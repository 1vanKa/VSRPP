namespace Bntu.Vsrpp.Ikarpovich.Lab1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.operationsLabel = new System.Windows.Forms.Label();
            this.operationsComboBox = new System.Windows.Forms.ComboBox();
            this.parametersLabel = new System.Windows.Forms.Label();
            this.parametersComboBox = new System.Windows.Forms.ComboBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.operationResultLabel = new System.Windows.Forms.Label();
            this.formatButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 28);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(367, 410);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // operationsLabel
            // 
            this.operationsLabel.AutoSize = true;
            this.operationsLabel.Location = new System.Drawing.Point(386, 31);
            this.operationsLabel.Name = "operationsLabel";
            this.operationsLabel.Size = new System.Drawing.Size(65, 15);
            this.operationsLabel.TabIndex = 2;
            this.operationsLabel.Text = "Operations";
            // 
            // operationsComboBox
            // 
            this.operationsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationsComboBox.FormattingEnabled = true;
            this.operationsComboBox.Location = new System.Drawing.Point(458, 27);
            this.operationsComboBox.Name = "operationsComboBox";
            this.operationsComboBox.Size = new System.Drawing.Size(121, 23);
            this.operationsComboBox.TabIndex = 3;
            this.operationsComboBox.SelectedIndexChanged += new System.EventHandler(this.OperationsComboBox_SelectedIndexChanged);
            // 
            // parametersLabel
            // 
            this.parametersLabel.AutoSize = true;
            this.parametersLabel.Location = new System.Drawing.Point(386, 61);
            this.parametersLabel.Name = "parametersLabel";
            this.parametersLabel.Size = new System.Drawing.Size(66, 15);
            this.parametersLabel.TabIndex = 4;
            this.parametersLabel.Text = "Parameters";
            // 
            // parametersComboBox
            // 
            this.parametersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parametersComboBox.FormattingEnabled = true;
            this.parametersComboBox.Location = new System.Drawing.Point(458, 58);
            this.parametersComboBox.Name = "parametersComboBox";
            this.parametersComboBox.Size = new System.Drawing.Size(121, 23);
            this.parametersComboBox.TabIndex = 5;
            this.parametersComboBox.SelectedIndexChanged += new System.EventHandler(this.ParametersComboBox_SelectedIndexChanged);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(386, 84);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(39, 15);
            this.resultLabel.TabIndex = 6;
            this.resultLabel.Text = "Result";
            // 
            // operationResultLabel
            // 
            this.operationResultLabel.AutoSize = true;
            this.operationResultLabel.Location = new System.Drawing.Point(458, 84);
            this.operationResultLabel.Name = "operationResultLabel";
            this.operationResultLabel.Size = new System.Drawing.Size(0, 15);
            this.operationResultLabel.TabIndex = 7;
            // 
            // formatButton
            // 
            this.formatButton.Location = new System.Drawing.Point(386, 102);
            this.formatButton.Name = "formatButton";
            this.formatButton.Size = new System.Drawing.Size(75, 23);
            this.formatButton.TabIndex = 8;
            this.formatButton.Text = "Format";
            this.formatButton.UseVisualStyleBackColor = true;
            this.formatButton.Click += new System.EventHandler(this.FormatButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.formatButton);
            this.Controls.Add(this.operationResultLabel);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.parametersComboBox);
            this.Controls.Add(this.parametersLabel);
            this.Controls.Add(this.operationsComboBox);
            this.Controls.Add(this.operationsLabel);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label operationsLabel;
        private System.Windows.Forms.ComboBox operationsComboBox;
        private System.Windows.Forms.Label parametersLabel;
        private System.Windows.Forms.ComboBox parametersComboBox;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label operationResultLabel;
        private System.Windows.Forms.Button formatButton;
    }
}

