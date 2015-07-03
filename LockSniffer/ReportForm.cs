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

            foreach (var day in _days.Where(day => day.Date >= monthCalendar1.SelectionStart && day.Date <= monthCalendar1.SelectionEnd))
            {
                var t = string.Format("Date: {0}\tDuration: {1} ({2}-{3}){4}", day.Date.ToString("D"), day.Duration, day.Start.ToString("t"), day.End.ToString("t"), Environment.NewLine);
                textBox1.Text = textBox1.Text + t;
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            Render();
        }
    }
}
