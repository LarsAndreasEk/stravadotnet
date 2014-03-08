namespace com.strava.api.Athletes
{
    /// <summary>
    /// Use this enum to specifiy which parameter of an athlete you want to update.
    /// </summary>
    public enum AthleteParameter
    {
        /// <summary>
        /// Update the city.
        /// </summary>
        City,
        /// <summary>
        /// Update the state.
        /// </summary>
        State,
        /// <summary>
        /// Update the country.
        /// </summary>
        Country,
        /// <summary>
        /// Update the athlete's wheight.
        /// </summary>
        Weight
    }
}