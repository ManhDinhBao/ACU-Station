using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACUManager
{
    class Period
    {
        public Period() { }

        public Period(string dayInWeek, DateTime startTime, DateTime endTime)
        {
            DayInWeek = dayInWeek;
            StartTime = startTime;
            EndTime = endTime;
        }

        private DateTime StartTime;

        public DateTime startTime
        {
            get { return StartTime; }
            set { StartTime = value; }
        }

        private DateTime EndTime;

        public DateTime endTime
        {
            get { return EndTime; }
            set { EndTime = value; }
        }

        private string dayInWeek;

        public string DayInWeek
        {
            get { return dayInWeek; }
            set { dayInWeek = value; }
        }

    }
}
