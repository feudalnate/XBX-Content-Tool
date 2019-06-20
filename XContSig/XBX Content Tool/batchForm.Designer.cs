namespace XBXContentTool
{
    partial class batchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(batchForm));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.keyBox = new System.Windows.Forms.ToolStripComboBox();
            this.keysButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.skipBox = new System.Windows.Forms.CheckBox();
            this.signButton = new System.Windows.Forms.ToolStripButton();
            this.addButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearButton = new System.Windows.Forms.ToolStripButton();
            this.fileList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyBox,
            this.keysButton,
            this.toolStripSeparator1,
            this.signButton,
            this.addButton,
            this.toolStripSeparator2,
            this.clearButton});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(1034, 25);
            this.toolbar.TabIndex = 0;
            this.toolbar.Text = "toolStrip1";
            // 
            // keyBox
            // 
            this.keyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keyBox.Name = "keyBox";
            this.keyBox.Size = new System.Drawing.Size(233, 25);
            // 
            // keysButton
            // 
            this.keysButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.keysButton.Image = ((System.Drawing.Image)(resources.GetObject("keysButton.Image")));
            this.keysButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.keysButton.Name = "keysButton";
            this.keysButton.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.keysButton.Size = new System.Drawing.Size(46, 22);
            this.keysButton.Text = "Keys..";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // skipBox
            // 
            this.skipBox.AutoSize = true;
            this.skipBox.Location = new System.Drawing.Point(287, 1);
            this.skipBox.Name = "skipBox";
            this.skipBox.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.skipBox.Size = new System.Drawing.Size(142, 22);
            this.skipBox.TabIndex = 1;
            this.skipBox.Text = "Skip content hashing";
            // 
            // signButton
            // 
            this.signButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.signButton.Image = ((System.Drawing.Image)(resources.GetObject("signButton.Image")));
            this.signButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.signButton.Name = "signButton";
            this.signButton.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.signButton.Size = new System.Drawing.Size(83, 22);
            this.signButton.Text = "Sign content";
            // 
            // addButton
            // 
            this.addButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.addButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addButton.Image = ((System.Drawing.Image)(resources.GetObject("addButton.Image")));
            this.addButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(102, 22);
            this.addButton.Text = "Add from folder..";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // clearButton
            // 
            this.clearButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.clearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearButton.Image = ((System.Drawing.Image)(resources.GetObject("clearButton.Image")));
            this.clearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(38, 22);
            this.clearButton.Text = "Clear";
            // 
            // fileList
            // 
            this.fileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.fileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileList.FullRowSelect = true;
            this.fileList.GridLines = true;
            this.fileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.fileList.Location = new System.Drawing.Point(0, 25);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(1034, 322);
            this.fileList.TabIndex = 2;
            this.fileList.UseCompatibleStateImageBehavior = false;
            this.fileList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File path";
            this.columnHeader1.Width = 718;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Result";
            this.columnHeader2.Width = 310;
            // 
            // batchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 347);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.toolbar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "batchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Batch";
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.CheckBox skipBox;
        private System.Windows.Forms.ToolStripComboBox keyBox;
        private System.Windows.Forms.ToolStripButton keysButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton signButton;
        private System.Windows.Forms.ToolStripButton addButton;
        private System.Windows.Forms.ListView fileList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton clearButton;
    }
}