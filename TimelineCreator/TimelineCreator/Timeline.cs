using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Collections;
using System.Diagnostics;

namespace TimelineCreator
{
    public partial class Timeline : Form
    {
        // Info needed for the timeline: List of (Time, Location, Person)
        public Dictionary<string, List<string>> TimeLineInfo
        {
            get; set;
        }

        private List<Color> ColorList = new List<Color> { 
            Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Violet, Color.Turquoise, Color.Beige,
            Color.Magenta, Color.Lime, Color.Maroon, Color.MediumPurple, Color.MediumSlateBlue, Color.LightSlateGray,
            Color.Wheat, Color.Teal, Color.Plum, Color.Pink, Color.Orchid, Color.OrangeRed, Color.Orange};

        private Bitmap _bitmap;
        private Graphics _graphics;
        public Dictionary<string, List<Point>> _NameToPoint = new Dictionary<string, List<Point>>();
        public Timeline()
        {
            InitializeComponent();
            _bitmap = new Bitmap(panTimeline.Size.Width, panTimeline.Height, PixelFormat.Format32bppPArgb);
            _graphics = Graphics.FromImage(_bitmap);
            // example/////////////////////////////////////////
            List<Point> LucyPoints = new List<Point>() { new Point(10, 20), new Point(100, 200), new Point(200, 150), new Point(300, 100) };
            List<Point> BoPoints = new List<Point>() { new Point(10, 250), new Point(100, 10), new Point(200, 400), new Point(300, 100) };
            _NameToPoint.Add("Lucy", LucyPoints);
            _NameToPoint.Add("Bo", BoPoints);
            //////////////////////////////////////////////
        }

        private void Timeline_Load(object sender, EventArgs e)
        {
            Color PersonColor = Color.Red;
            Point LastUsedPoint = new Point (0,0);
            foreach(KeyValuePair<string, List<Point>> PointsPerName in _NameToPoint)
            {
                LastUsedPoint = new Point(0, 0);
                foreach (Point point in PointsPerName.Value)
                {
                    DrawDot(point, PersonColor, 10);
                    if (LastUsedPoint != new Point(0,0))
                    {
                        ConnectDots(LastUsedPoint, point, PersonColor);
                    }
                    LastUsedPoint = point;
                }
                PersonColor = IterateColor(PersonColor); // iterates colors for each new person
            }
        }

        private Color IterateColor(Color color)
        {
            int colorIndex = ColorList.FindIndex(c => ColorsEqual(c, color));
            color = ColorList[colorIndex + 1];
            return color;
        }
        private void ConnectDots(Point point1, Point point2, Color dotColor)
        {

            Pen pen = new Pen(dotColor, 5);
            _graphics.DrawLine(pen, point1, point2);
        }

        private bool ColorsEqual (Color color1, Color color2)
        {
            return color1 == color2;
        }

        private void DrawDot(Point coords, Color dotColor, int size = 5)
        {
            // add option for a bigger size for each person there so I can see who is part of the gathering
            // Create a new Bitmap

            // Create a Pen class instance
            Pen pen = new Pen(dotColor, 7);

            // Draw the circle
            _graphics.DrawEllipse(pen, coords.X - size/2, coords.Y - size/2, size, size);
            panTimeline.BackgroundImage = _bitmap;
        }
    }
}
