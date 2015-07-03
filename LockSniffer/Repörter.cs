using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LockSniffer
{
    public class Repörter
    {
        public class Day
        {
            public DateTime Date { get; set; }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public string Duration { get { return ((End - Start).TotalMinutes / 60.0).ToString("F1"); } }
        }

        private static List<LögEntry> ReadLögEntries()
        {
            var path = Lögger.GetPath();
            var rows = File.ReadAllLines(path);

            return rows.Select(LögEntry.Deserialize).ToList();
        }

        public List<Day> Report()
        {
            var entries = ReadLögEntries();

            entries.Add(new LögEntry { Locked = true, Message = "Current", Timestamp = DateTime.Now });

            return entries.OrderBy(e => e.Timestamp)
                .GroupBy(e => e.Timestamp.Date)
                .Select(day => new { day, start = day.FirstOrDefault(d => !d.Locked), end = day.LastOrDefault(d => d.Locked) })
                .Where(day => day.start != null && day.end != null)
                .Select(day => new Day {Date = day.day.Key, Start = day.start.Timestamp, End = day.end.Timestamp}).ToList();
        }
    }
}
