using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.strava.api.Http;

namespace com.strava.api.client
{
    public class Program
    {
        public static void Main(String[] args)
        {
            GetRequest r = new GetRequest();
            r.Execute("");


            Console.ReadLine();
        }
    }
}
