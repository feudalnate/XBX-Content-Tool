namespace XBXContentTool
{
    partial class keyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(keyForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.keyList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.removeButton = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.addKeyButton = new System.Windows.Forms.Button();
            this.keyBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addAliasBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.importButton = new System.Windows.Forms.Button();
            this.consoleSerialBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.motherboardSerialBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.makeButton = new System.Windows.Forms.Button();
            this.makeAliasBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.keyList);
            this.splitContainer1.Panel1.Controls.Add(this.toolbar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(587, 322);
            this.splitContainer1.SplitterDistance = 188;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // keyList
            // 
            this.keyList.CheckBoxes = true;
            this.keyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.keyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyList.FullRowSelect = true;
            this.keyList.GridLines = true;
            this.keyList.Location = new System.Drawing.Point(0, 0);
            this.keyList.MultiSelect = false;
            this.keyList.Name = "keyList";
            this.keyList.Size = new System.Drawing.Size(585, 161);
            this.keyList.TabIndex = 0;
            this.keyList.UseCompatibleStateImageBehavior = false;
            this.keyList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Alias";
            this.columnHeader1.Width = 157;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Key";
            this.columnHeader2.Width = 335;
            // 
            // toolbar
            // 
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeButton});
            this.toolbar.Location = new System.Drawing.Point(0, 161);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(585, 25);
            this.toolbar.TabIndex = 1;
            // 
            // removeButton
            // 
            this.removeButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.removeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.removeButton.Image = ((System.Drawing.Image)(resources.GetObject("removeButton.Image")));
            this.removeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(100, 22);
            this.removeButton.Text = "Remove selected";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(585, 127);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.addKeyButton);
            this.tabPage1.Controls.Add(this.keyBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.addAliasBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(577, 99);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Key";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // addKeyButton
            // 
            this.addKeyButton.Location = new System.Drawing.Point(464, 67);
            this.addKeyButton.Name = "addKeyButton";
            this.addKeyButton.Size = new System.Drawing.Size(106, 25);
            this.addKeyButton.TabIndex = 4;
            this.addKeyButton.Text = "Add key";
            this.addKeyButton.UseVisualStyleBackColor = true;
            // 
            // keyBox
            // 
            this.keyBox.Location = new System.Drawing.Point(9, 69);
            this.keyBox.MaxLength = 32;
            this.keyBox.Name = "keyBox";
            this.keyBox.Size = new System.Drawing.Size(449, 21);
            this.keyBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "XboxHDKey (32 character hex string)";
            // 
            // addAliasBox
            // 
            this.addAliasBox.Location = new System.Drawing.Point(9, 23);
            this.addAliasBox.MaxLength = 64;
            this.addAliasBox.Name = "addAliasBox";
            this.addAliasBox.Size = new System.Drawing.Size(561, 21);
            this.addAliasBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alias";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.importButton);
            this.tabPage2.Controls.Add(this.consoleSerialBox);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.motherboardSerialBox);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.makeButton);
            this.tabPage2.Controls.Add(this.makeAliasBox);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(577, 99);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Make Key (Xbox 360)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(464, 38);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(106, 25);
            this.importButton.TabIndex = 14;
            this.importButton.Text = "Import from KV..";
            this.importButton.UseVisualStyleBackColor = true;
            // 
            // consoleSerialBox
            // 
            this.consoleSerialBox.Location = new System.Drawing.Point(9, 69);
            this.consoleSerialBox.MaxLength = 12;
            this.consoleSerialBox.Name = "consoleSerialBox";
            this.consoleSerialBox.Size = new System.Drawing.Size(179, 21);
            this.consoleSerialBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Console serial (12 digit number)";
            // 
            // motherboardSerialBox
            // 
            this.motherboardSerialBox.Location = new System.Drawing.Point(202, 69);
            this.motherboardSerialBox.MaxLength = 16;
            this.motherboardSerialBox.Name = "motherboardSerialBox";
            this.motherboardSerialBox.Size = new System.Drawing.Size(256, 21);
            this.motherboardSerialBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(246, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Motherboard serial (16 character hex string)";
            // 
            // makeButton
            // 
            this.makeButton.Location = new System.Drawing.Point(464, 67);
            this.makeButton.Name = "makeButton";
            this.makeButton.Size = new System.Drawing.Size(106, 25);
            this.makeButton.TabIndex = 9;
            this.makeButton.Text = "Add key";
            this.makeButton.UseVisualStyleBackColor = true;
            // 
            // makeAliasBox
            // 
            this.makeAliasBox.Location = new System.Drawing.Point(9, 23);
            this.makeAliasBox.MaxLength = 64;
            this.makeAliasBox.Name = "makeAliasBox";
            this.makeAliasBox.Size = new System.Drawing.Size(449, 21);
            this.makeAliasBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Alias";
            // 
            // keyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 322);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "keyForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Keys";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView keyList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton removeButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button addKeyButton;
        private System.Windows.Forms.TextBox keyBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addAliasBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox consoleSerialBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox motherboardSerialBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button makeButton;
        private System.Windows.Forms.TextBox makeAliasBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button importButton;
    }
}