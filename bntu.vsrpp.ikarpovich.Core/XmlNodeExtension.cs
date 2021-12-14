// <copyright file="XmlNodeExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Bntu.Vsrpp.Ikarpovich.Core
{
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Extension.
    /// </summary>
    public static class XmlNodeExtension
    {
        /// <summary>
        /// Checks if node has child with same type and name.
        /// </summary>
        /// <param name="node">Parant node.</param>
        /// <param name="parameter">Child node.</param>
        /// <returns>true if parent has child with same name and type.</returns>
        public static bool HasParameter(this XmlNode node, XmlNode parameter)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.Name == parameter.Name
                    && !(double.TryParse(childNode.InnerText, out _) ^ double.TryParse(parameter.InnerText, out _)))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if node has child with same name.
        /// </summary>
        /// <param name="node">Parant node.</param>
        /// <param name="parameter">Child node name.</param>
        /// <returns>true if parent has child with same name.</returns>
        public static bool HasParameter(this XmlNode node, string parameter)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.Name == parameter)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if node has FIO or FullName child and parses it into FirstName, LastName and Surname.
        /// </summary>
        /// <param name="node">Node.</param>
        public static void ParseFullName(this XmlNode node)
        {
            if (node.HasParameter("FIO") || node.HasParameter("FullName"))
            {
                XmlNode fullName = node.SelectSingleNode("FIO") == null
                    ? node.SelectSingleNode("FullName") : node.SelectSingleNode("FIO");
                string[] names = fullName.InnerText.Split(' ');
                if (names.Length == 0)
                {
                    names = new string[] { "N/A", "N/A", "N/A" };
                }
                else if (names.Length == 1)
                {
                    names = new string[] { names[0], "N/A", "N/A" };
                }
                else if (names.Length == 2)
                {
                    names = new string[] { names[0], names[1], "N/A" };
                }
                else if (names.Length > 3)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    for (int i = 2; i < names.Length; i++)
                    {
                        stringBuilder.Append(names[i]);
                    }

                    names = new string[] { names[0], names[1], stringBuilder.ToString() };
                }

                node.RemoveChild(fullName);
                XmlElement firstNameElement = node.OwnerDocument.CreateElement("FirstName");
                XmlElement lastNameElement = node.OwnerDocument.CreateElement("LastName");
                XmlElement surnameElement = node.OwnerDocument.CreateElement("Surname");
                firstNameElement.InnerText = names[0];
                lastNameElement.InnerText = names[1];
                surnameElement.InnerText = names[2];
                node.AppendChild(firstNameElement);
                node.AppendChild(lastNameElement);
                node.AppendChild(surnameElement);
            }
        }

        /// <summary>
        /// Adds missing parameters to all nodes of the root element.
        /// </summary>
        /// <param name="node">Node to create parameters.</param>
        /// <param name="root">Root element.</param>
        public static void CreateMissingParameters(this XmlNode node, XmlElement root)
        {
            foreach (XmlNode parameter in node.ChildNodes)
            {
                foreach (XmlNode node2 in root)
                {
                    if (!node2.HasParameter(parameter.Name))
                    {
                        XmlElement newElement = root.OwnerDocument.CreateElement(parameter.Name);
                        if (double.TryParse(parameter.InnerText, out _))
                        {
                            newElement.InnerText = "0";
                        }
                        else
                        {
                            newElement.InnerText = "N/A";
                        }

                        node2.AppendChild(newElement);
                    }
                }
            }
        }
    }
}
