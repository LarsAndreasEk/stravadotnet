using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace com.strava.api.Http
{
    public class ImageLoader
    {
        public async static Task<Image> LoadImage(Uri uri)
        {
            HttpClient client = new HttpClient();
            Stream stream =  await client.GetStreamAsync(uri);

            Image image = new Bitmap(stream);

            return image;
        }
    }
}
