namespace MoreEverything
{

    // For lack of a better word, DistanceIndicator
    // TODO: Add more indicators
    public enum DistanceIndicator
    {
        Kilometers
    }

    public class Distance
    {
        private double distance = 0;

        private double kilometers;
        public double Kilometers
        {
            get => kilometers;
            private set => kilometers = value;
        }

        public Distance(DistanceIndicator indicator, double distance) => SetDistance(indicator, distance);
        public static bool operator <(Distance a, Distance b) => a.distance < b.distance;
        public static bool operator >(Distance a, Distance b) => a.distance > b.distance;

        /// <summary>
        /// Returns the same Distance object after setting new values to variables
        /// </summary>
        /// <param name="indicator">Chooses speed indicator*, e.g.: Kilometers</param>
        /// <param name="distance">Initial distance in specified distance indicator*</param>
        /// <returns>Distance</returns>
        public Distance SetDistance(DistanceIndicator indicator, double distance)
        {
            // TODO: Update with more distance indicators
            this.distance = distance * 1000000;
            return this;
        }
    }
}