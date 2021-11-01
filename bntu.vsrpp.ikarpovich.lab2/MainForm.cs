using bntu.vsrpp.ikarpovich.Core;
using NbrbAPI.Models;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bntu.vsrpp.ikarpovich.lab2
{
    public partial class MainForm : Form
    {
        private Rate[] rates;
        private Rate[] ratesOnDate;
        private Currency[] currencies;

        private Task task;

        public MainForm()
        {
            InitializeComponent();
            new Task(getCurrencies).Start();

        }

        private void getCurrencies()
        {
            HttpService service = new("https://www.nbrb.by/api/exrates/rates?periodicity=0");
            while ((rates = service.getObject<Rate[]>()) == null) ;
            ratesOnDate = rates;
            currencyRateComboBox.BeginInvoke(new Action(() =>
            {
                foreach (Rate rate in rates)
                {
                    currencyRateComboBox.Items.Add(rate.Cur_Abbreviation);
                    currencyRatesComboBox.Items.Add(rate.Cur_Abbreviation);
                    convertFromComboBox.Items.Add(rate.Cur_Abbreviation);
                    convertToComboBox.Items.Add(rate.Cur_Abbreviation);
                }
                convertFromComboBox.Items.Add("BYN");
                convertToComboBox.Items.Add("BYN");
            }));
            service = new("https://www.nbrb.by/api/exrates/currencies");
            while ((currencies = service.getObject<Currency[]>()) == null) ;
        }

        private void showCurrencyRateButton_Click(object sender, EventArgs e)
        {
            int currencyId;
            if (currencyRateComboBox.SelectedIndex == -1 || rates == null) return;
            lock (rates)
                currencyId = rates[currencyRateComboBox.SelectedIndex].Cur_ID;
            new Task(new Action(() =>
            {
                Rate rate = getRate(currencyId);
                String labelText;
                if (rate == null) labelText = "Not Found";
                else labelText = rate.Cur_Scale.ToString() + " " +
                    rate.Cur_Abbreviation + " = " + rate.Cur_OfficialRate.ToString() + " BYN";
                currencyRateLabel.BeginInvoke(new Action(() => currencyRateLabel.Text = labelText));
            })).Start();
        }

        private Rate getRate(int currencyId)
        {
            HttpService service = new("https://www.nbrb.by/api/exrates/rates/" + currencyId);
            Rate rate;
            while ((rate = service.getObject<Rate>()) == null) ;
            return rate;
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            if (convertFromComboBox.SelectedIndex == convertToComboBox.SelectedIndex)
            {
                convertToTextBox.Text = "Choose different options";
            }
            double convertFromValue;
            try
            {
                convertFromValue = Double.Parse(convertFromTextBox.Text);
            }
            catch (FormatException)
            {
                convertToTextBox.Text = "Wrong input";
                return;
            }
            int convertFromIndex = convertFromComboBox.SelectedIndex;
            int convertToIndex = convertToComboBox.SelectedIndex;
            new Task(new Action(() =>
            {
                int scale1, scale2;
                decimal rate1, rate2;
                lock (rates)
                {
                    if (convertFromIndex == rates.Length)
                    {
                        scale1 = 1;
                        rate1 = 1;
                    }
                    else
                    {
                        Rate rate = getRate(rates[convertFromIndex].Cur_ID);
                        if (rate == null)
                        {
                            asyncSetConvertToTextBoxText("Rate Not Found");
                            return;
                        }
                        scale1 = rate.Cur_Scale;
                        rate1 = (decimal)rate.Cur_OfficialRate;
                    }
                    if (convertToIndex == rates.Length)
                    {
                        scale2 = 1;
                        rate2 = 1;
                    }
                    else
                    {
                        Rate rate = getRate(rates[convertToIndex].Cur_ID);
                        if (rate == null)
                        {
                            asyncSetConvertToTextBoxText("Rate Not Found");
                            return;
                        }
                        scale2 = rate.Cur_Scale;
                        rate2 = (decimal)rate.Cur_OfficialRate;
                    }
                }
                asyncSetConvertToTextBoxText(
                    (decimal.Floor((decimal)convertFromValue / scale1 * rate1 * scale2 / rate2 * 10000) / 10000).ToString());
            })).Start();
        }

        private void asyncSetConvertToTextBoxText(String text)
        {
            convertToTextBox.BeginInvoke(new Action(() =>
            {
                convertToTextBox.Text = text;
            }));
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            if (currencyRatesComboBox.SelectedIndex == -1) return;
            ((Button)sender).Enabled = false;
            int currencyId = ratesOnDate[currencyRatesComboBox.SelectedIndex].Cur_ID;
            DateTime startDate = fromDateTimePicker.Value;
            DateTime endDate = toDateTimePicker.Value;
            new Task(new Action(() =>
            {
                List<RateShort> rates;
                if ((rates = getRates(currencyId, startDate, endDate)) == null)
                {
                    showButton.BeginInvoke(new Action(() => showButton.Enabled = true));
                    return;
                }
                decimal minRate = decimal.MaxValue;
                decimal maxRate = 0;
                decimal avgRate = 0;
                List<decimal> ratesValues = new();
                foreach (RateShort rate in rates)
                {
                    int scale = findCurrencyById(currencies, rate.Cur_ID).Cur_Scale;
                    if (rate.Cur_OfficialRate / scale < minRate)
                        minRate = (decimal)rate.Cur_OfficialRate / scale;
                    if (rate.Cur_OfficialRate / scale > maxRate)
                        maxRate = (decimal)rate.Cur_OfficialRate / scale;
                    avgRate += (decimal)rate.Cur_OfficialRate / scale;
                    ratesValues.Add((decimal)rate.Cur_OfficialRate / scale);
                }
                avgRate /= rates.Count;
                avgRate = decimal.Floor(avgRate * 1000) / 1000;
                minMaxAvgCurrenciesLabel.BeginInvoke(new Action(
                    () => minMaxAvgCurrenciesLabel.Text = "Min rate: " + minRate.ToString()
                        + "\nMax rate: " + maxRate.ToString() + "\nAvg rate: " + avgRate.ToString()));
                chart.BeginInvoke(new Action(() => createPlot(ratesValues)));
                showButton.BeginInvoke(new Action(() => showButton.Enabled = true));
            })).Start();
        }

        private void createPlot(List<decimal> values)
        {
            PlotModel model = new PlotModel { Title = "Rates" };
            LineSeries line = new() { Title = "Rates" };
            for (int i = 0; i < values.Count; i++)
            {
                line.Points.Add(new DataPoint(i, (double)values[i]));
            }
            model.Series.Add(line);
            chart.Model = model;
            chart.Visible = true;
        }

        private List<RateShort> getRates(int currencyId, DateTime startDate, DateTime endDate)
        {
            List<CurrencyPeriod> periods = new();
            Currency currentCurrency = findCurrencyById(currencies, currencyId);
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
                    currentCurrency = getNextCurrency(currencies, currentCurrency);
                    startDate = currentCurrency.Cur_DateStart;
                }
            }
            for (int i = 0; i < periods.Count; i++)
            {
                if (periods[i].endDate - periods[i].startDate > TimeSpan.FromDays(365))
                {
                    periods.Insert(i + 1, new CurrencyPeriod(periods[i].currency,
                        periods[i].startDate + TimeSpan.FromDays(365), periods[i].endDate));
                    periods[i].endDate = periods[i].startDate + TimeSpan.FromDays(365);
                }
            }
            List<RateShort> rates = new();
            foreach (CurrencyPeriod period in periods)
            {
                HttpService service = new("https://www.nbrb.by/api/exrates/rates/dynamics/" + period.currency.Cur_ID
                    + "?startDate=" + period.startDate.ToString("s")
                    + "&endDate=" + period.endDate.ToString("s"));
                RateShort[] periodRates;
                while ((periodRates = service.getObject<RateShort[]>()) == null) ;
                rates.AddRange(periodRates);
            }
            return rates;
        }

        private Currency getNextCurrency(Currency[] currencies, Currency currentCurrency)
        {
            foreach (Currency currency in currencies)
            {
                if (currency.Cur_DateStart >= currentCurrency.Cur_DateEnd
                    && currentCurrency.Cur_ParentID == currency.Cur_ParentID)
                    return currency;
            }
            return null;
        }

        private Currency findCurrencyById(Currency[] currencies, int id)
        {
            if (currencies == null) return null;
            foreach (Currency currency in currencies)
                if (currency.Cur_ID == id)
                    return currency;
            return null;
        }

        private void fromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            HttpService service = new("https://www.nbrb.by/api/exrates/rates?periodicity=0&ondate="
                + fromDateTimePicker.Value.ToString("s"));
            currencyRatesComboBox.Items.Clear();
            if (task != null)
                if (!task.IsCompleted)
                    task.Dispose();
            task = new Task(new Action(() =>
            {
                currencyRatesComboBox.BeginInvoke(new Action(() =>
                    currencyRatesComboBox.Items.Clear()));
                while ((ratesOnDate = service.getObject<Rate[]>()) == null) if (task.IsCanceled) return;
                currencyRatesComboBox.BeginInvoke(new Action(() =>
                {
                    lock (ratesOnDate)
                    {
                        currencyRatesComboBox.Items.Clear();
                        foreach (Rate rate in ratesOnDate)
                            currencyRatesComboBox.Items.Add(rate.Cur_Abbreviation);
                    }
                }));
            })); task.Start();
        }

        private class CurrencyPeriod
        {
            public readonly Currency currency;
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }

            public CurrencyPeriod(Currency currency, DateTime startDate, DateTime endDate)
            {
                this.currency = currency;
                this.startDate = startDate;
                this.endDate = endDate;
            }
        }
    }
}
