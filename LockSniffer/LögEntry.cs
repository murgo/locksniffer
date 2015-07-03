using System;
using System.Linq;

namespace LockSniffer
{
    public class LögEntry
    {
        public DateTime Timestamp { get; set; }
        public bool Locked { get; set; }
        public string Message { get; set; }

        private const char Separator = '|';

        public string Serialize()
        {
            return string.Format("{0}{3}{1}{3}{2}{4}", Timestamp.Ticks, Locked, Message, Separator, Environment.NewLine);
        }

        public static LögEntry Deserialize(string line)
        {
            var split = line.Split(Separator);
            var date = new DateTime(long.Parse(split[0]));
            var locked = bool.Parse(split[1]);
            var msg = string.Join(Separator.ToString(), split.Skip(2));

            return new LögEntry { Timestamp = date, Locked = locked, Message = msg };
        }
    }
}
