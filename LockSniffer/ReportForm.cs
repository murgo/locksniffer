using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LockSniffer
{
    public partial class ReportForm : Form
    {
        private readonly List<Repörter.Day> _days;

        public ReportForm(Repörter repörter)
        {
            InitializeComponent();

            _days = repörter.Report();
            monthCalendar1.BoldedDates = _days.Select(d => d.Date).ToArray();
            Render();
        }

        private void Render()
        {
            textBox1.Clear();

            foreach (
                var day in
                _days.Where(day => day.Date >= monthCalendar1.SelectionStart && day.Date <= monthCalendar1.SelectionEnd)
            )
            {
                decimal worktime = 0;
                decimal lunch = 0;
                var overtime = decimal.Parse(day.Duration) -
                               (decimal.TryParse(textBox_worktime.Text, out worktime) ? worktime : 0) -
                               (decimal.TryParse(textBox_lunch.Text, out lunch) ? lunch : 0);
                var t =
                    string.Format(
                        "Date: {0}\tDuration: {1} ({2}-{3}) Lunch: {4} Overtime: {5}, Accual working time: {6}{7}",
                        day.Date.ToString("D"), day.Duration, day.Start.ToString("t"), day.End.ToString("t"), lunch,
                        overtime, decimal.Parse(day.Duration) - lunch, Environment.NewLine);
                textBox1.Text = textBox1.Text + t;
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            Render();
        }

        private void UpdateList(object sender, KeyEventArgs e)
        {
            Render();
        }
    }
}
