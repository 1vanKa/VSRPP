using System;
using System.Xml;

namespace bntu.vsrpp.ikarpovich.Core
{
    public class XmlParser
    {
        private readonly String url;
        public XmlParser(String url)
        {
            this.url = url;
        }

        public void getNodes()
        {
            XmlDocument xmlDocument = ReadXml();
        }

        private XmlDocument ReadXml()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(url);
            return xmlDocument;
        }

        private XmlElement GetRootElement()
        {
            XmlDocument xmlDocument = ReadXml();
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            return xmlRoot;
        }

        private String ParseNode(XmlNode node)
        {
            String result = "";
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.HasChildNodes)
                {
                    result += "\t" + childNode.Name + '\n' + ParseNode(childNode) + '\n';
                }
                else
                {
                    result += "\t\t" + childNode.InnerText;
                }
            }
            return result;
        }

        override public String ToString()
        {
            String result = "";
            XmlElement xmlRoot = GetRootElement();
            foreach (XmlNode node in xmlRoot)
            {
                result += node.Name + "\n" + ParseNode(node);
            }
            return result;
        }
    }
}
