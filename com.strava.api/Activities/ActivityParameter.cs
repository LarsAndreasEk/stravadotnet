namespace com.strava.api.Activities
{
    /// <summary>
    /// Specifies the parameter that is being updated.
    /// </summary>
    public enum ActivityParameter
    {
        /// <summary>
        /// Updates the name of an activity. String values are allowed as parameter.
        /// </summary>
        Name,
        /// <summary>
        /// Set to true if the activity is a private one.
        /// </summary>
        Private,
        /// <summary>
        /// Indicates if the activity is a commute.
        /// </summary> 
        Commute,
        /// <summary>
        /// Indicates whether the activity was recorded on a stationary trainer.
        /// </summary>
        Trainer,
        /// <summary>
        /// Updates the gear used.
        /// </summary>
        GearId,
        /// <summary>
        /// Adds a description to an activity.
        /// </summary>
        Description
    }
}