using System;

namespace com.strava.api.Api
{
    public static class Limits
    {
        public static event EventHandler<UsageChangedEventArgs> UsageChanged;

        private static Usage _usage;
        private static Limit _limit;
        
        public static Usage Usage
        {
            get
            {
                if (_usage == null)
                {
                    _usage = new Usage(0, 0);
                }

                return _usage;
            }
            set
            {
                _usage = value;

                if (UsageChanged != null)
                {
                    UsageChanged(null, new UsageChangedEventArgs(value.ShortTerm, value.LongTerm));
                }
            }
        }

        public static Limit Limit
        {
            get
            {
                if (_limit == null)
                {
                    _limit = new Limit(0, 0);
                }

                return _limit;
            }
            set
            {
                _limit = value;
            }
        }
    }
}
