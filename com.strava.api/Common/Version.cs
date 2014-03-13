using System;
using System.Reflection;

namespace com.strava.api.Common
{
    /// <summary>
    /// Contains information about the framework.
    /// </summary>
    public static class Framework
    {
        /// <summary>
        /// Contains information about the version of the framework.
        /// </summary>
        public static Version Version
        {
            get
            {
                return new Version(
                    Assembly.GetExecutingAssembly().GetName().Version.Major,
                    Assembly.GetExecutingAssembly().GetName().Version.Minor,
                    Assembly.GetExecutingAssembly().GetName().Version.Build);
            }
        }
    }
}
