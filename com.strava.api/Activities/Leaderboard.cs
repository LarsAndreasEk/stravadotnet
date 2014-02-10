using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.strava.api.Activities
{
    public class Leaderboard
    {
        [JsonProperty("effort_count")]
        public int EffortCount { get; set; }

        [JsonProperty("entry_count")]
        public int EntryCount { get; set; }

        [JsonProperty("entries")]
        public List<LeaderboardEntry> Entries { get; set; }
    }
}
