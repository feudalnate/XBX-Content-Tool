using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using XBXContentTool.UI;
using XBXContentTool.Xbox;

namespace XBXContentTool
{
    public partial class batchForm : Form
    {
        private List<ContentMeta> batchItems;
        private UI.Keys keys;

        public batchForm()
        {
            batchItems = new List<ContentMeta>();
            InitializeComponent();
            if (!toolbar.Contains(skipBox))
            {
                Win32.SuspendDrawing(this);
                toolbar.Items.Insert(3, new ToolStripControlHost(skipBox));
                Win32.ResumeDrawing(this);
            }

            Shown += (s, e) => { LoadKeys(); };

            FormClosing += (s, e) =>
            {
                if(!Equals(null, batchItems) && batchItems.Count > 0)
                {
                    foreach (ContentMeta contentMeta in batchItems) contentMeta.Dispose();
                    batchItems.Clear();
                }
            };

            keysButton.Click += (s, e) =>
            {
                keys = new keyForm().ShowDialog(this, keys);
                LoadKeys();
            };

            clearButton.Click += (s, e) =>
            {
                if (Equals(null, batchItems)) return;
                foreach (ContentMeta contentMeta in batchItems) contentMeta.Dispose();
                batchItems.Clear();
                LoadItems();
            };

            addButton.Click += (s, e) =>
            {
                string path;
                using (FolderBrowserDialog folder = new FolderBrowserDialog())
                {
                    folder.Description = "Select folder containing ContentMeta.xbx files";
                    if (folder.ShowDialog() != DialogResult.OK) return;
                    path = folder.SelectedPath;
                }

                IEnumerable<string> files = Directory.EnumerateFiles(path, "*.xbx", SearchOption.AllDirectories);
                if (Equals(null, files) || files.Count() == 0)
                {
                    MessageBox.Show("No .xbx files found");
                    return;
                }

                List<ContentMeta> items = new List<ContentMeta>();
                ContentMeta item;
                bool success;
                foreach (string file in files)
                {
                    item = new ContentMeta(file, out success);
                    foreach (ContentMeta contentMeta in batchItems)
                    {
                        if (contentMeta.FilePath == file)
                        {
                            success = false;
                            break;
                        }
                    }
                    if (success) items.Add(item);
                }

                if (items.Count == 0)
                {
                    MessageBox.Show("No valid .xbx files found");
                    return;
                }

                batchItems.AddRange(items);
                LoadItems();

            };

            signButton.Click += (s, e) =>
            {
                if (Equals(null, batchItems) || batchItems.Count == 0) return;
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
                string result;
                new Thread(delegate ()
                {
                    Invoke((Action)delegate
                    {
                        signButton.Enabled = false;
                        addButton.Enabled = false;
                        clearButton.Enabled = false;
                        keysButton.Enabled = false;

                        foreach (ListViewItem item in fileList.Items) item.SubItems[1].Text = null;
                        fileList.RedrawItems(0, (fileList.Items.Count - 1), false);
                    });

                    int i = 0;
                    foreach (ContentMeta contentMeta in batchItems)
                    {
                        result = Sign(contentMeta, key, skipContentHashing);
                        Invoke((Action)delegate
                        {
                            fileList.Items[i].SubItems[1].Text = result;
                            fileList.RedrawItems(i, i, false);
                        });
                        i++;
                    }

                    Invoke((Action)delegate
                    {
                        signButton.Enabled = true;
                        addButton.Enabled = true;
                        clearButton.Enabled = true;
                        keysButton.Enabled = true;
                    });

                    Thread.CurrentThread.Abort();
                }).Start();
            };

        }


        private void LoadItems()
        {
            if (Equals(null, batchItems)) return;
            Win32.SuspendDrawing(this);

            List<ListViewItem> items = new List<ListViewItem>();
            ListViewItem item;
            foreach (ContentMeta contentMeta in batchItems)
            {
                item = new ListViewItem(contentMeta.FilePath);
                item.SubItems.Add("");
                items.Add(item);
            }
            fileList.Items.Clear();
            if (items.Count > 0) fileList.Items.AddRange(items.ToArray());
            Win32.ResumeDrawing(this);
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

        private string Sign(ContentMeta contentMeta, byte[] key, bool skipContentHashing)
        {
            if (Equals(null, contentMeta)) return "";
            string error;
            if (!contentMeta.Sign(key, skipContentHashing, out error))
            {
                return string.Format("Error: {0}", error);
            }
            return "Signed successfully";
        }

        public UI.Keys ShowDialog(Form parent, UI.Keys keys)
        {
            this.keys = keys;
            ShowDialog(parent);
            return this.keys;
        }

    }
}
