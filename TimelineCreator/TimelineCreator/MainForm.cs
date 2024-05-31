using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace TimelineCreator
{
    public partial class MainForm : Form
    {
        #region Application variables
        private XmlDocument doc = new XmlDocument();
        private string ROSTER_NAME = "C:\\Users\\jgmcg\\OneDrive\\Documents\\GitHub\\TimeLine_RoadMap\\TimelineCreator\\Config\\Roster.config";
        private string TIMELINE_NAME = "C:\\Users\\jgmcg\\OneDrive\\Documents\\GitHub\\TimeLine_RoadMap\\TimelineCreator\\Config\\Timeline.config";
        private Dictionary<string, string> RosterUserInput = new Dictionary<string, string>();
        private Dictionary<string, string> TimelineUserInput = new Dictionary<string, string>();
        private List<string> TimelineDates = new List<string>();
        private Dictionary<string, List<string>> NameAndInfo = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> LocationInfo = new Dictionary<string, List<string>>();
        private Dictionary<string, List<Point>> _NameToPoint = new Dictionary<string, List<Point>>(); // find color by using the index of the name in ColorList
        private List<string> TraitList;
        private List<string> EventInfoList;
        private List<string> LocInfoList;
        private Dictionary<string, int> LocToPoints = new Dictionary<string, int>();
        private Dictionary<string, int> EventToPoints = new Dictionary<string, int>();
        public  List<Event> _Events = new List<Event>();

        //Timeline Info
        ////////////////////////////////////
        private List<Color> ColorList = new List<Color> {
            Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Violet, Color.Turquoise, Color.Beige,
            Color.Magenta, Color.Lime, Color.Maroon, Color.MediumPurple, Color.MediumSlateBlue, Color.LightSlateGray,
            Color.Wheat, Color.Teal, Color.Plum, Color.Pink, Color.Orchid, Color.OrangeRed, Color.Orange};

        private Bitmap _bitmap;
        private Graphics _graphics;
        /////////////////////////////////

        #endregion
        public MainForm()
        {
            InitializeComponent();
            TraitList = new List<string> { "Name", "Birthday", "EyeColor" };
            EventInfoList = new List<string> { "Name", "Date", "Location", "People" };
            LocInfoList = new List<string> { "Name", "Description" };
            //UpdateEnables();
            UpdateRoster();
            UpdateLocations();
        }
        private void UpdateUserInput()
        {
            RosterUserInput.Clear();
            RosterUserInput.Add(TraitList[0], txtNewPersonName.Text);
            RosterUserInput.Add(TraitList[1], txtNewPersonBirthday.Text);
            RosterUserInput.Add(TraitList[2], txtNewPersonEyeColor.Text);
            TimelineUserInput.Clear();
            TimelineUserInput.Add(EventInfoList[0], txtEventName.Text);
            TimelineUserInput.Add(EventInfoList[1], dateTimePicker.Text);
            TimelineUserInput.Add(EventInfoList[2], comboEventLocation.Text);
            TimelineUserInput.Add(EventInfoList[3], "Temp");


        }

        private void UpdateLocations()
        {

            GetConfigInfo(ROSTER_NAME, "Location");
            listLocations.Items.Clear();
            foreach (KeyValuePair<string, List<string>> location in LocationInfo)
            {
                comboEventLocation.Items.Add(location.Key);
                listLocations.Items.Add(location.Key);
            }
        }

        private void CreateTimeline()
        {
            GetConfigInfo(TIMELINE_NAME, "Event");
            _bitmap = new Bitmap(panTimeline.Size.Width, panTimeline.Height, PixelFormat.Format32bppPArgb);
            _graphics = Graphics.FromImage(_bitmap);
            SectionTimeline();
            MapPointsToName("");
            ///
            // Initialize

            Color PersonColor = Color.Red;
            Point LastUsedPoint;
            foreach (KeyValuePair<string, List<Point>> PointsPerName in _NameToPoint)
            {
                LastUsedPoint = new Point(0, 0);
                foreach (Point point in PointsPerName.Value)
                {
                    DrawDot(point, PersonColor, 10);
                    if (LastUsedPoint != new Point(0, 0))
                    {
                        ConnectDots(LastUsedPoint, point, PersonColor);
                    }
                    LastUsedPoint = point;
                }
                PersonColor = IterateColor(PersonColor); // iterates colors for each new person
            }
            //////////////////////////////////////////////////////////////////////////
        }

        private void MapPointsToName(string name)
        {
            //It seems like the best way to do this is to update the timeline document to make events
            // example/////////////////////////////////////////
            /*
            List<Point> LucyPoints = new List<Point>() { new Point(10, 20), new Point(100, 200), new Point(200, 150), new Point(300, 100) };
            List<Point> BoPoints = new List<Point>() { new Point(10, 250), new Point(100, 10), new Point(200, 400), new Point(300, 100) };
            _NameToPoint.Add("Lucy", LucyPoints);
            _NameToPoint.Add("Bo", BoPoints);
            */
            //////////////////////////////////////////////
            ///
            //Add a sorter for the dates

                //
            foreach (Event _event in _Events)
            {
                if (_event.People.Contains(name))
                {
                    if (!_NameToPoint.ContainsKey(name))
                        _NameToPoint.Add(name, new List<Point>());
                    _NameToPoint[name].Add(new Point(EventToPoints[_event.Name], LocToPoints[_event.Location]));
                    // to find the value of this point I think we have to save the grid of points when sectioning the timeline so that
                    // we can find them in the form of Dictionary<string location, int heightvalueforlocation> and Dictionary<string Event, int widthvalueforEvent>
                }
            }
            
        }

        private void UpdateEnables()
        {
            UpdateUserInput();
        }
        private void GetConfigInfo(string fileName, string category)
        {
            //because the timeline data is pulled in a different way this is necessary. Will change later
            if (fileName == TIMELINE_NAME)
            {
                if (File.Exists(TIMELINE_NAME))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Event>));

                    using (StreamReader sr = new StreamReader(TIMELINE_NAME))
                    {
                        _Events = (List<Event>)serializer.Deserialize(sr);
                    }
                }
                return;
            }
            XmlNode AppInfo;
            doc.Load(fileName);
            AppInfo = doc.SelectSingleNode("AppInfo");
            // Access the Personel node
            XmlNodeList childNodes = AppInfo.ChildNodes;
            foreach (XmlNode childNode in childNodes)
            {
                if (childNode.Name == "Person") // check if this works all in one file
                {
                    if (!NameAndInfo.ContainsKey(childNode.SelectSingleNode("Name").InnerText)) // doesn't account for adding new info to a certain name
                    {
                        NameAndInfo.Add(childNode.SelectSingleNode("Name").InnerText, new List<string>());
                        foreach (string trait in TraitList)
                        {
                            if (trait != "Name")
                                NameAndInfo[childNode.SelectSingleNode("Name").InnerText].Add(childNode.SelectSingleNode(trait).InnerText);
                        }
                    }
                }
                else if (childNode.Name == "Location")
                {
                    if (!LocationInfo.ContainsKey(childNode.SelectSingleNode("Name").InnerText)) // doesn't account for adding new info to a certain name
                    {
                        LocationInfo.Add(childNode.SelectSingleNode("Name").InnerText, new List<string>());
                        foreach (string locInfo in LocInfoList)
                        {
                            if (locInfo != "Name")
                                LocationInfo[childNode.SelectSingleNode("Name").InnerText].Add(childNode.SelectSingleNode(locInfo).InnerText);
                        }
                    }
                }
            }
        }

        private void AddToRosterConfig(string type)
        {
            doc.Load(ROSTER_NAME);
            XmlNode AppInfo = doc.SelectSingleNode("AppInfo");
            XmlElement newInfo = doc.CreateElement(type);
            if (type == "Person")
            {
                foreach (KeyValuePair<string, string> userInput in RosterUserInput)
                {
                    XmlElement newPersonInfo = doc.CreateElement(userInput.Key);
                    newPersonInfo.InnerText = userInput.Value;
                    newInfo.AppendChild(newPersonInfo);
                }
            }
            XmlNode root = doc.DocumentElement;
            root.AppendChild(newInfo);
            doc.Save(ROSTER_NAME);
        }
        private void AddNewToTimelineConfig()
        {
            // must be a better way to insert the variables below but for now this works.
            if (txtEventName.Text != "" && comboEventLocation.Text != "" && dateTimePicker.Text != "")
            {
                _Events.Add(new Event(TimelineUserInput[EventInfoList[0]], Convert.ToDateTime(TimelineUserInput[EventInfoList[1]]), TimelineUserInput[EventInfoList[2]], new List<string>()));
                SerializeTimeline();
            }
            else
            {
                MessageBox.Show("Please finish filling out the information before adding this event");
            }
        }
        private void SerializeTimeline()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Event>));
            using (StreamWriter writer = new StreamWriter(TIMELINE_NAME))
            {
                serializer.Serialize(writer, _Events);
            }
        }
        #region UI Interactables

        private void btnShowTimeline_Click(object sender, EventArgs e)
        {
            CreateTimeline();
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            GetConfigInfo(TIMELINE_NAME, "Event");
            AddNewToTimelineConfig();
            UpdateEnables();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddToRosterConfig("Person");
            UpdateRoster();
            UpdateEnables();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            UpdateEnables();
        }

        private void txtNewPersonName_TextChanged(object sender, EventArgs e)
        {
            UpdateEnables();
        }

        private void txtNewPersonBirthday_TextChanged(object sender, EventArgs e)
        {
            UpdateEnables();
        }

        private void txtNewPersonEyeColor_TextChanged(object sender, EventArgs e)
        {
            UpdateEnables();
        }

        private void txtEventName_TextChanged(object sender, EventArgs e)
        {
            UpdateEnables();
        }

        private void txtEventLocation_TextChanged(object sender, EventArgs e)
        {
            UpdateEnables();
        }

        private void txtEventTime_TextChanged(object sender, EventArgs e)
        {
            UpdateEnables();
        }

        private void listRoster_SelectedValueChanged(object sender, EventArgs e)
        {
            txtRoster.Text = "";
            for (int i = 0; i < NameAndInfo[listRoster.SelectedItem.ToString()].Count; i++)
            {
                txtRoster.Text += NameAndInfo[listRoster.SelectedItem.ToString()][i] + Environment.NewLine;
            }
            UpdateEnables();
        }
        private void comboLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //going to have to deal with locations being saved in events if we delete them here, which should eventually be a feature
            if (comboEventLocation.Text == "(+) New Location")
            {
                AddLocationForm newLocForm = new AddLocationForm();
                newLocForm.Location_Info = LocationInfo;
                if (newLocForm.ShowDialog() == DialogResult.OK)
                {

                }
            }
            UpdateEnables();
        }

