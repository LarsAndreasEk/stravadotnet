using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using com.strava.api.Common;
using WebRequest = com.strava.api.Http.WebRequest;

namespace com.strava.api.Authentication
{
    /// <summary>
    /// This class starts a local web server. This web server is needed to receive the callback from
    /// Strava.
    /// </summary>
    public class LocalWebServer
    {
        public event EventHandler<AuthCodeReceivedEventArgs> AuthCodeReceived;
        public event EventHandler<TokenReceivedEventArgs> AccessTokenReceived;

        public String ClientId { get; set; }
        public String ClientSecret { get; set; }
        public String Code { get; set; }

        private HttpListener _httpListener = new HttpListener();
        private HttpListenerContext _context;

        public LocalWebServer(String prefix)
        {
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add(prefix);
        }

        public void Start()
        {
            _httpListener.Start();

            new Thread(ProcessRequest).Start();
        }

        public void Stop()
        {
            _httpListener.Stop();
        }

        public async void ProcessRequest()
        {
            _context = _httpListener.GetContext();
            NameValueCollection queries = _context.Request.QueryString;

            // Access Token laden
            // 0 = state
            // 1 = code
            String code = queries.GetValues(1)[0];

            if (!String.IsNullOrEmpty(code))
            {
                if (AuthCodeReceived != null)
                {
                    AuthCodeReceived(this, new AuthCodeReceivedEventArgs(code));
                }
            }

            // Save token to hard disk
            String path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StravaApi");
            String file = Path.Combine(path, "AccessToken.auth");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            FileStream stream = new FileStream(file, FileMode.OpenOrCreate);
            stream.Write(Encoding.UTF8.GetBytes(code), 0, Encoding.UTF8.GetBytes(code).Length);
            stream.Close();

            // Antwort liefen und anzeigen
            byte[] b = Encoding.UTF8.GetBytes("Access token was loaded - You can close your browser window.");
            _context.Response.ContentLength64 = b.Length;
            _context.Response.OutputStream.Write(b, 0, b.Length);
            _context.Response.OutputStream.Close();


            // Getting the Access Token
            String url = String.Format("https://www.strava.com/oauth/token?client_id={0}&client_secret={1}&code={2}", ClientId, ClientSecret, code);
            String json = await WebRequest.SendPostAsync(new Uri(url));

            AccessToken auth = Unmarshaller<AccessToken>.Unmarshal(json);

            if (!String.IsNullOrEmpty(auth.Token))
            {
                if (AccessTokenReceived != null)
                {
                    AccessTokenReceived(this, new TokenReceivedEventArgs(auth.Token));
                }
            }
        }
    }
}
