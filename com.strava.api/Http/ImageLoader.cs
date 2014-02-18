using System;
using System.Diagnostics;
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
            if (uri == null)
            {
                throw new ArgumentException("The uri object must not be null.");
            }

            try
            {
                HttpClient client = new HttpClient();
                Stream stream = await client.GetStreamAsync(uri);
                Image image = new Bitmap(stream);
                return image;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Couldn't load the image: {0}", ex.Message);
            }

            return null;
        }
    }
}
