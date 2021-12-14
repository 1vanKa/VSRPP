// <copyright file="MainForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Bntu.Vsrpp.Ikarpovich.Lab2
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Bntu.Vsrpp.Ikarpovich.Core;
    using NbrbAPI.Models;
    using OxyPlot;
    using OxyPlot.Series;

    /// <summary>
    /// Main window.
    /// </summary>
    public partial class MainForm : Form
    {
        private Rate[] rates;
        private Rate[] ratesOnDate;
        private Currency[] currencies;

        private Task task;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
            new Task(this.GetCurrencies).Start();
        }

        private void GetCurrencies()
        {
            HttpService service = new("https://www.nbrb.by/api/exrates/rates?periodicity=0");
            while ((this.rates = service.GetObject<Rate[]>()) == null)
            {
            }

            this.ratesOnDate = this.rates;
            this.currencyRateComboBox.BeginInvoke(new Action(() =>
            {
                foreach (Rate rate in this.rates)
                {
                    this.currencyRateComboBox.Items.Add(rate.Cur_Abbreviation);
                    this.currencyRatesComboBox.Items.Add(rate.Cur_Abbreviation);
                    this.convertFromComboBox.Items.Add(rate.Cur_Abbreviation);
                    this.convertToComboBox.Items.Add(rate.Cur_Abbreviation);
                }

                this.convertFromComboBox.Items.Add("BYN");
                this.convertToComboBox.Items.Add("BYN");
            }));
            service = new("https://www.nbrb.by/api/exrates/currencies");
            while ((this.currencies = service.GetObject<Currency[]>()) == null)
            {
            }
        }

        private void ShowCurrencyRateButton_Click(object sender, EventArgs e)
        {
            int currencyId;
            if (this.currencyRateComboBox.SelectedIndex == -1 || this.rates == null)
            {
                return;
            }

            lock (this.rates)
            {
                currencyId = this.rates[this.currencyRateComboBox.SelectedIndex].Cur_ID;
            }

            new Task(new Action(() =>
            {
                Rate rate = this.GetRate(currencyId);
                string labelText;
                if (rate == null)
                {
                    labelText = "Not Found";
                }
                else
                {
                    labelText = rate.Cur_Scale.ToString() + " " +
                        rate.Cur_Abbreviation + " = " + rate.Cur_OfficialRate.ToString() + " BYN";
                }

                this.currencyRateLabel.BeginInvoke(new Action(() => this.currencyRateLabel.Text = labelText));
            })).Start();
        }

        private Rate GetRate(int currencyId)
        {
            HttpService service = new("https://www.nbrb.by/api/exrates/rates/" + currencyId);
            Rate rate;
            while ((rate = service.GetObject<Rate>()) == null)
            {
            }

            return rate;
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if (this.convertFromComboBox.SelectedIndex == this.convertToComboBox.SelectedIndex)
            {
                this.convertToTextBox.Text = "Choose different options";
            }

            double convertFromValue;
            try
            {
                convertFromValue = double.Parse(this.convertFromTextBox.Text);
            }
            catch (FormatException)
            {
                this.convertToTextBox.Text = "Wrong input";
                return;
            }

            int convertFromIndex = this.convertFromComboBox.SelectedIndex;
            int convertToIndex = this.convertToComboBox.SelectedIndex;
            new Task(new Action(() =>
            {
                int scale1, scale2;
                decimal rate1, rate2;
                lock (this.rates)
                {
                    if (convertFromIndex == this.rates.Length)
                    {
                        scale1 = 1;
                        rate1 = 1;
                    }
                    else
                    {
                        Rate rate = this.GetRate(this.rates[convertFromIndex].Cur_ID);
                        if (rate == null)
                        {
                            this.AsyncSetConvertToTextBoxText("Rate Not Found");
                            return;
                        }

                        scale1 = rate.Cur_Scale;
                        rate1 = (decimal)rate.Cur_OfficialRate;
                    }

                    if (convertToIndex == this.rates.Length)
                    {
                        scale2 = 1;
                        rate2 = 1;
                    }
                    else
                    {
                        Rate rate = this.GetRate(this.rates[convertToIndex].Cur_ID);
                        if (rate == null)
                        {
                            this.AsyncSetConvertToTextBoxText("Rate Not Found");
                            return;
                        }

                        scale2 = rate.Cur_Scale;
                        rate2 = (decimal)rate.Cur_OfficialRate;
                    }
                }

                this.AsyncSetConvertToTextBoxText(
                    (decimal.Floor((decimal)convertFromValue / scale1 * rate1 * scale2 / rate2 * 10000) / 10000).ToString());
            })).Start();
        }

        private void AsyncSetConvertToTextBoxText(string text)
        {
            this.convertToTextBox.BeginInvoke(new Action(() =>
            {
                this.convertToTextBox.Text = text;
            }));
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            if (this.currencyRatesComboBox.SelectedIndex == -1)
            {
                return;
            }

            ((Button)sender).Enabled = false;
            int currencyId = this.ratesOnDate[this.currencyRatesComboBox.SelectedIndex].Cur_ID;
            DateTime startDate = this.fromDateTimePicker.Value;
            DateTime endDate = this.toDateTimePicker.Value;
            new Task(new Action(() =>
            {
                List<RateShort> rates;
                if ((rates = this.GetRates(currencyId, startDate, endDate)) == null)
                {
                    this.showButton.BeginInvoke(new Action(() => this.showButton.Enabled = true));
                    return;
                }

                decimal minRate = decimal.MaxValue;
                decimal maxRate = 0;
                decimal avgRate = 0;
                List<decimal> ratesValues = new();
                foreach (RateShort rate in rates)
                {
                    int scale = this.FindCurrencyById(this.currencies, rate.Cur_ID).Cur_Scale;
                    if (rate.Cur_OfficialRate / scale < minRate)
                    {
                        minRate = (decimal)rate.Cur_OfficialRate / scale;
                    }

                    if (rate.Cur_OfficialRate / scale > maxRate)
                    {
                        maxRate = (decimal)rate.Cur_OfficialRate / scale;
                    }

                    avgRate += (decimal)rate.Cur_OfficialRate / scale;
                    ratesValues.Add((decimal)rate.Cur_OfficialRate / scale);
                }

                avgRate /= rates.Count;
                avgRate = decimal.Floor(avgRate * 1000) / 1000;
                this.minMaxAvgCurrenciesLabel.BeginInvoke(new Action(
                    () => this.minMaxAvgCurrenciesLabel.Text = "Min rate: " + minRate.ToString()
                        + "\nMax rate: " + maxRate.ToString() + "\nAvg rate: " + avgRate.ToString()));
                this.chart.BeginInvoke(new Action(() => this.CreatePlot(ratesValues)));
                this.showButton.BeginInvoke(new Action(() => this.showButton.Enabled = true));
            })).Start();
        }

        private void CreatePlot(List<decimal> values)
        {
            PlotModel model = new PlotModel { Title = "Rates" };
            LineSeries line = new() { Title = "Rates" };
            for (int i = 0; i < values.Count; i++)
            {
                line.Points.Add(new DataPoint(i, (double)values[i]));
            }

            model.Series.Add(line);
            this.chart.Model = model;
            this.chart.Visible = true;
        }

        private List<RateShort> GetRates(int currencyId, DateTime startDate, DateTime endDate)
        {
            List<CurrencyPeriod> periods = new();
            Currency currentCurrency = this.FindCurrencyById(this.currencies, currencyId);
            while (true)
            {
                if (currentCurrency.Cur_DateEnd >= endDate)
                {
                    periods.Add(new CurrencyPeriod(currentCurrency, startDate, endDate));
                    break;
                }
                else
                {
                    periods.Add(new CurrencyPeriod(currentCurrency, startDate, currentCurrency.Cur_DateEnd));
                    currentCurrency = this.GetNextCurrency(this.currencies, currentCurrency);
                    startDate = currentCurrency.Cur_DateStart;
                }
            }

            for (int i = 0; i < periods.Count; i++)
            {
                if (periods[i].EndDate - periods[i].StartDate > TimeSpan.FromDays(365))
                {
                    periods.Insert(i + 1, new CurrencyPeriod(
                        periods[i].Currency,
                        periods[i].StartDate + TimeSpan.FromDays(365),
                        periods[i].EndDate));
                    periods[i].EndDate = periods[i].StartDate + TimeSpan.FromDays(365);
                }
            }

            List<RateShort> rates = new();
            foreach (CurrencyPeriod period in periods)
            {
                HttpService service = new("https://www.nbrb.by/api/exrates/rates/dynamics/" + period.Currency.Cur_ID
                    + "?startDate=" + period.StartDate.ToString("s")
                    + "&endDate=" + period.EndDate.ToString("s"));
                RateShort[] periodRates;
                while ((periodRates = service.GetObject<RateShort[]>()) == null)
                {
                }

                rates.AddRange(periodRates);
            }

            return rates;
        }

        private Currency GetNextCurrency(Currency[] currencies, Currency currentCurrency)
        {
            foreach (Currency currency in currencies)
            {
                if (currency.Cur_DateStart >= currentCurrency.Cur_DateEnd
                    && currentCurrency.Cur_ParentID == currency.Cur_ParentID)
                {
                    return currency;
                }
            }

            return null;
        }

        private Currency FindCurrencyById(Currency[] currencies, int id)
        {
            if (currencies == null)
            {
                return null;
            }

            foreach (Currency currency in currencies)
            {
                if (currency.Cur_ID == id)
                {
                    return currency;
                }
            }

            return null;
        }

        private void FromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            HttpService service = new("https://www.nbrb.by/api/exrates/rates?periodicity=0&ondate="
                + this.fromDateTimePicker.Value.ToString("s"));
            this.currencyRatesComboBox.Items.Clear();
            if (this.task != null)
            {
                if (!this.task.IsCompleted)
                {
                    this.task.Dispose();
                }
            }

            this.task = new Task(new Action(() =>
            {
                this.currencyRatesComboBox.BeginInvoke(new Action(() =>
                    this.currencyRatesComboBox.Items.Clear()));
                while ((this.ratesOnDate = service.GetObject<Rate[]>()) == null)
                {
                    if (this.task.IsCanceled)
                    {
                        return;
                    }
                }

                this.currencyRatesComboBox.BeginInvoke(new Action(() =>
                {
                    lock (this.ratesOnDate)
                    {
                        this.currencyRatesComboBox.Items.Clear();
                        foreach (Rate rate in this.ratesOnDate)
                        {
                            this.currencyRatesComboBox.Items.Add(rate.Cur_Abbreviation);
                        }
                    }
                }));
            }));
            this.task.Start();
        }

        private class CurrencyPeriod
        {
            public CurrencyPeriod(Currency currency, DateTime startDate, DateTime endDate)
            {
                this.Currency = currency;
                this.StartDate = startDate;
                this.EndDate = endDate;
            }

            public Currency Currency { get; }

            public DateTime StartDate { get; set; }

            public DateTime EndDate { get; set; }
        }
    }
}
