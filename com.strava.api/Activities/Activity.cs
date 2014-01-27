using System;
using System.Collections.Generic;
using com.strava.api.Athletes;
using com.strava.api.Common;
using com.strava.api.Gear;
using com.strava.api.Segments;

namespace com.strava.api.Activities
{
    public class Activity
    {
        public String Id { get; set; }
        public ResourceState ResourceState { get; set; }
        public String ExternalId { get; set; }

        public Athlete Athlete { get; set; }
        public String Name { get; set; }

        public float Distance { get; set; }

        public int MovingTime { get; set; }
        public int ElapsedTime { get; set; }

        public float ElevationGain { get; set; }

        public ActivityType ActivityType { get; set; }

        public String StartDate { get; set; }
        public String StartDateLocal { get; set; }
        public String TimeZone { get; set; }

        public Coordinate StartPoint { get; set; }
        public Coordinate EndPoint { get; set; }
        
        public String City { get; set; }
        public String State { get; set; }
        public String Country { get; set; }

        public int AchievementCount { get; set; }
        public int KudosCount { get; set; }
        public int CommentCount { get; set; }
        public int AtheleteCount { get; set; }
        public int PhotoCount { get; set; }

        public Map Map { get; set; }

        public bool IsTrainer { get; set; }
        public bool IsCommute { get; set; }
        public bool IsManual { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsFlagged { get; set; }

        public String GearId { get; set; }

        public IGear Gear { get; set; }

        public float AverageSpeed { get; set; }
        public float MaxSpeed { get; set; }

        public int AverageCadence { get; set; }

        public int AverageTemperature { get; set; }

        public int AveragePower { get; set; }

        public int Kilojoules { get; set; }

        public int AverageHeartrate { get; set; }
        public int MaxHeartrate { get; set; }

        public int Calories { get; set; }

        public int Truncated { get; set; }

        public bool HasKudoed { get; set; }

        public List<SegmentEffort> SegmentEfforts { get; set; }

        /*
         * splits_metric: 	array of metric split summaries
         *  running activities only
         * splits_standard: 	array of standard split summaries
         *  running activities only
         * best_efforts: 	array of best effort summaries
         *  running activities only
        */
    }
}
