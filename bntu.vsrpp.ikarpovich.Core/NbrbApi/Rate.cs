// <copyright file="Rate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NbrbAPI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// NBRB currency rate.
    /// </summary>
    public class Rate
    {
        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        [Key]
        public int Cur_ID { get; set; }

        /// <summary>
        /// Gets or sets date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets currency abbreviation.
        /// </summary>
        public string Cur_Abbreviation { get; set; }

        /// <summary>
        /// Gets or sets currency scale.
        /// </summary>
        public int Cur_Scale { get; set; }

        /// <summary>
        /// Gets or sets currency name.
        /// </summary>
        public string Cur_Name { get; set; }

        /// <summary>
        /// Gets or sets currency official rate.
        /// </summary>
        public decimal? Cur_OfficialRate { get; set; }
    }
}