#endregion

        private void UpdateRoster()
        {
            GetConfigInfo(ROSTER_NAME, "Person");
            listRoster.Items.Clear();
            foreach (KeyValuePair<string, List<string>> name in NameAndInfo)
            {
                listRoster.Items.Add(name.Key);
                comboConnectionPeople.Items.Add(name.Key);
            }
        }

        #region Timeline Creation 
        private Color IterateColor(Color color)
        {
            int colorIndex = ColorList.FindIndex(c => ColorsEqual(c, color));
            color = ColorList[colorIndex + 1];
            return color;
        }
        private void ConnectDots(Point point1, Point point2, Color dotColor, float pensize = 5)
        {

            Pen pen = new Pen(dotColor, pensize);
            _graphics.DrawLine(pen, point1, point2);
        }

        private bool ColorsEqual(Color color1, Color color2)
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
            _graphics.DrawEllipse(pen, coords.X - size / 2, coords.Y - size / 2, size, size);
            panTimeline.BackgroundImage = _bitmap;
        }


        private void SectionTimeline()
        {
            EventToPoints.Clear();
            LocToPoints.Clear();
            float width = panTimeline.Width;
            float height = panTimeline.Height;
            Point point1;
            Point point2;
            for (int i = 0; i < _Events.Count; i++)
            {
                point1 = new Point((int)(width / (_Events.Count + 1)) * (i + 1), 0);
                point2 = new Point((int)(width / (_Events.Count + 1)) * (i + 1), (int)Height);
                EventToPoints.Add(_Events[i].Name, (int)(width / (_Events.Count + 1)) * (i + 1));
                comboConnectionEvents.Items.Add(_Events[i].Name);
                ConnectDots(point1, point2, Color.Black, .1f);
            }
            for (int j = 0; j < LocationInfo.Count; j++)
            {
                point1 = new Point(0, (int)(height / (LocationInfo.Count + 1)) * (j + 1));
                point2 = new Point((int)width, (int)(height / (LocationInfo.Count + 1)) * (j + 1));
                LocToPoints.Add(LocationInfo.Keys.ElementAt(j), (int)(height / (LocationInfo.Count + 1)) * (j + 1));
                ConnectDots(point1, point2, Color.Black, .1f);
            }
        }

        #endregion

        private void btnAddPeopleToEvent_Click(object sender, EventArgs e)
        {
            if (comboConnectionPeople.Text != "" && comboConnectionEvents.Text != "")
            {
                foreach (Event _event in _Events)
                {
                    if (_event.Name == comboConnectionEvents.Text)
                    {
                        _event.People.Add(comboConnectionPeople.Text);
                    }
                }
                SerializeTimeline();
            }
            else
            {
                MessageBox.Show("Please fill out the information before adding anything");
            }
            UpdateEnables();
        }
    }

}
