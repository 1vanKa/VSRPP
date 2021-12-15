// <copyright file="XmlProcessorTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Bntu.Vsrpp.Ikarpovich.CoreTest
{
    using System.IO;
    using System.Xml;
    using Bntu.Vsrpp.Ikarpovich.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test for XmlProcessor.
    /// </summary>
    [TestClass]
    public class XmlProcessorTest
    {
        /// <summary>
        /// Tests formatting.
        /// </summary>
        [TestMethod]
        public void FormatXmlFile_FIOAndMissingParametersInFile_ParseFIOAndAddMissing()
        {
            string url = "test.xml";
            XmlDocument xmlDocument = new();
            XmlElement root = xmlDocument.CreateElement("root");
            XmlElement element1 = xmlDocument.CreateElement("A");
            XmlElement element11 = xmlDocument.CreateElement("FullName");
            XmlElement element2 = xmlDocument.CreateElement("B");
            element11.InnerText = "AAA BBB CCC";
            element1.AppendChild(element11);
            root.AppendChild(element1);
            root.AppendChild(element2);
            xmlDocument.AppendChild(root);
            xmlDocument.Save(url);
            XmlProcessor processor = new(url);
            processor.FormatXmlFile();
            xmlDocument.Load(url.Substring(0, url.LastIndexOf('.')) + "_output.xml");
            string expected = "AAA";
            string actual = xmlDocument.DocumentElement.GetElementsByTagName("FirstName").Item(0).InnerText;
            File.Delete(url);
            File.Delete(url.Substring(0, url.LastIndexOf('.')) + "_output.xml");
            Assert.AreEqual(expected, actual);
            expected = "BBB";
            actual = xmlDocument.DocumentElement.GetElementsByTagName("LastName").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
            expected = "CCC";
            actual = xmlDocument.DocumentElement.GetElementsByTagName("Surname").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
            expected = "N/A";
            actual = xmlDocument.DocumentElement.GetElementsByTagName("FirstName").Item(1).InnerText;
            Assert.AreEqual(expected, actual);
            expected = "N/A";
            actual = xmlDocument.DocumentElement.GetElementsByTagName("LastName").Item(1).InnerText;
            Assert.AreEqual(expected, actual);
            expected = "N/A";
            actual = xmlDocument.DocumentElement.GetElementsByTagName("Surname").Item(1).InnerText;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests max.
        /// </summary>
        [TestMethod]
        public void GetMaxValue_TwoElementsWithSameField_Max()
        {
            string url = "test.xml";
            XmlDocument xmlDocument = new();
            XmlElement root = xmlDocument.CreateElement("root");
            XmlElement element1 = xmlDocument.CreateElement("A");
            XmlElement element11 = xmlDocument.CreateElement("a");
            XmlElement element2 = xmlDocument.CreateElement("A");
            XmlElement element21 = xmlDocument.CreateElement("a");
            element11.InnerText = "2";
            element21.InnerText = "1";
            element1.AppendChild(element11);
            element2.AppendChild(element21);
            root.AppendChild(element1);
            root.AppendChild(element2);
            xmlDocument.AppendChild(root);
            xmlDocument.Save(url);
            XmlProcessor processor = new(url);
            double actual = processor.GetMaxValue(element11.Name);
            double expected = 2;
            File.Delete(url);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests min.
        /// </summary>
        [TestMethod]
        public void GetMinValue_TwoElementsWithSameField_Min()
        {
            string url = "test.xml";
            XmlDocument xmlDocument = new();
            XmlElement root = xmlDocument.CreateElement("root");
            XmlElement element1 = xmlDocument.CreateElement("A");
            XmlElement element11 = xmlDocument.CreateElement("a");
            XmlElement element2 = xmlDocument.CreateElement("A");
            XmlElement element21 = xmlDocument.CreateElement("a");
            element11.InnerText = "2";
            element21.InnerText = "1";
            element1.AppendChild(element11);
            element2.AppendChild(element21);
            root.AppendChild(element1);
            root.AppendChild(element2);
            xmlDocument.AppendChild(root);
            xmlDocument.Save(url);
            XmlProcessor processor = new(url);
            double actual = processor.GetMinValue(element11.Name);
            double expected = 1;
            File.Delete(url);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests avg.
        /// </summary>
        [TestMethod]
        public void GetAvgValue_TwoElementsWithSameField_Avg()
        {
            string url = "test.xml";
            XmlDocument xmlDocument = new();
            XmlElement root = xmlDocument.CreateElement("root");
            XmlElement element1 = xmlDocument.CreateElement("A");
            XmlElement element11 = xmlDocument.CreateElement("a");
            XmlElement element2 = xmlDocument.CreateElement("A");
            XmlElement element21 = xmlDocument.CreateElement("a");
            element11.InnerText = "2";
            element21.InnerText = "1";
            element1.AppendChild(element11);
            element2.AppendChild(element21);
            root.AppendChild(element1);
            root.AppendChild(element2);
            xmlDocument.AppendChild(root);
            xmlDocument.Save(url);
            XmlProcessor processor = new(url);
            double actual = processor.GetMinValue(element11.Name);
            double expected = 3 / 2;
            File.Delete(url);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests max length.
        /// </summary>
        [TestMethod]
        public void GetMaxLength_TwoElementsWithSameField_Max()
        {
            string url = "test.xml";
            XmlDocument xmlDocument = new();
            XmlElement root = xmlDocument.CreateElement("root");
            XmlElement element1 = xmlDocument.CreateElement("A");
            XmlElement element11 = xmlDocument.CreateElement("a");
            XmlElement element2 = xmlDocument.CreateElement("A");
            XmlElement element21 = xmlDocument.CreateElement("a");
            element11.InnerText = "aa";
            element21.InnerText = "a";
            element1.AppendChild(element11);
            element2.AppendChild(element21);
            root.AppendChild(element1);
            root.AppendChild(element2);
            xmlDocument.AppendChild(root);
            xmlDocument.Save(url);
            XmlProcessor processor = new(url);
            double actual = processor.GetMaxLength(element11.Name);
            double expected = 2;
            File.Delete(url);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests min length.
        /// </summary>
        [TestMethod]
        public void GetMinLength_TwoElementsWithSameField_Min()
        {
            string url = "test.xml";
            XmlDocument xmlDocument = new();
            XmlElement root = xmlDocument.CreateElement("root");
            XmlElement element1 = xmlDocument.CreateElement("A");
            XmlElement element11 = xmlDocument.CreateElement("a");
            XmlElement element2 = xmlDocument.CreateElement("A");
            XmlElement element21 = xmlDocument.CreateElement("a");
            element11.InnerText = "aa";
            element21.InnerText = "a";
            element1.AppendChild(element11);
            element2.AppendChild(element21);
            root.AppendChild(element1);
            root.AppendChild(element2);
            xmlDocument.AppendChild(root);
            xmlDocument.Save(url);
            XmlProcessor processor = new(url);
            double actual = processor.GetMinLength(element11.Name);
            double expected = 1;
            File.Delete(url);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests avg length.
        /// </summary>
        [TestMethod]
        public void GetAvgLength_TwoElementsWithSameField_Avg()
        {
            string url = "test.xml";
            XmlDocument xmlDocument = new();
            XmlElement root = xmlDocument.CreateElement("root");
            XmlElement element1 = xmlDocument.CreateElement("A");
            XmlElement element11 = xmlDocument.CreateElement("a");
            XmlElement element2 = xmlDocument.CreateElement("A");
            XmlElement element21 = xmlDocument.CreateElement("a");
            element11.InnerText = "aa";
            element21.InnerText = "a";
            element1.AppendChild(element11);
            element2.AppendChild(element21);
            root.AppendChild(element1);
            root.AppendChild(element2);
            xmlDocument.AppendChild(root);
            xmlDocument.Save(url);
            XmlProcessor processor = new(url);
            double actual = processor.GetMinLength(element11.Name);
            double expected = 3 / 2;
            File.Delete(url);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests getting numeric parameters.
        /// </summary>
        [TestMethod]
        public void GetParametersListForOperations_True_NumericParameters()
        {
            string url = "test.xml";
            XmlDocument xmlDocument = new();
            XmlElement root = xmlDocument.CreateElement("root");
            XmlElement element1 = xmlDocument.CreateElement("A");
            XmlElement element11 = xmlDocument.CreateElement("a");
            XmlElement element12 = xmlDocument.CreateElement("b");
            XmlElement element2 = xmlDocument.CreateElement("A");
            XmlElement element21 = xmlDocument.CreateElement("a");
            XmlElement element22 = xmlDocument.CreateElement("b");
            element11.InnerText = "aa";
            element21.InnerText = "aaa";
            element12.InnerText = "1";
            element22.InnerText = "2";
            element1.AppendChild(element11);
            element2.AppendChild(element21);
            element1.AppendChild(element12);
            element2.AppendChild(element22);
            root.AppendChild(element1);
            root.AppendChild(element2);
            xmlDocument.AppendChild(root);
            xmlDocument.Save(url);
            XmlProcessor processor = new(url);
            System.Collections.Generic.List<string> parameters = processor.GetParametersListForOperations(true);
            string actual = parameters[0];
            string expected = "b";
            File.Delete(url);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(1, parameters.Count);
        }

        /// <summary>
        /// Tests getting string parameters.
        /// </summary>
        [TestMethod]
        public void GetParametersListForOperations_False_StringParameters()
        {
            string url = "test.xml";
            XmlDocument xmlDocument = new();
            XmlElement root = xmlDocument.CreateElement("root");
            XmlElement element1 = xmlDocument.CreateElement("A");
            XmlElement element11 = xmlDocument.CreateElement("a");
            XmlElement element12 = xmlDocument.CreateElement("b");
            XmlElement element2 = xmlDocument.CreateElement("A");
            XmlElement element21 = xmlDocument.CreateElement("a");
            XmlElement element22 = xmlDocument.CreateElement("b");
            element11.InnerText = "aa";
            element21.InnerText = "aaa";
            element12.InnerText = "1";
            element22.InnerText = "2";
            element1.AppendChild(element11);
            element2.AppendChild(element21);
            element1.AppendChild(element12);
            element2.AppendChild(element22);
            root.AppendChild(element1);
            root.AppendChild(element2);
            xmlDocument.AppendChild(root);
            xmlDocument.Save(url);
            XmlProcessor processor = new(url);
            System.Collections.Generic.List<string> parameters = processor.GetParametersListForOperations(false);
            string actual = parameters[0];
            string expected = "a";
            File.Delete(url);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(1, parameters.Count);
        }

        /// <summary>
        /// Tests getting string parameters.
        /// </summary>
        [TestMethod]
        public void GetParametersListForOperations_False_NoParameters()
        {
            string url = "test.xml";
            XmlDocument xmlDocument = new();
            XmlElement root = xmlDocument.CreateElement("root");
            XmlElement element1 = xmlDocument.CreateElement("A");
            XmlElement element11 = xmlDocument.CreateElement("a");
            XmlElement element12 = xmlDocument.CreateElement("b");
            XmlElement element2 = xmlDocument.CreateElement("A");
            XmlElement element21 = xmlDocument.CreateElement("a");
            XmlElement element22 = xmlDocument.CreateElement("b");
            element11.InnerText = "1";
            element21.InnerText = "1";
            element12.InnerText = "1";
            element22.InnerText = "2";
            element1.AppendChild(element11);
            element2.AppendChild(element21);
            element1.AppendChild(element12);
            element2.AppendChild(element22);
            root.AppendChild(element1);
            root.AppendChild(element2);
            xmlDocument.AppendChild(root);
            xmlDocument.Save(url);
            XmlProcessor processor = new(url);
            System.Collections.Generic.List<string> parameters = processor.GetParametersListForOperations(false);
            File.Delete(url);
            Assert.AreEqual(0, parameters.Count);
        }

        /// <summary>
        /// Tests getting numeric parameters.
        /// </summary>
        [TestMethod]
        public void GetParametersListForOperations_True_StringParameters()
        {
            string url = "test.xml";
            XmlDocument xmlDocument = new();
            XmlElement root = xmlDocument.CreateElement("root");
            XmlElement element1 = xmlDocument.CreateElement("A");
            XmlElement element11 = xmlDocument.CreateElement("a");
            XmlElement element12 = xmlDocument.CreateElement("b");
            XmlElement element2 = xmlDocument.CreateElement("A");
            XmlElement element21 = xmlDocument.CreateElement("a");
            XmlElement element22 = xmlDocument.CreateElement("b");
            element11.InnerText = "1";
            element21.InnerText = "2";
            element12.InnerText = "1";
            element22.InnerText = "2";
            element1.AppendChild(element11);
            element2.AppendChild(element21);
            element1.AppendChild(element12);
            element2.AppendChild(element22);
            root.AppendChild(element1);
            root.AppendChild(element2);
            xmlDocument.AppendChild(root);
            xmlDocument.Save(url);
            XmlProcessor processor = new(url);
            System.Collections.Generic.List<string> parameters = processor.GetParametersListForOperations(true);
            string actual = parameters[0];
            string expected = "a";
            File.Delete(url);
            Assert.AreEqual(expected, actual);
            actual = parameters[1];
            expected = "b";
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(2, parameters.Count);
        }
    }
}
