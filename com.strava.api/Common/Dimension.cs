namespace com.strava.api.Common
{
    /// <summary>
    /// Contains information about a width x height box.
    /// </summary>
    public class Dimension
    {
        /// <summary>
        /// The dimension's width.
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// The dimension's height.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Initializes a new instance of the Dimension class.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Dimension(int width, int height)
        {
            Height = height;
            Width = width;
        }
    }
}
