// <copyright file="HttpServiceTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Bntu.Vsrpp.Ikarpovich.CoreTest
{
    using Bntu.Vsrpp.Ikarpovich.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test for HttpService.
    /// </summary>
    [TestClass]
    public class HttpServiceTest
    {
        /// <summary>
        /// Tests correct api call.
        /// </summary>
        [TestMethod]
        public void GetObject_CurrencyId1_ReturnsCurrency()
        {
            HttpService service = new("https://www.nbrb.by/api/exrates/currencies/1");
            Nancy.Json.JavaScriptSerializer serializer = new();
            Core.NbrbAPI.Models.Currency expected = serializer.Deserialize<Core.NbrbAPI.Models.Currency>("{\"Cur_ID\":1,\"Cur_ParentID\":1,\"Cur_Code\":\"008\",\"Cur_Abbreviation\":\"ALL\",\"Cur_Name\":\"Албанский лек\",\"Cur_Name_Bel\":\"Албанскі лек\",\"Cur_Name_Eng\":\"Albanian Lek\",\"Cur_QuotName\":\"1 Албанский лек\",\"Cur_QuotName_Bel\":\"1 Албанскі лек\",\"Cur_QuotName_Eng\":\"1 Albanian Lek\",\"Cur_NameMulti\":\"\",\"Cur_Name_BelMulti\":\"\",\"Cur_Name_EngMulti\":\"\",\"Cur_Scale\":1,\"Cur_Periodicity\":1,\"Cur_DateStart\":\"1991-01-01T00:00:00\",\"Cur_DateEnd\":\"2007-11-30T00:00:00\"}");
            Core.NbrbAPI.Models.Currency actual = service.GetObject<Core.NbrbAPI.Models.Currency>();
            Assert.AreEqual(expected.Cur_Abbreviation, actual.Cur_Abbreviation);
            Assert.AreEqual(expected.Cur_Code, actual.Cur_Code);
            Assert.AreEqual(expected.Cur_DateEnd, actual.Cur_DateEnd);
            Assert.AreEqual(expected.Cur_DateStart, actual.Cur_DateStart);
            Assert.AreEqual(expected.Cur_ID, actual.Cur_ID);
            Assert.AreEqual(expected.Cur_Name, actual.Cur_Name);
            Assert.AreEqual(expected.Cur_NameMulti, actual.Cur_NameMulti);
            Assert.AreEqual(expected.Cur_Name_Bel, actual.Cur_Name_Bel);
            Assert.AreEqual(expected.Cur_Name_BelMulti, actual.Cur_Name_BelMulti);
            Assert.AreEqual(expected.Cur_Name_Eng, actual.Cur_Name_Eng);
            Assert.AreEqual(expected.Cur_Name_EngMulti, actual.Cur_Name_EngMulti);
            Assert.AreEqual(expected.Cur_ParentID, actual.Cur_ParentID);
            Assert.AreEqual(expected.Cur_Periodicity, actual.Cur_Periodicity);
            Assert.AreEqual(expected.Cur_QuotName, actual.Cur_QuotName);
            Assert.AreEqual(expected.Cur_QuotName_Bel, actual.Cur_QuotName_Bel);
            Assert.AreEqual(expected.Cur_QuotName_Eng, actual.Cur_QuotName_Eng);
            Assert.AreEqual(expected.Cur_Scale, actual.Cur_Scale);
        }

        /// <summary>
        /// Tests incorrect api call.
        /// </summary>
        [TestMethod]
        public void GetObject_CurrencyId0_ReturnsDefault()
        {
            HttpService service = new("https://www.nbrb.by/api/exrates/currencies/0");
            Core.NbrbAPI.Models.Currency actual = service.GetObject<Core.NbrbAPI.Models.Currency>();
            Assert.IsNull(actual);
        }
    }
}
