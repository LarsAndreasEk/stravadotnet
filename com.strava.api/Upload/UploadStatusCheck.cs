using System;
using System.Timers;
using com.strava.api.Activities;
using com.strava.api.Authentication;
using com.strava.api.Client;

namespace com.strava.api.Upload
{
    /// <summary>
    /// This class is used to check the status of an upload. You can subscribe to the UploadChecked event which is raised 
    /// whenever the status was checked. You can then read the current status of the upload.
    /// </summary>
    public class UploadStatusCheck
    {
        private readonly Timer _timer;
        private CheckStatus _currentStatus;
        private readonly String _token;
        private readonly String _uploadId;

        /// <summary>
        /// Indicates whether the activity is processed.
        /// </summary>
        public bool IsFinished
        {
            get
            {
                return _currentStatus == CheckStatus.Finished;
            }
        }

        #region Events

        /// <summary>
        /// UploadChecked is raised whenever the status of an upload was checked and a response was received.
        /// </summary>
        public event EventHandler<UploadStatusCheckedEventArgs> UploadChecked;

        /// <summary>
        /// ActivityReady is raised whenever the activity was successfully uploaded to and processed by Strava.
        /// </summary>
        public event EventHandler ActivityReady;

        /// <summary>
        /// ActivityProcessing is raised whenever the activity is being processed by Strava.
        /// </summary>
        public event EventHandler ActivityProcessing;

        #endregion

        /// <summary>
        /// Initializes a new instance of the UploadStatusCheck class.
        /// </summary>
        public UploadStatusCheck(String accessToken, string uploadId)
        {
            _timer = new Timer(1000D);
            _timer.Elapsed += TimerTick;

            _token = accessToken;
            _uploadId = uploadId;
        }

        private async void TimerTick(object sender, ElapsedEventArgs e)
        {
            StaticAuthentication auth = new StaticAuthentication(_token);
            StravaClient client = new StravaClient(auth);

            UploadStatus status = await client.Uploads.CheckUploadStatusAsync(_uploadId);

            switch (status.Status)
            {
                case "Your activity is still being processed.":
                    if (UploadChecked != null)
                    {
                        UploadChecked(this, new UploadStatusCheckedEventArgs(CurrentUploadStatus.Processing));
                    }
                    if (ActivityProcessing != null)
                    {
                        ActivityProcessing(this, EventArgs.Empty);
                    }
                    break;

                case "The created activity has been deleted.":
                    if (UploadChecked != null)
                    {
                        UploadChecked(this, new UploadStatusCheckedEventArgs(CurrentUploadStatus.Deleted));
                    }
                    break;

                case "There was an error processing your activity.":
                    if (UploadChecked != null)
                    {
                        UploadChecked(this, new UploadStatusCheckedEventArgs(CurrentUploadStatus.Error));
                    }
                    break;

                case "Your activity is ready.":
                    if (UploadChecked != null)
                    {
                        UploadChecked(this, new UploadStatusCheckedEventArgs(CurrentUploadStatus.Ready));
                    }
                    if (ActivityReady != null)
                    {
                        ActivityReady(this, EventArgs.Empty);
                    }
                    Finish();
                    break;
            }
        }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        public void Start()
        {
            if (!IsFinished)
            {
                
                _timer.Start();
                _currentStatus = CheckStatus.Busy;
            }
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void Stop()
        {
            _timer.Stop();
            _currentStatus = CheckStatus.Idle;
        }

        private void Finish()
        {
            _currentStatus = CheckStatus.Finished;
            _timer.Stop();
        }
    }
}
