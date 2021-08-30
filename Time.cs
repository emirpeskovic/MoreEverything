namespace MoreEverything
{
    public class Time
    {
        // TODO: Add more time periods
        public enum TimePeriod
        {
            Hours,
            Days
        }

        private double milliseconds = 0;

        private double hours;
        public double Hours
        {
            get => hours;
            private set => hours = value;
        }

        private double days;
        public double Days
        {
            get => days;
            private set => days = value;
        }
        

        public Time(TimePeriod period, double time) => SetTime(period, time);

        /// <summary>
        /// Returns the same Time object after setting new values to variables
        /// </summary>
        /// <param name="period">Chooses time period, e.g.: Hours</param>
        /// <param name="time">Initial time in specified time period</param>
        /// <returns>Time</returns>
        public Time SetTime(TimePeriod period, double time)
        {
            // TODO: Update with more time periods
            switch (period)
            {
                case TimePeriod.Hours:
                    milliseconds = time * (3.6 * 1000000);
                    Hours = time;
                    Days = Hours / 24;
                    break;
                case TimePeriod.Days:
                    Days = time;
                    Hours = (time / 24);
                    milliseconds = Hours * (3.6 * 1000000);
                    break;
                default:
                    break;

            }
            return this;
        }
    }
}