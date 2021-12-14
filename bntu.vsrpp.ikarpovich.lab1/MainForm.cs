// <copyright file="MainForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Bntu.Vsrpp.Ikarpovich.Lab1
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Bntu.Vsrpp.Ikarpovich.Core;

    /// <summary>
    /// Main window.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly List<string> operations = new List<string>()
        { "Maximum", "Minimum", "Average", "Maximum Length", "Minimum Length", "Average Length" };

        private List<string> doubleParameters;
        private List<string> stringParameters;
        private XmlProcessor xmlParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
            this.operationsComboBox.Items.AddRange(this.operations.ToArray());
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            this.xmlParser = new(openFileDialog.FileName);
            this.operationsComboBox.SelectedIndex = -1;
            this.parametersComboBox.SelectedIndex = -1;
            this.operationResultLabel.Text = string.Empty;
            this.doubleParameters = this.xmlParser.GetParametersListForOperations(true);
            this.stringParameters = this.xmlParser.GetParametersListForOperations(false);
            this.richTextBox1.Text = this.xmlParser.ToString();
        }

        private void OperationsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.operationResultLabel.Text = string.Empty;
            if (this.operationsComboBox.SelectedIndex < 3)
            {
                if (this.parametersComboBox.Items.Count != 0)
                {
                    if ((string)this.parametersComboBox.Items[0] != this.doubleParameters[0])
                    {
                        this.parametersComboBox.Items.Clear();
                        this.parametersComboBox.Items.AddRange(this.doubleParameters.ToArray());
                    }
                }
                else if (this.doubleParameters != null)
                {
                    this.parametersComboBox.Items.AddRange(this.doubleParameters.ToArray());
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (this.parametersComboBox.Items.Count != 0)
                {
                    if ((string)this.parametersComboBox.Items[0] != this.stringParameters[0])
                    {
                        this.parametersComboBox.Items.Clear();
                        this.parametersComboBox.Items.AddRange(this.stringParameters.ToArray());
                    }
                }
                else if (this.doubleParameters != null)
                {
                    this.parametersComboBox.Items.AddRange(this.doubleParameters.ToArray());
                }
                else
                {
                    return;
                }
            }

            if (this.parametersComboBox.SelectedIndex != -1)
            {
                this.ParametersComboBox_SelectedIndexChanged(null, e);
            }
        }

        private void ParametersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.operationsComboBox.SelectedIndex)
            {
                case 0:
                    this.operationResultLabel.Text = this.xmlParser.GetMaxValue((string)this.parametersComboBox.SelectedItem).ToString();
                    break;
                case 1:
                    this.operationResultLabel.Text = this.xmlParser.GetMinValue((string)this.parametersComboBox.SelectedItem).ToString();
                    break;
                case 2:
                    this.operationResultLabel.Text = this.xmlParser.GetAvgValue((string)this.parametersComboBox.SelectedItem).ToString();
                    break;
                case 3:
                    this.operationResultLabel.Text = this.xmlParser.GetMaxLength((string)this.parametersComboBox.SelectedItem).ToString();
                    break;
                case 4:
                    this.operationResultLabel.Text = this.xmlParser.GetMinLength((string)this.parametersComboBox.SelectedItem).ToString();
                    break;
                case 5:
                    this.operationResultLabel.Text = this.xmlParser.GetAvgLength((string)this.parametersComboBox.SelectedItem).ToString();
                    break;
            }
        }

        private void FormatButton_Click(object sender, EventArgs e)
        {
            this.xmlParser?.FormatXmlFile();
        }
    }
}
