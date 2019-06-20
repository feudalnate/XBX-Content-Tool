using System.Collections.Generic;
using System.Windows.Forms;
using XBXContentTool.Xbox;

namespace XBXContentTool
{
    public partial class keyForm : Form
    {
        private UI.Keys keys;

        public keyForm()
        {
            InitializeComponent();

            Shown += (s, e) => { LoadKeys(); };

            importButton.Click += (s, e) =>
            {
                using (OpenFileDialog open = new OpenFileDialog())
                {
                    open.Filter = "Xbox 360 Keyvault (*.bin)|*.bin|All Files (*.*)|*.*";
                    if (open.ShowDialog() != DialogResult.OK) return;
                    string consoleSerial, motherboardSerial;
                    if (XCalcSig.FromKV(open.FileName, out consoleSerial, out motherboardSerial))
                    {
                        consoleSerialBox.Text = consoleSerial;
                        motherboardSerialBox.Text = motherboardSerial;
                        return;
                    }
                    MessageBox.Show("Failed to read KV file");
                }
            };

            removeButton.Click += (s, e) =>
            {
                if (!(Equals(null, keyList.Items) && keyList.Items.Count > 0))
                {
                    foreach (ListViewItem item in keyList.CheckedItems)
                    {
                        keys.Remove(item.Text, item.SubItems[1].Text.ToBytes(true));
                        keyList.Items.Remove(item);
                    }
                    LoadKeys();
                }
            };

            makeButton.Click += (s, e) =>
            {
                if (makeAliasBox.Text.Length == 0)
                {
                    MessageBox.Show("Alias name must not be empty");
                    return;
                }
                long consoleSerial; 
                if (consoleSerialBox.Text.Length != 12 || !long.TryParse(consoleSerialBox.Text, out consoleSerial))
                {
                    MessageBox.Show("Invalid console serial");
                    return;
                }
                if (motherboardSerialBox.Text.Length != 16 || !motherboardSerialBox.Text.IsHex())
                {
                    MessageBox.Show("Invalid motherboard serial");
                    return;
                }
                string alias = makeAliasBox.Text;
                if (keys.Contains(alias))
                {
                    MessageBox.Show("Alias already in use");
                    return;
                }
                byte[] key = XCalcSig.MakeXboxHDKey(consoleSerialBox.Text, motherboardSerialBox.Text);
                if (keys.Contains(key))
                {
                    MessageBox.Show("Key already added under another alias");
                    return;
                }
                keys.Add(new UI.Keys.Key() { alias = alias, key = key });
                LoadKeys();
            };

            addKeyButton.Click += (s, e) =>
            {
                if (addAliasBox.Text.Length == 0)
                {
                    MessageBox.Show("Alias name must not be empty");
                    return;
                }
                if (keyBox.Text.Length != 32 || !keyBox.Text.IsHex())
                {
                    MessageBox.Show("Invalid XboxHDKey");
                    return;
                }
                string alias = addAliasBox.Text;
                if (keys.Contains(alias))
                {
                    MessageBox.Show("Alias already in use");
                    return;
                }
                byte[] key = keyBox.Text.ToBytes(true);
                if (keys.Contains(key))
                {
                    MessageBox.Show("Key already added under another alias");
                    return;
                }
                keys.Add(new UI.Keys.Key() { alias = alias, key = key });
                LoadKeys();
            };

        }

        private void LoadKeys()
        {
            UI.Win32.SuspendDrawing(this);
            keyList.Items.Clear();
            List<ListViewItem> items = new List<ListViewItem>();
            ListViewItem item;
            foreach (UI.Keys.Key key in keys.ToArray())
            {
                item = new ListViewItem(key.alias);
                item.SubItems.Add(key.key.ToHex());
                items.Add(item);
            }
            keyList.Items.AddRange(items.ToArray());
            items.Clear();
            UI.Win32.ResumeDrawing(this);
        }

        public UI.Keys ShowDialog(Form parent, UI.Keys keys)
        {
            this.keys = keys;
            ShowDialog(parent);
            return this.keys;
        }

    }
}
