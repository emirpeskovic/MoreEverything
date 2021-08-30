namespace MoreEverything
{
    public class Time
    {
        // TODO: Add more time periods
        public enum TimePeriod
        {
            Hours,
        }

        private double milliseconds = 0;

        private double hours;
        public double Hours
        {
            get => hours;
            private set => hours = value;
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
            milliseconds = time * (3.6 * 1000000);
            Hours = time;
            return this;
        }
    }
}