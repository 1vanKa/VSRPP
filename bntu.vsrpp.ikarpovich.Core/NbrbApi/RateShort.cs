// <copyright file="RateShort.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Bntu.Vsrpp.Ikarpovich.Core.NbrbAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// NBRB currency short rate.
    /// </summary>
    public class RateShort
    {
        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        public int Cur_ID { get; set; }

        /// <summary>
        /// Gets or sets date.
        /// </summary>
        [Key]
        public System.DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets currency rate.
        /// </summary>
        public decimal? Cur_OfficialRate { get; set; }
    }
}