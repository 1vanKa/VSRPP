
namespace Bntu.Vsrpp.Ikarpovich.Lab2
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
            this.currencyRateComboBox = new System.Windows.Forms.ComboBox();
            this.showCurrencyRateButton = new System.Windows.Forms.Button();
            this.currencyRateLabel = new System.Windows.Forms.Label();
            this.convertFromTextBox = new System.Windows.Forms.TextBox();
            this.convertFromLabel = new System.Windows.Forms.Label();
            this.convertFromComboBox = new System.Windows.Forms.ComboBox();
            this.convertToTextBox = new System.Windows.Forms.TextBox();
            this.convertToComboBox = new System.Windows.Forms.ComboBox();
            this.convertToLabel = new System.Windows.Forms.Label();
            this.convertButton = new System.Windows.Forms.Button();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromLabel = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.currencyRatesComboBox = new System.Windows.Forms.ComboBox();
            this.currencyLabel = new System.Windows.Forms.Label();
            this.showButton = new System.Windows.Forms.Button();
            this.minMaxAvgCurrenciesLabel = new System.Windows.Forms.Label();
            this.chart = new OxyPlot.WindowsForms.PlotView();
            this.SuspendLayout();
            // 
            // currencyRateComboBox
            // 
            this.currencyRateComboBox.FormattingEnabled = true;
            this.currencyRateComboBox.Location = new System.Drawing.Point(12, 12);
            this.currencyRateComboBox.Name = "currencyRateComboBox";
            this.currencyRateComboBox.Size = new System.Drawing.Size(121, 23);
            this.currencyRateComboBox.TabIndex = 0;
            // 
            // showCurrencyRateButton
            // 
            this.showCurrencyRateButton.Location = new System.Drawing.Point(140, 12);
            this.showCurrencyRateButton.Name = "showCurrencyRateButton";
            this.showCurrencyRateButton.Size = new System.Drawing.Size(75, 23);
            this.showCurrencyRateButton.TabIndex = 1;
            this.showCurrencyRateButton.Text = "Show Rate";
            this.showCurrencyRateButton.UseVisualStyleBackColor = true;
            this.showCurrencyRateButton.Click += new System.EventHandler(this.ShowCurrencyRateButton_Click);
            // 
            // currencyRateLabel
            // 
            this.currencyRateLabel.AutoSize = true;
            this.currencyRateLabel.Location = new System.Drawing.Point(221, 17);
            this.currencyRateLabel.Name = "currencyRateLabel";
            this.currencyRateLabel.Size = new System.Drawing.Size(0, 15);
            this.currencyRateLabel.TabIndex = 2;
            // 
            // convertFromTextBox
            // 
            this.convertFromTextBox.Location = new System.Drawing.Point(12, 56);
            this.convertFromTextBox.Name = "convertFromTextBox";
            this.convertFromTextBox.Size = new System.Drawing.Size(100, 23);
            this.convertFromTextBox.TabIndex = 3;
            // 
            // convertFromLabel
            // 
            this.convertFromLabel.AutoSize = true;
            this.convertFromLabel.Location = new System.Drawing.Point(12, 38);
            this.convertFromLabel.Name = "convertFromLabel";
            this.convertFromLabel.Size = new System.Drawing.Size(81, 15);
            this.convertFromLabel.TabIndex = 4;
            this.convertFromLabel.Text = "Convert from:";
            // 
            // convertFromComboBox
            // 
            this.convertFromComboBox.FormattingEnabled = true;
            this.convertFromComboBox.Location = new System.Drawing.Point(118, 56);
            this.convertFromComboBox.Name = "convertFromComboBox";
            this.convertFromComboBox.Size = new System.Drawing.Size(121, 23);
            this.convertFromComboBox.TabIndex = 5;
            // 
            // convertToTextBox
            // 
            this.convertToTextBox.Location = new System.Drawing.Point(372, 56);
            this.convertToTextBox.Name = "convertToTextBox";
            this.convertToTextBox.ReadOnly = true;
            this.convertToTextBox.Size = new System.Drawing.Size(100, 23);
            this.convertToTextBox.TabIndex = 7;
            // 
            // convertToComboBox
            // 
            this.convertToComboBox.FormattingEnabled = true;
            this.convertToComboBox.Location = new System.Drawing.Point(245, 56);
            this.convertToComboBox.Name = "convertToComboBox";
            this.convertToComboBox.Size = new System.Drawing.Size(121, 23);
            this.convertToComboBox.TabIndex = 6;
            // 
            // convertToLabel
            // 
            this.convertToLabel.AutoSize = true;
            this.convertToLabel.Location = new System.Drawing.Point(245, 38);
            this.convertToLabel.Name = "convertToLabel";
            this.convertToLabel.Size = new System.Drawing.Size(66, 15);
            this.convertToLabel.TabIndex = 8;
            this.convertToLabel.Text = "Convert to:";
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(478, 56);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(75, 23);
            this.convertButton.TabIndex = 9;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDateTimePicker.Location = new System.Drawing.Point(12, 100);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(200, 23);
            this.fromDateTimePicker.TabIndex = 10;
            this.fromDateTimePicker.ValueChanged += new System.EventHandler(this.FromDateTimePicker_ValueChanged);
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDateTimePicker.Location = new System.Drawing.Point(218, 100);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(200, 23);
            this.toDateTimePicker.TabIndex = 11;
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(12, 82);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(38, 15);
            this.fromLabel.TabIndex = 12;
            this.fromLabel.Text = "From:";
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(218, 82);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(22, 15);
            this.toLabel.TabIndex = 13;
            this.toLabel.Text = "To:";
            // 
            // currencyRatesComboBox
            // 
            this.currencyRatesComboBox.FormattingEnabled = true;
            this.currencyRatesComboBox.Location = new System.Drawing.Point(424, 100);
            this.currencyRatesComboBox.Name = "currencyRatesComboBox";
            this.currencyRatesComboBox.Size = new System.Drawing.Size(121, 23);
            this.currencyRatesComboBox.TabIndex = 14;
            // 
            // currencyLabel
            // 
            this.currencyLabel.AutoSize = true;
            this.currencyLabel.Location = new System.Drawing.Point(424, 82);
            this.currencyLabel.Name = "currencyLabel";
            this.currencyLabel.Size = new System.Drawing.Size(58, 15);
            this.currencyLabel.TabIndex = 15;
            this.currencyLabel.Text = "Currency:";
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(551, 100);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(75, 23);
            this.showButton.TabIndex = 16;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.ShowButton_Click);
            // 
            // minMaxAvgCurrenciesLabel
            // 
            this.minMaxAvgCurrenciesLabel.AutoSize = true;
            this.minMaxAvgCurrenciesLabel.Location = new System.Drawing.Point(12, 352);
            this.minMaxAvgCurrenciesLabel.Name = "minMaxAvgCurrenciesLabel";
            this.minMaxAvgCurrenciesLabel.Size = new System.Drawing.Size(0, 15);
            this.minMaxAvgCurrenciesLabel.TabIndex = 17;
            // 
            // chart
            // 
            this.chart.Location = new System.Drawing.Point(12, 129);
            this.chart.Name = "chart";
            this.chart.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.chart.Size = new System.Drawing.Size(614, 220);
            this.chart.TabIndex = 18;
            this.chart.Visible = false;
            this.chart.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.chart.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.chart.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 450);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.minMaxAvgCurrenciesLabel);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.currencyLabel);
            this.Controls.Add(this.currencyRatesComboBox);
            this.Controls.Add(this.toLabel);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.toDateTimePicker);
            this.Controls.Add(this.fromDateTimePicker);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.convertToLabel);
            this.Controls.Add(this.convertToComboBox);
            this.Controls.Add(this.convertToTextBox);
            this.Controls.Add(this.convertFromComboBox);
            this.Controls.Add(this.convertFromLabel);
            this.Controls.Add(this.convertFromTextBox);
            this.Controls.Add(this.currencyRateLabel);
            this.Controls.Add(this.showCurrencyRateButton);
            this.Controls.Add(this.currencyRateComboBox);
            this.Location = new System.Drawing.Point(12, 150);
            this.Name = "MainForm";
            this.Text = "Currencies Rates";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox currencyRateComboBox;
        private System.Windows.Forms.Button showCurrencyRateButton;
        private System.Windows.Forms.Label currencyRateLabel;
        private System.Windows.Forms.TextBox convertFromTextBox;
        private System.Windows.Forms.Label convertFromLabel;
        private System.Windows.Forms.ComboBox convertFromComboBox;
        private System.Windows.Forms.TextBox convertToTextBox;
        private System.Windows.Forms.ComboBox convertToComboBox;
        private System.Windows.Forms.Label convertToLabel;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.ComboBox currencyRatesComboBox;
        private System.Windows.Forms.Label currencyLabel;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Label minMaxAvgCurrenciesLabel;
        private OxyPlot.WindowsForms.PlotView chart;
    }
}

