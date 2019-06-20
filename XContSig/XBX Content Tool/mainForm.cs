using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using XBXContentTool.UI;
using XBXContentTool.Xbox;

namespace XBXContentTool
{
    public partial class mainForm : Form
    {
        UI.Keys keys;
        ContentMeta contentMeta;

        public mainForm()
        {
            InitializeComponent();

            //add control events
            Load += (s, e) =>
            {
                keys = new UI.Keys();
                if (File.Exists("keys.json")) keys.Load("keys.json");
            };

            Shown += (s, e) => { LoadKeys(); };

            FormClosing += (s, e) =>
            {
                if (!Equals(null, contentMeta)) contentMeta.Dispose();
                keys.Save("keys.json");
            };

            keysButton.Click += (s, e) =>
            {
                keys = new keyForm().ShowDialog(this, keys);
                LoadKeys();
            };

            openButton.Click += (s, e) =>
            {
                using (OpenFileDialog open = new OpenFileDialog())
                {
                    open.Filter = "Xbox Content (*.xbx)|*.xbx|All Files (*.*)|*.*";
                    if (open.ShowDialog() != DialogResult.OK) return;
                    Open(open.FileName);
                }
            };

            batchButton.Click += (s, e) =>
            {
                keys = new batchForm().ShowDialog(this, keys);
                LoadKeys();
            };

            createPathButton.Click += (s, e) =>
            {
                if (Equals(null, contentMeta)) return;
                using (FolderBrowserDialog folder = new FolderBrowserDialog())
                {
                    folder.Description = "Select where content path will be created";
                    if (folder.ShowDialog() != DialogResult.OK) return;
                    DirectoryInfo directory = Directory.CreateDirectory(string.Format("{0}{1}", folder.SelectedPath, contentMeta.RelativePath));
                    MessageBox.Show(string.Format("Content path created:\n\n{0}", directory.FullName));
                }
            };

            signButton.Click += (s, e) =>
            {
                if (Equals(null, contentMeta)) return;
                if (keys.Count == 0)
                {
                    MessageBox.Show("You must add a key to sign content with");
                    return;
                }
                string alias = (string)keyBox.SelectedItem;
                if (string.IsNullOrEmpty(alias))
                {
                    MessageBox.Show("Invalid key selected");
                    return;
                }
                bool exists;
                byte[] key = keys.GetKey(alias, out exists);
                if (!exists)
                {
                    MessageBox.Show("Selected key does not exist");
                    return;
                }
                bool skipContentHashing = skipBox.Checked;
                Sign(key, skipContentHashing);
            };

        }

        private void Open(string file)
        {
            bool parseSuccess = false;
            if (!Equals(null, contentMeta)) contentMeta.Dispose();
            contentMeta = new ContentMeta(file, out parseSuccess);
            if (!parseSuccess)
            {
                MessageBox.Show("Invalid file\n\nFailed to parse content header");
                return;
            }

            //use a seperate thread for loading data to ui since there will be io and hashing
            new Thread(new ThreadStart(PopulateUI)).Start();
        }

        private void ReOpen()
        {
            if (Equals(null, contentMeta)) return;
            string file = contentMeta.FilePath;
            contentMeta.Dispose();
            contentMeta = null;
            Open(file);
        }

        private void Sign(byte[] key, bool skipContentHashing)
        {
            //instead of doing this on another thread (because possible content hashing), its easier to let the UI hang for the duration so controls dont need to be disabled
            if (Equals(null, contentMeta)) return;
            string error;
            if (!contentMeta.Sign(key, skipContentHashing, out error))
            {
                MessageBox.Show(string.Format("Error: {0}", error));
                return;
            }
            MessageBox.Show(string.Format("{0} was signed successfully", contentMeta.FilePath));
            ReOpen();
        }

        private void LoadKeys()
        {
            keyBox.Items.Clear();
            List<string> items = new List<string>();
            foreach (UI.Keys.Key key in keys.ToArray())
            {
                items.Add(key.alias);
            }
            if (items.Count > 0)
            {
                keyBox.Items.AddRange(items.ToArray());
                keyBox.SelectedIndex = 0;
            }
        }

