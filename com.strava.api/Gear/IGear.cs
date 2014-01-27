using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace com.strava.api.Gear
{
    public interface IGear
    {
        String Brand { get; set;}
        String Model { get; set; }
        int Id { get; set; }
        bool IsPrimary { get; set; }
        String Name { get; set; }
        float Distance { get; set; }
        String Description { get; set; }
    }
}
