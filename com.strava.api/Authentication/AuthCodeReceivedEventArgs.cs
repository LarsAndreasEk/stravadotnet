using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.strava.api.Authentication
{
    public class AuthCodeReceivedEventArgs
    {
        public String AuthCode { get; set; }

        public AuthCodeReceivedEventArgs(string code)
        {
            AuthCode = code;
        }
    }
}
