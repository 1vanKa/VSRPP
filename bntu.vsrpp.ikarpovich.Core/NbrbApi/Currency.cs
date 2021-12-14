// <copyright file="Currency.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NbrbAPI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// NBRB currency.
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        [Key]
        public int Cur_ID { get; set; }

        /// <summary>
        /// Gets or sets parent currency id.
        /// </summary>
        public int? Cur_ParentID { get; set; }

        /// <summary>
        /// Gets or sets currency code.
        /// </summary>
        public string Cur_Code { get; set; }

        /// <summary>
        /// Gets or sets currency abbreviation.
        /// </summary>
        public string Cur_Abbreviation { get; set; }

        /// <summary>
        /// Gets or sets currency name.
        /// </summary>
        public string Cur_Name { get; set; }

        /// <summary>
        /// Gets or sets currency belarusian name.
        /// </summary>
        public string Cur_Name_Bel { get; set; }

        /// <summary>
        /// Gets or sets currency english name.
        /// </summary>
        public string Cur_Name_Eng { get; set; }

        /// <summary>
        /// Gets or sets currency quot name.
        /// </summary>
        public string Cur_QuotName { get; set; }

        /// <summary>
        /// Gets or sets currency belarusian quot name.
        /// </summary>
        public string Cur_QuotName_Bel { get; set; }

        /// <summary>
        /// Gets or sets currency english quot name.
        /// </summary>
        public string Cur_QuotName_Eng { get; set; }

        /// <summary>
        /// Gets or sets currency multi name.
        /// </summary>
        public string Cur_NameMulti { get; set; }

        /// <summary>
        /// Gets or sets currency belarusian multi name.
        /// </summary>
        public string Cur_Name_BelMulti { get; set; }

        /// <summary>
        /// Gets or sets currency english multi name.
        /// </summary>
        public string Cur_Name_EngMulti { get; set; }

        /// <summary>
        /// Gets or sets currency scale.
        /// </summary>
        public int Cur_Scale { get; set; }

        /// <summary>
        /// Gets or sets currency update periodicity.
        /// </summary>
        public int Cur_Periodicity { get; set; }

        /// <summary>
        /// Gets or sets start date.
        /// </summary>
        public DateTime Cur_DateStart { get; set; }

        /// <summary>
        /// Gets or sets end date.
        /// </summary>
        public DateTime Cur_DateEnd { get; set; }
    }
}