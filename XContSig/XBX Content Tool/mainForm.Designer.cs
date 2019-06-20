namespace XBXContentTool
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.createPathButton = new System.Windows.Forms.Button();
            this.relativepathBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.offerTitleIdLabel = new System.Windows.Forms.Label();
            this.publisherFlagsLabel = new System.Windows.Forms.Label();
            this.contentFlagsLabel = new System.Windows.Forms.Label();
            this.contentTypeLabel = new System.Windows.Forms.Label();
            this.offerIdLabel = new System.Windows.Forms.Label();
            this.titleIdLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.openButton = new System.Windows.Forms.Button();
            this.filepathBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.skipBox = new System.Windows.Forms.CheckBox();
            this.keysButton = new System.Windows.Forms.Button();
            this.signButton = new System.Windows.Forms.Button();
            this.keyBox = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.sectionsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileList = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.languageBox = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.hexBox = new Be.Windows.Forms.HexBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.batchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.createPathButton);
            this.splitContainer1.Panel1.Controls.Add(this.relativepathBox);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.offerTitleIdLabel);
            this.splitContainer1.Panel1.Controls.Add(this.publisherFlagsLabel);
            this.splitContainer1.Panel1.Controls.Add(this.contentFlagsLabel);
            this.splitContainer1.Panel1.Controls.Add(this.contentTypeLabel);
            this.splitContainer1.Panel1.Controls.Add(this.offerIdLabel);
            this.splitContainer1.Panel1.Controls.Add(this.titleIdLabel);
            this.splitContainer1.Panel1.Controls.Add(this.typeLabel);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(997, 309);
            this.splitContainer1.SplitterDistance = 481;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 4;
            // 
            // createPathButton
            // 
            this.createPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createPathButton.Location = new System.Drawing.Point(383, 196);
            this.createPathButton.Name = "createPathButton";
            this.createPathButton.Size = new System.Drawing.Size(94, 23);
            this.createPathButton.TabIndex = 16;
            this.createPathButton.Text = "Create path..";
            this.toolTip1.SetToolTip(this.createPathButton, "Create the relative Xbox content path in a specified folder");
            this.createPathButton.UseVisualStyleBackColor = true;
            // 
            // relativepathBox
            // 
            this.relativepathBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.relativepathBox.Location = new System.Drawing.Point(6, 222);
            this.relativepathBox.Name = "relativepathBox";
            this.relativepathBox.ReadOnly = true;
            this.relativepathBox.Size = new System.Drawing.Size(471, 21);
            this.relativepathBox.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Xbox Path";
            // 
            // offerTitleIdLabel
            // 
            this.offerTitleIdLabel.AutoSize = true;
            this.offerTitleIdLabel.BackColor = System.Drawing.Color.Transparent;
            this.offerTitleIdLabel.Location = new System.Drawing.Point(195, 119);
            this.offerTitleIdLabel.Name = "offerTitleIdLabel";
            this.offerTitleIdLabel.Size = new System.Drawing.Size(95, 15);
            this.offerTitleIdLabel.TabIndex = 13;
            this.offerTitleIdLabel.Text = "Offer Title ID (?):";
            // 
            // publisherFlagsLabel
            // 
            this.publisherFlagsLabel.AutoSize = true;
            this.publisherFlagsLabel.BackColor = System.Drawing.Color.Transparent;
            this.publisherFlagsLabel.Location = new System.Drawing.Point(3, 146);
            this.publisherFlagsLabel.Name = "publisherFlagsLabel";
            this.publisherFlagsLabel.Size = new System.Drawing.Size(95, 15);
            this.publisherFlagsLabel.TabIndex = 12;
            this.publisherFlagsLabel.Text = "Publisher Flags:";
            // 
            // contentFlagsLabel
            // 
            this.contentFlagsLabel.AutoSize = true;
            this.contentFlagsLabel.BackColor = System.Drawing.Color.Transparent;
            this.contentFlagsLabel.Location = new System.Drawing.Point(195, 94);
            this.contentFlagsLabel.Name = "contentFlagsLabel";
            this.contentFlagsLabel.Size = new System.Drawing.Size(103, 15);
            this.contentFlagsLabel.TabIndex = 11;
            this.contentFlagsLabel.Text = "Content Flags (?):";
            // 
            // contentTypeLabel
            // 
            this.contentTypeLabel.AutoSize = true;
            this.contentTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.contentTypeLabel.Location = new System.Drawing.Point(195, 67);
            this.contentTypeLabel.Name = "contentTypeLabel";
            this.contentTypeLabel.Size = new System.Drawing.Size(99, 15);
            this.contentTypeLabel.TabIndex = 10;
            this.contentTypeLabel.Text = "Content Type (?):";
            // 
            // offerIdLabel
            // 
            this.offerIdLabel.AutoSize = true;
            this.offerIdLabel.BackColor = System.Drawing.Color.Transparent;
            this.offerIdLabel.Location = new System.Drawing.Point(3, 119);
            this.offerIdLabel.Name = "offerIdLabel";
            this.offerIdLabel.Size = new System.Drawing.Size(51, 15);
            this.offerIdLabel.TabIndex = 9;
            this.offerIdLabel.Text = "Offer ID:";
            // 
            // titleIdLabel
            // 
            this.titleIdLabel.AutoSize = true;
            this.titleIdLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleIdLabel.Location = new System.Drawing.Point(3, 94);
            this.titleIdLabel.Name = "titleIdLabel";
            this.titleIdLabel.Size = new System.Drawing.Size(48, 15);
            this.titleIdLabel.TabIndex = 8;
            this.titleIdLabel.Text = "Title ID:";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.BackColor = System.Drawing.Color.Transparent;
            this.typeLabel.Location = new System.Drawing.Point(3, 67);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(36, 15);
            this.typeLabel.TabIndex = 7;
            this.typeLabel.Text = "Type:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.openButton);
            this.groupBox2.Controls.Add(this.filepathBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(481, 53);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File";
            // 
            // openButton
            // 
            this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openButton.Location = new System.Drawing.Point(415, 18);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(62, 25);
            this.openButton.TabIndex = 4;
            this.openButton.Text = "Open..";
            this.openButton.UseVisualStyleBackColor = true;
            // 
            // filepathBox
            // 
            this.filepathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filepathBox.Location = new System.Drawing.Point(3, 21);
            this.filepathBox.Name = "filepathBox";
            this.filepathBox.ReadOnly = true;
            this.filepathBox.Size = new System.Drawing.Size(407, 21);
            this.filepathBox.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.batchButton);
            this.groupBox1.Controls.Add(this.skipBox);
            this.groupBox1.Controls.Add(this.keysButton);
            this.groupBox1.Controls.Add(this.signButton);
            this.groupBox1.Controls.Add(this.keyBox);
            this.groupBox1.Location = new System.Drawing.Point(-14, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 74);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // skipBox
            // 
            this.skipBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.skipBox.AutoSize = true;
            this.skipBox.Location = new System.Drawing.Point(334, 11);
            this.skipBox.Name = "skipBox";
            this.skipBox.Size = new System.Drawing.Size(140, 19);
            this.skipBox.TabIndex = 3;
            this.skipBox.Text = "Skip content hashing";
            this.toolTip1.SetToolTip(this.skipBox, "If checked, the external content files (files that are included in the contentmet" +
        "a) will not be hashed before signing.\r\n\r\nCheck this if the any of the files are " +
        "shown as not valid");
            this.skipBox.UseVisualStyleBackColor = true;
            // 
            // keysButton
            // 
            this.keysButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.keysButton.Location = new System.Drawing.Point(239, 25);
            this.keysButton.Name = "keysButton";
            this.keysButton.Size = new System.Drawing.Size(65, 25);
            this.keysButton.TabIndex = 2;
            this.keysButton.Text = "Keys..";
            this.keysButton.UseVisualStyleBackColor = true;
            // 
            // signButton
            // 
            this.signButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.signButton.Location = new System.Drawing.Point(334, 31);
            this.signButton.Name = "signButton";
            this.signButton.Size = new System.Drawing.Size(105, 25);
            this.signButton.TabIndex = 1;
            this.signButton.Text = "Sign content";
            this.signButton.UseVisualStyleBackColor = true;
            // 
            // keyBox
            // 
            this.keyBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keyBox.FormattingEnabled = true;
            this.keyBox.Location = new System.Drawing.Point(17, 26);
            this.keyBox.Name = "keyBox";
            this.keyBox.Size = new System.Drawing.Size(220, 23);
            this.keyBox.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(511, 309);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(503, 281);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sections / Content";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.sectionsList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.fileList);
            this.splitContainer2.Size = new System.Drawing.Size(497, 275);
            this.splitContainer2.SplitterDistance = 104;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // sectionsList
            // 
            this.sectionsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader9,
            this.columnHeader2,
            this.columnHeader3});
            this.sectionsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectionsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sectionsList.FullRowSelect = true;
            this.sectionsList.GridLines = true;
            this.sectionsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.sectionsList.Location = new System.Drawing.Point(0, 0);
            this.sectionsList.MultiSelect = false;
            this.sectionsList.Name = "sectionsList";
            this.sectionsList.Size = new System.Drawing.Size(497, 104);
            this.sectionsList.TabIndex = 3;
            this.sectionsList.UseCompatibleStateImageBehavior = false;
            this.sectionsList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Section";
            this.columnHeader1.Width = 236;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Allocated";
            this.columnHeader9.Width = 63;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size (bytes)";
            this.columnHeader2.Width = 87;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Valid";
            this.columnHeader3.Width = 58;
            // 
            // fileList
            // 
            this.fileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader6,
            this.columnHeader7});
            this.fileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileList.FullRowSelect = true;
            this.fileList.GridLines = true;
            this.fileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.fileList.Location = new System.Drawing.Point(0, 0);
            this.fileList.MultiSelect = false;
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(497, 166);
            this.fileList.TabIndex = 5;
            this.fileList.UseCompatibleStateImageBehavior = false;
            this.fileList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "File";
            this.columnHeader4.Width = 125;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Size";
            this.columnHeader5.Width = 90;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Size (bytes)";
            this.columnHeader8.Width = 78;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Exists";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Valid";
            this.columnHeader7.Width = 67;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.languageBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(503, 283);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Language";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // languageBox
            // 
            this.languageBox.DetectUrls = false;
            this.languageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.languageBox.Location = new System.Drawing.Point(3, 3);
            this.languageBox.Name = "languageBox";
            this.languageBox.ReadOnly = true;
            this.languageBox.Size = new System.Drawing.Size(497, 277);
            this.languageBox.TabIndex = 0;
            this.languageBox.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.hexBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(503, 283);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Optional / Unknown";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // hexBox
            // 
            this.hexBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexBox.LineInfoForeColor = System.Drawing.Color.Empty;
            this.hexBox.LineInfoVisible = true;
            this.hexBox.Location = new System.Drawing.Point(3, 3);
            this.hexBox.Name = "hexBox";
            this.hexBox.ReadOnly = true;
            this.hexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox.Size = new System.Drawing.Size(497, 277);
            this.hexBox.TabIndex = 0;
            this.hexBox.UseFixedBytesPerLine = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 50;
            this.toolTip1.AutoPopDelay = 60000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 10;
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // batchButton
            // 
            this.batchButton.Location = new System.Drawing.Point(440, 31);
            this.batchButton.Name = "batchButton";
            this.batchButton.Size = new System.Drawing.Size(55, 25);
            this.batchButton.TabIndex = 17;
            this.batchButton.Text = "Batch..";
            this.batchButton.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 309);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1013, 348);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XBX Content Tool";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.TextBox filepathBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button keysButton;
        private System.Windows.Forms.Button signButton;
        private System.Windows.Forms.ComboBox keyBox;
        private System.Windows.Forms.RichTextBox languageBox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView sectionsList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView fileList;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private Be.Windows.Forms.HexBox hexBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label titleIdLabel;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label offerIdLabel;
        private System.Windows.Forms.Button createPathButton;
        private System.Windows.Forms.TextBox relativepathBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label offerTitleIdLabel;
        private System.Windows.Forms.Label publisherFlagsLabel;
        private System.Windows.Forms.Label contentFlagsLabel;
        private System.Windows.Forms.Label contentTypeLabel;
        private System.Windows.Forms.CheckBox skipBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button batchButton;
    }
}