        private void PopulateUI()
        {
            CheckForIllegalCrossThreadCalls = false; //rather than invoking controls one by one or storing extra varibles, I decided to take the shortcut
            Win32.SuspendDrawing(this);

            filepathBox.Text = contentMeta.FilePath;

            //header info

            typeLabel.Text = string.Format("Type: {0}", Enum.GetName(typeof(ContentMeta.Types.HeaderType), contentMeta.Header.headerType));

            byte[] buffer = BitConverter.GetBytes(contentMeta.Header.titleId);
            Array.Reverse(buffer, 2, 2);
            string catalogId = string.Format("{0}-{1}", Encoding.UTF8.GetString(buffer, 2, 2), BitConverter.ToUInt16(buffer, 0));
            titleIdLabel.Text = string.Format("Title ID: {0} ({1})", contentMeta.Header.titleId.ToString("X2"), catalogId);

            offerIdLabel.Text = string.Format("Offer ID: {0}", contentMeta.Header.offerId.ToString("X2").PadLeft(8, '0'));

            publisherFlagsLabel.Text = string.Format("Publisher Flags: {0}", contentMeta.Header.publisherFlags.ToString("X2").PadLeft(8, '0'));

            contentTypeLabel.Text = string.Format("Content Type (?): {0}", contentMeta.Header.contentType.ToString("X2").PadLeft(8, '0'));

            contentFlagsLabel.Text = string.Format("Content Flags (?): {0}", contentMeta.Header.contentFlags.ToString("X2").PadLeft(8, '0'));

            offerTitleIdLabel.Text = string.Format("Offer Title ID (?): {0}", contentMeta.Header.offerTitleId.ToString("X2").PadLeft(8, '0'));

            relativepathBox.Text = contentMeta.RelativePath;


            ListViewItem item;
            List<ListViewItem> items;

            //header type specific sections
            object result;
            if (contentMeta.Header.headerType == ContentMeta.Types.HeaderType.Content)
            {
                //required for dlc
                if (contentMeta.GetSection(ContentMeta.Types.SectionType.Language, out result))
                    languageBox.Text = (string)result;

                //usually unallocated
                if (contentMeta.GetSection(ContentMeta.Types.SectionType.Optional, out result))
                    hexBox.ByteProvider = new Be.Windows.Forms.DynamicByteProvider((byte[])result);
            }
            else
            {
                languageBox.Text = "";

                //this section im unsure of, specific to updates and always 0x44 size - possibly install flags? developer flags? purchase flags?
                if (contentMeta.GetSection(ContentMeta.Types.SectionType.Unknown, out result))
                    hexBox.ByteProvider = new Be.Windows.Forms.DynamicByteProvider((byte[])result);
            }

            //file list
            if (contentMeta.GetSection(ContentMeta.Types.SectionType.TableOfContents, out result))
            {
                ContentMeta.Types.TableOfContents fileTable = (ContentMeta.Types.TableOfContents)result;
                string root = Path.GetDirectoryName(contentMeta.FilePath);

                Array.Sort(fileTable.entries, (x, y) => string.Compare(x.fileName, y.fileName));
                items = new List<ListViewItem>();
                foreach (ContentMeta.Types.TableEntry file in fileTable.entries)
                {
                    item = new ListViewItem(file.fileName);
                    item.SubItems.Add(file.fileSize.RoundBytes());
                    item.SubItems.Add(file.fileSize.ToString());
                    item.SubItems.Add(file.Exists(root).ToString());
                    item.SubItems.Add(file.IsValid(root).ToString());
                    items.Add(item);
                }
                fileList.Items.Clear();
                fileList.Items.AddRange(items.ToArray());
            }

            //section list
            items = new List<ListViewItem>();
            foreach (ContentMeta.Types.Section section in contentMeta.Sections)
            {
                item = new ListViewItem(Enum.GetName(typeof(ContentMeta.Types.SectionType), section.sectionType));
                item.SubItems.Add(section.IsAllocated.ToString());
                item.SubItems.Add(section.sectionLength.ToString());
                item.SubItems.Add(section.IsValid.ToString());
                items.Add(item);
            }
            sectionsList.Items.Clear();
            sectionsList.Items.AddRange(items.ToArray());


            buffer = null;

            Win32.ResumeDrawing(this);

            Thread.CurrentThread.Abort();
        }

    }
}
