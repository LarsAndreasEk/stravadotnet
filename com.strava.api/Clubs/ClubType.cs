namespace com.strava.api.Clubs
{
    /// <summary>
    /// This enum is used by the Club class and represents the type of a club.
    /// </summary>
    public enum ClubType
    {
        /// <summary>
        /// The club is a casual club.
        /// </summary>
        Casual,
        /// <summary>
        /// The club is a racing team.
        /// </summary>
        RacingTeam,
        /// <summary>
        /// The club is owned by a shop.
        /// </summary>
        Shop,
        /// <summary>
        /// The club's members are all riding for a company.
        /// </summary>
        Company,
        /// <summary>
        /// Other club.
        /// </summary>
        Other
    }
}