// <copyright file="XmlNodeExtensionTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Bntu.Vsrpp.Ikarpovich.CoreTest
{
    using System.Xml;
    using Bntu.Vsrpp.Ikarpovich.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test for XmlNodeExtension.
    /// </summary>
    [TestClass]
    public class XmlNodeExtensionTest
    {
        /// <summary>
        /// Has parameter.
        /// </summary>
        [TestMethod]
        public void HasParameter_ParentHasSameTypeParameter_true()
        {
            XmlDocument xmlDocument = new();
            XmlElement element1 = xmlDocument.CreateElement("A");
            XmlElement element2 = xmlDocument.CreateElement("A");
            XmlElement element11 = xmlDocument.CreateElement("b");
            XmlElement element21 = xmlDocument.CreateElement("b");
            element11.InnerText = "aaa";
            element21.InnerText = "aaa";
            element1.AppendChild(element11);
            element2.AppendChild(element21);
            Assert.IsTrue(element1.HasParameter(
                element2.ChildNodes.Item(0)));
        }

        /// <summary>
        /// Has parameter.
        /// </summary>
        [TestMethod]
        public void HasParameter_ParentHasNotSameTypeParameter_false()
        {
            XmlDocument xmlDocument = new();
            XmlElement element1 = xmlDocument.CreateElement("A");
            XmlElement element2 = xmlDocument.CreateElement("A");
            XmlElement element11 = xmlDocument.CreateElement("b");
            XmlElement element21 = xmlDocument.CreateElement("b");
            element11.InnerText = "111";
            element21.InnerText = "aaa";
            element1.AppendChild(element11);
            element2.AppendChild(element21);
            Assert.IsFalse(element1.HasParameter(
                element2.ChildNodes.Item(0)));
        }

        /// <summary>
        /// Has not parameter.
        /// </summary>
        [TestMethod]
        public void HasParameter_ParentHasNotSameParameter_false()
        {
            XmlDocument xmlDocument = new();
            XmlElement element1 = xmlDocument.CreateElement("A");
            XmlElement element2 = xmlDocument.CreateElement("A");
            XmlElement element11 = xmlDocument.CreateElement("b");
            XmlElement element21 = xmlDocument.CreateElement("c");
            element11.InnerText = "aaa";
            element21.InnerText = "aaa";
            element1.AppendChild(element11);
            element2.AppendChild(element21);
            Assert.IsFalse(element1.HasParameter(
                element2.ChildNodes.Item(0)));
        }

        /// <summary>
        /// Has parameter.
        /// </summary>
        [TestMethod]
        public void HasParameter_ParentHasSameParameterName_true()
        {
            XmlDocument xmlDocument = new();
            XmlElement element1 = xmlDocument.CreateElement("A");
            XmlElement element2 = xmlDocument.CreateElement("A");
            XmlElement element11 = xmlDocument.CreateElement("b");
            XmlElement element21 = xmlDocument.CreateElement("b");
            element11.InnerText = "aaa";
            element21.InnerText = "aaa";
            element1.AppendChild(element11);
            element2.AppendChild(element21);
            Assert.IsTrue(element1.HasParameter(
                element2.ChildNodes.Item(0).Name));
        }

        /// <summary>
        /// Has not parameter.
        /// </summary>
        [TestMethod]
        public void HasParameter_ParentHasNotSameParameterName_false()
        {
            XmlDocument xmlDocument = new();
            XmlElement element1 = xmlDocument.CreateElement("A");
            XmlElement element2 = xmlDocument.CreateElement("A");
            XmlElement element11 = xmlDocument.CreateElement("b");
            XmlElement element21 = xmlDocument.CreateElement("c");
            element11.InnerText = "aaa";
            element21.InnerText = "aaa";
            element1.AppendChild(element11);
            element2.AppendChild(element21);
            Assert.IsFalse(element1.HasParameter(
                element2.ChildNodes.Item(0).Name));
        }

        /// <summary>
        /// Parse FullName field.
        /// </summary>
        [TestMethod]
        public void ParseFullName_FullName_ParsedNode()
        {
            XmlDocument xmlDocument = new();
            XmlElement element = xmlDocument.CreateElement("A");
            XmlElement element1 = xmlDocument.CreateElement("FullName");
            element1.InnerText = "AAA BBB CCC";
            element.AppendChild(element1);
            element.ParseFullName();
            string expected = "AAA";
            string actual = element.GetElementsByTagName("FirstName").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
            expected = "BBB";
            actual = element.GetElementsByTagName("LastName").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
            expected = "CCC";
            actual = element.GetElementsByTagName("Surname").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Parse FIO field.
        /// </summary>
        [TestMethod]
        public void ParseFullName_FIO_ParsedNode()
        {
            XmlDocument xmlDocument = new();
            XmlElement element = xmlDocument.CreateElement("A");
            XmlElement element1 = xmlDocument.CreateElement("FIO");
            element1.InnerText = "AAA BBB CCC";
            element.AppendChild(element1);
            element.ParseFullName();
            string expected = "AAA";
            string actual = element.GetElementsByTagName("FirstName").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
            expected = "BBB";
            actual = element.GetElementsByTagName("LastName").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
            expected = "CCC";
            actual = element.GetElementsByTagName("Surname").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Parse FullName field no surname.
        /// </summary>
        [TestMethod]
        public void ParseFullName_FullNameNoSurname_ParsedNode()
        {
            XmlDocument xmlDocument = new();
            XmlElement element = xmlDocument.CreateElement("A");
            XmlElement element1 = xmlDocument.CreateElement("FullName");
            element1.InnerText = "AAA BBB";
            element.AppendChild(element1);
            element.ParseFullName();
            string expected = "AAA";
            string actual = element.GetElementsByTagName("FirstName").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
            expected = "BBB";
            actual = element.GetElementsByTagName("LastName").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
            expected = "N/A";
            actual = element.GetElementsByTagName("Surname").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Parse FullName field no surname no last name.
        /// </summary>
        [TestMethod]
        public void ParseFullName_FullNameNoLastNameNoSurname_ParsedNode()
        {
            XmlDocument xmlDocument = new();
            XmlElement element = xmlDocument.CreateElement("A");
            XmlElement element1 = xmlDocument.CreateElement("FullName");
            element1.InnerText = "AAA";
            element.AppendChild(element1);
            element.ParseFullName();
            string expected = "AAA";
            string actual = element.GetElementsByTagName("FirstName").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
            expected = "N/A";
            actual = element.GetElementsByTagName("LastName").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
            expected = "N/A";
            actual = element.GetElementsByTagName("Surname").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Parse empty FullName field.
        /// </summary>
        [TestMethod]
        public void ParseFullName_FullNameEmpty_ParsedNode()
        {
            XmlDocument xmlDocument = new();
            XmlElement element = xmlDocument.CreateElement("A");
            XmlElement element1 = xmlDocument.CreateElement("FullName");
            element.AppendChild(element1);
            element.ParseFullName();
            string expected = "N/A";
            string actual = element.GetElementsByTagName("FirstName").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
            expected = "N/A";
            actual = element.GetElementsByTagName("LastName").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
            expected = "N/A";
            actual = element.GetElementsByTagName("Surname").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Try parse with no field.
        /// </summary>
        [TestMethod]
        public void ParseFullName_NoFullName_ParsedNode()
        {
            XmlDocument xmlDocument = new();
            XmlElement element = xmlDocument.CreateElement("A");
            XmlElement element1 = xmlDocument.CreateElement("AAA");
            element1.InnerText = "AAA BBB CCC";
            element.AppendChild(element1);
            element.ParseFullName();
            Assert.IsNull(element.GetElementsByTagName("FirstName").Item(0));
            Assert.IsNull(element.GetElementsByTagName("LastName").Item(0));
            Assert.IsNull(element.GetElementsByTagName("Surname").Item(0));
        }

        /// <summary>
        /// Add one missing string parameter.
        /// </summary>
        [TestMethod]
        public void CreateMissingParameters_OneMissingString_AddedNAParameter()
        {
            XmlDocument xmlDocument = new();
            XmlElement root = xmlDocument.CreateElement("A");
            XmlElement element1 = xmlDocument.CreateElement("B");
            XmlElement element12 = xmlDocument.CreateElement("C");
            XmlElement element2 = xmlDocument.CreateElement("D");
            XmlElement element21 = xmlDocument.CreateElement("E");
            element12.InnerText = "CCC";
            element21.InnerText = "EEE";
            element1.AppendChild(element12);
            element2.AppendChild(element21);
            root.AppendChild(element1);
            root.AppendChild(element2);
            element1.CreateMissingParameters(root);
            string expected = "N/A";
            string actual = element2.GetElementsByTagName("C").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Add one missing int parameter.
        /// </summary>
        [TestMethod]
        public void CreateMissingParameters_OneMissingInt_AddedZeroParameter()
        {
            XmlDocument xmlDocument = new();
            XmlElement root = xmlDocument.CreateElement("A");
            XmlElement element1 = xmlDocument.CreateElement("B");
            XmlElement element12 = xmlDocument.CreateElement("C");
            XmlElement element2 = xmlDocument.CreateElement("D");
            XmlElement element21 = xmlDocument.CreateElement("E");
            element12.InnerText = "111";
            element21.InnerText = "EEE";
            element1.AppendChild(element12);
            element2.AppendChild(element21);
            root.AppendChild(element1);
            root.AppendChild(element2);
            element1.CreateMissingParameters(root);
            string expected = "0";
            string actual = element2.GetElementsByTagName("C").Item(0).InnerText;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Add no missing parameters.
        /// </summary>
        [TestMethod]
        public void CreateMissingParameters_NoMissing_NoAdding()
        {
            XmlDocument xmlDocument = new();
            XmlElement root = xmlDocument.CreateElement("A");
            XmlElement element1 = xmlDocument.CreateElement("B");
            XmlElement element12 = xmlDocument.CreateElement("C");
            XmlElement element2 = xmlDocument.CreateElement("D");
            XmlElement element21 = xmlDocument.CreateElement("C");
            element12.InnerText = "111";
            element21.InnerText = "222";
            element1.AppendChild(element12);
            element2.AppendChild(element21);
            root.AppendChild(element1);
            root.AppendChild(element2);
            element1.CreateMissingParameters(root);
            int expected = 1;
            int actual = element2.ChildNodes.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
