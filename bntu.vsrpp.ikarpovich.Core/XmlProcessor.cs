// <copyright file="XmlProcessor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Bntu.Vsrpp.Ikarpovich.Core
{
    using System.Collections.Generic;
    using System.Xml;

    /// <summary>
    /// Class to process XML files.
    /// </summary>
    public class XmlProcessor
    {
        private readonly string url;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlProcessor"/> class.
        /// </summary>
        /// <param name="url">URL address of the file.</param>
        public XmlProcessor(string url)
        {
            this.url = url;
        }

        /// <summary>
        /// Formats XML file.
        /// </summary>
        public void FormatXmlFile()
        {
            XmlElement root = this.GetRootElement();
            foreach (XmlNode node in root)
            {
                node.ParseFullName();
            }

            foreach (XmlNode node in root)
            {
                node.CreateMissingParameters(root);
            }

            string path = this.url.Substring(0, this.url.LastIndexOf('.')) + "_output.xml";
            root.OwnerDocument.Save(path);
        }

        /// <summary>
        /// Gets max value from all nodes.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        /// <returns>Max value.</returns>
        public double GetMaxValue(string parameter)
        {
            XmlElement root = this.GetRootElement();
            double maxValue = double.Parse(this.GetNodeParameterValue(root.ChildNodes.Item(0), parameter));
            double value;
            foreach (XmlNode node in root)
            {
                if ((value = double.Parse(this.GetNodeParameterValue(node, parameter))) > maxValue)
                {
                    maxValue = value;
                }
            }

            return maxValue;
        }

        /// <summary>
        /// Gets min value from all nodes.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        /// <returns>Min value.</returns>
        public double GetMinValue(string parameter)
        {
            XmlElement root = this.GetRootElement();
            double minValue = double.Parse(this.GetNodeParameterValue(root.ChildNodes.Item(0), parameter));
            double value;
            foreach (XmlNode node in root)
            {
                if ((value = double.Parse(this.GetNodeParameterValue(node, parameter))) < minValue)
                {
                    minValue = value;
                }
            }

            return minValue;
        }

        /// <summary>
        /// Gets average value from all nodes.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        /// <returns>Average value.</returns>
        public double GetAvgValue(string parameter)
        {
            XmlElement root = this.GetRootElement();
            double avgValue = 0;
            foreach (XmlNode node in root)
            {
                avgValue += double.Parse(this.GetNodeParameterValue(node, parameter));
            }

            avgValue /= root.ChildNodes.Count;
            return avgValue;
        }

        /// <summary>
        /// Gets max parameter length from all nodes.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        /// <returns>Max parameter length.</returns>
        public double GetMaxLength(string parameter)
        {
            XmlElement root = this.GetRootElement();
            int maxLength = this.GetNodeParameterValue(root.ChildNodes.Item(0), parameter).Length;
            int length;
            foreach (XmlNode node in root)
            {
                if ((length = this.GetNodeParameterValue(node, parameter).Length) > maxLength)
                {
                    maxLength = length;
                }
            }

            return maxLength;
        }

        /// <summary>
        /// Gets min parameter length from all nodes.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        /// <returns>Min parameter length.</returns>
        public double GetMinLength(string parameter)
        {
            XmlElement root = this.GetRootElement();
            int minLength = this.GetNodeParameterValue(root.ChildNodes.Item(0), parameter).Length;
            int length;
            foreach (XmlNode node in root)
            {
                if ((length = this.GetNodeParameterValue(node, parameter).Length) < minLength)
                {
                    minLength = length;
                }
            }

            return minLength;
        }

        /// <summary>
        /// Gets average parameter length from all nodes.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        /// <returns>Average parameter length.</returns>
        public double GetAvgLength(string parameter)
        {
            XmlElement root = this.GetRootElement();
            double avgLength = 0;
            foreach (XmlNode node in root)
            {
                avgLength += this.GetNodeParameterValue(node, parameter).Length;
            }

            avgLength /= root.ChildNodes.Count;
            return avgLength;
        }

        /// <summary>
        /// Gets parameters which has all nodes.
        /// </summary>
        /// <param name="isNumeric">Is numeric parameter.</param>
        /// <returns>List of names.</returns>
        public List<string> GetParametersListForOperations(bool isNumeric)
        {
            List<string> stringParameters = new();
            List<XmlNode> generalParameters = this.GetGeneralParametersList();
            foreach (XmlNode node in generalParameters)
            {
                if (double.TryParse(node.InnerText, out _) == isNumeric)
                {
                    stringParameters.Add(node.Name);
                }
            }

            return stringParameters;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            string result = string.Empty;
            XmlElement xmlRoot = this.GetRootElement();
            foreach (XmlNode node in xmlRoot)
            {
                result += node.Name + "\n" + this.ParseNode(node);
            }

            return result;
        }

        private List<XmlNode> GetGeneralParametersList()
        {
            List<XmlNode> parameters = new();
            XmlElement root = this.GetRootElement();
            XmlNode firstNode = root.FirstChild;
            foreach (XmlNode node in firstNode.ChildNodes)
            {
                bool hasParameter = true;
                for (int i = 1; i < root.ChildNodes.Count; i++)
                {
                    if (!root.ChildNodes.Item(i).HasParameter(node))
                    {
                        hasParameter = false;
                        break;
                    }
                }

                if (hasParameter)
                {
                    parameters.Add(node);
                }
            }

            return parameters;
        }

        private XmlDocument ReadXml()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(this.url);
            return xmlDocument;
        }

        private XmlElement GetRootElement()
        {
            XmlDocument xmlDocument = this.ReadXml();
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            return xmlRoot;
        }

        private string GetNodeParameterValue(XmlNode node, string parameter)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (parameter == childNode.Name)
                {
                    return childNode.InnerText;
                }
            }

            return null;
        }

        private string ParseNode(XmlNode node)
        {
            string result = string.Empty;
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.HasChildNodes)
                {
                    result += "\t" + childNode.Name + '\n' + this.ParseNode(childNode) + '\n';
                }
                else
                {
                    result += "\t\t" + childNode.InnerText;
                }
            }

            return result;
        }
    }
}
