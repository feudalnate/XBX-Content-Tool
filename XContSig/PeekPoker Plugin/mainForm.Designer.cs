namespace Plugin
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
            this.consoleLabel = new System.Windows.Forms.Label();
            this.macLabel = new System.Windows.Forms.Label();
            this.videoLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.xboxhdkeyBox = new System.Windows.Forms.TextBox();
            this.readSaveButton = new System.Windows.Forms.Button();
            this.motherboardLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // consoleLabel
            // 
            this.consoleLabel.AutoSize = true;
            this.consoleLabel.BackColor = System.Drawing.Color.Transparent;
            this.consoleLabel.Location = new System.Drawing.Point(12, 9);
            this.consoleLabel.Name = "consoleLabel";
            this.consoleLabel.Size = new System.Drawing.Size(91, 15);
            this.consoleLabel.TabIndex = 0;
            this.consoleLabel.Text = "Console serial: ";
            // 
            // macLabel
            // 
            this.macLabel.AutoSize = true;
            this.macLabel.BackColor = System.Drawing.Color.Transparent;
            this.macLabel.Location = new System.Drawing.Point(12, 63);
            this.macLabel.Name = "macLabel";
            this.macLabel.Size = new System.Drawing.Size(86, 15);
            this.macLabel.TabIndex = 1;
            this.macLabel.Text = "MAC address: ";
            // 
            // videoLabel
            // 
            this.videoLabel.AutoSize = true;
            this.videoLabel.BackColor = System.Drawing.Color.Transparent;
            this.videoLabel.Location = new System.Drawing.Point(12, 90);
            this.videoLabel.Name = "videoLabel";
            this.videoLabel.Size = new System.Drawing.Size(95, 15);
            this.videoLabel.TabIndex = 2;
            this.videoLabel.Text = "Video standard: ";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "XboxHDKey:";
            // 
            // xboxhdkeyBox
            // 
            this.xboxhdkeyBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.xboxhdkeyBox.Location = new System.Drawing.Point(15, 140);
            this.xboxhdkeyBox.Name = "xboxhdkeyBox";
            this.xboxhdkeyBox.ReadOnly = true;
            this.xboxhdkeyBox.Size = new System.Drawing.Size(280, 21);
            this.xboxhdkeyBox.TabIndex = 4;
            // 
            // readSaveButton
            // 
            this.readSaveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.readSaveButton.Location = new System.Drawing.Point(222, 113);
            this.readSaveButton.Name = "readSaveButton";
            this.readSaveButton.Size = new System.Drawing.Size(73, 23);
            this.readSaveButton.TabIndex = 5;
            this.readSaveButton.Text = "Read";
            this.readSaveButton.UseVisualStyleBackColor = true;
            // 
            // motherboardLabel
            // 
            this.motherboardLabel.AutoSize = true;
            this.motherboardLabel.BackColor = System.Drawing.Color.Transparent;
            this.motherboardLabel.Location = new System.Drawing.Point(12, 36);
            this.motherboardLabel.Name = "motherboardLabel";
            this.motherboardLabel.Size = new System.Drawing.Size(117, 15);
            this.motherboardLabel.TabIndex = 6;
            this.motherboardLabel.Text = "Motherboard serial: ";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 173);
            this.Controls.Add(this.motherboardLabel);
            this.Controls.Add(this.readSaveButton);
            this.Controls.Add(this.xboxhdkeyBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.videoLabel);
            this.Controls.Add(this.macLabel);
            this.Controls.Add(this.consoleLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "XBX Content Tool - Plugin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label consoleLabel;
        private System.Windows.Forms.Label macLabel;
        private System.Windows.Forms.Label videoLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox xboxhdkeyBox;
        private System.Windows.Forms.Button readSaveButton;
        private System.Windows.Forms.Label motherboardLabel;
    }
}