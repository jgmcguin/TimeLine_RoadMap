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
        private Dictionary<string, List<Point>> _NameToPoints = new Dictionary<string, List<Point>>(); // find color by using the index of the name in ColorList
        private Dictionary<string, Color> _NameToColor = new Dictionary<string, Color>();
        private List<string> TraitList;
        private List<string> EventInfoList;
        private Dictionary<string, int> LocToPoints = new Dictionary<string, int>();
        private Dictionary<DateTime, int> DateToPoints = new Dictionary<DateTime, int>();
        public List<Location> _Locations = new List<Location>();
        public List<Person> _People = new List<Person>();
        public List<Event> _Events = new List<Event>();
        private List<Label> _Labels = new List<Label>();
        private Dictionary<DateTime, List<Event>> _DateToEvents;

        private Roster roster;// different than the way events are saved. could be a problem later

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
            UpdateEnables();
        }


        #region Updates
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
            listLocations.Items.Clear();
            comboEventLocation.Items.Clear();
            comboEventLocation.Items.Add("(+) New Location");
            foreach (Location _location in _Locations)
            {
                comboEventLocation.Items.Add(_location.Name);
                listLocations.Items.Add(_location.Name);
            }
        }

        private void UpdateRoster()
        {
            listRoster.Items.Clear();
            comboConnectionPeople.Items.Clear();
            foreach (Person person in _People)
            {
                listRoster.Items.Add(person.Name);
                comboConnectionPeople.Items.Add(person.Name);
            }
        }

        private void UpdateEvents()
        {
            listEvents.Items.Clear();
            comboConnectionEvents.Items.Clear();
            foreach (KeyValuePair<DateTime, List<Event>> _dateToEvents in _DateToEvents)
            {
                foreach (Event _event in _dateToEvents.Value)
                {
                    comboConnectionEvents.Items.Add(_event.Name);
                    if (!listEvents.Items.Contains(_event.Date.ToShortDateString()))
                        listEvents.Items.Add(_event.Date.ToShortDateString());
                }
            }
        }

        private void UpdateEnables(bool updateLoc = true, bool updateInput = true, bool updateTimeline = true, bool updateRoster = true, bool updateEvents = true)
        {
            if (updateInput)
                UpdateUserInput();
            if (updateLoc || updateRoster)
                GetConfigInfo(ROSTER_NAME);
            if (updateLoc)
                UpdateLocations();
            if (updateRoster)
                UpdateRoster();
            if (updateTimeline)
                CreateTimeline();
            if (updateEvents)
                UpdateEvents();
        }
        private void CreateTimeline()
        {
            GetConfigInfo(TIMELINE_NAME);
            _bitmap = new Bitmap(panTimeline.Size.Width, panTimeline.Height, PixelFormat.Format32bppPArgb);
            _graphics = Graphics.FromImage(_bitmap);
            SectionTimeline();
            _NameToPoints.Clear();
            foreach (Person person in _People)
            {
                MapPointsToName(person.Name);
            }

            Color PersonColor = Color.Red;
            foreach (KeyValuePair<string, List<Point>> PointsPerName in _NameToPoints)
            {
                DrawPersonPath(PointsPerName.Key, PersonColor);
                if (!_NameToColor.ContainsKey(PointsPerName.Key))
                    _NameToColor.Add(PointsPerName.Key, PersonColor);
                PersonColor = IterateColor(PersonColor); // iterates colors for each new person
            }
        }
       
        #endregion


        private void DrawPersonPath(string name, Color PersonColor)
        {
            Point LastUsedPoint = new Point(0, 0);
            foreach (Point point in _NameToPoints[name])
            {
                DrawDot(point, PersonColor, 10);
                if (LastUsedPoint != new Point(0, 0))
                {
                    ConnectDots(LastUsedPoint, point, PersonColor);
                }
                LastUsedPoint = point;
            }
        }

        private void MapPointsToName(string name)
        { 
             foreach (KeyValuePair<DateTime, List<Event>> _dateToEvents in _DateToEvents)
            {
                Point overridePoint = new Point(0, 0);
                int index = 1;
                foreach (Event _event in _dateToEvents.Value)
                {
                    if (_event.People.Contains(name))
                    {
                        if (!_NameToPoints.ContainsKey(name))
                            _NameToPoints.Add(name, new List<Point>());
                        _NameToPoints[name].Add(new Point(DateToPoints[_event.Date], LocToPoints[_event.Location]));
                        break;
                    }
                    else 
                    {
                        if (_NameToPoints.ContainsKey(name)) 
                        {

                            overridePoint = new Point(DateToPoints[_event.Date], _NameToPoints[name].Last().Y);
                            if (index == _dateToEvents.Value.Count)
                                _NameToPoints[name].Add(overridePoint); //only adds the 'didnt move locations' point if all events at the date have been checked.
                        }
                    }
                    index++;
                }
            }
            
        }

        private void GetConfigInfo(string fileName)
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
                        _Events.Sort((e1, e2) => e1.Date.CompareTo(e2.Date));
                    }
                }
                return;
            }
            else if (fileName == ROSTER_NAME)
            {
                Roster _Roster;
                if (File.Exists(ROSTER_NAME))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Roster));

                    using (StreamReader sr = new StreamReader(ROSTER_NAME))
                    {
                        _Roster = (Roster)serializer.Deserialize(sr);
                        _Locations = _Roster.Locations;
                        _People = _Roster.People;
                    }
                }
                return;
            }
        }

        private void AddToRosterConfig(string type)
        {
            if (type == "Person")
            {
                if (txtNewPersonName.Text != "" && txtNewPersonEyeColor.Text != "" && txtNewPersonBirthday.Text != "")
                    _People.Add(new Person(txtNewPersonName.Text, string.Format("{0} \r\n {1}", txtNewPersonBirthday.Text, txtNewPersonEyeColor.Text)));
                else
                    MessageBox.Show("Please finish filling out the name information before adding it.");
            }
            SerializeRoster();
        }
        
        private void SerializeRoster()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Roster));
            using (StreamWriter writer = new StreamWriter(ROSTER_NAME))
            {
                serializer.Serialize(writer, new Roster(_Locations, _People));
            }
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

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            GetConfigInfo(TIMELINE_NAME);
            AddNewToTimelineConfig();
            UpdateEnables();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddToRosterConfig("Person");
            UpdateEnables();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            UpdateEnables();
        }

        private void txtNewPersonName_TextChanged(object sender, EventArgs e)
        {
            //UpdateEnables();
        }

        private void txtNewPersonBirthday_TextChanged(object sender, EventArgs e)
        {
            //UpdateEnables();
        }

        private void txtNewPersonEyeColor_TextChanged(object sender, EventArgs e)
        {
            //UpdateEnables();
        }

        private void txtEventName_TextChanged(object sender, EventArgs e)
        {
            //UpdateEnables();
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
            foreach (Person person in _People)
            {
                if (person.Name == listRoster.SelectedItem?.ToString())
                {
                    txtRoster.Text = person.Description;
                    DrawPersonPath(person.Name, _NameToColor[person.Name]);
                }
            }
            UpdateEnables(true, true, false); // I dont know why this isnt highlighting the chosen path.
        }
        private void comboLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //going to have to deal with locations being saved in events if we delete them here, which should eventually be a feature
            if (comboEventLocation.Text == "(+) New Location")
            {
                AddLocationForm newLocForm = new AddLocationForm();
                newLocForm.Location_Info = _Locations;
                if (newLocForm.ShowDialog() == DialogResult.OK){}
                _Locations = newLocForm.Location_Info;
                AddToRosterConfig("Location");
                UpdateEnables(false);
            }
        }

        private void listLocations_SelectedValueChanged(object sender, EventArgs e)
        {
            txtRoster.Text = "";
            foreach (Location location in _Locations)
            {
                if (location.Name == listLocations.SelectedItem?.ToString())
                    txtRoster.Text = location.Description;
            }
            UpdateEnables(true, true, false);
        }
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

        private void listEvents_SelectedValueChanged(object sender, EventArgs e)
        {
            txtRoster.Text = "";
            foreach (KeyValuePair<DateTime, List<Event>> _dateToEvents in _DateToEvents)
            {
                foreach (Event _event in _dateToEvents.Value)
                {
                    if (_dateToEvents.Value.Count > 1)
                    {
                        if (_event.Date.ToShortDateString() == listEvents.SelectedItem?.ToString())
                            txtRoster.Text += string.Format("Name: {0}\r\nLocation: {1}\r\nPeople: {2}\r\n\r\n", _event.Name, _event.Location, string.Join(",", _event.People));
                    }
                    else
                    {
                        if (_event.Date.ToShortDateString() == listEvents.SelectedItem?.ToString())
                            txtRoster.Text = string.Format("Name: {0}\r\nLocation: {1}\r\nPeople: {2}", _event.Name, _event.Location, string.Join(",", _event.People));
                    }
                }
            }
            UpdateEnables(true, true, false);
        }

        #endregion

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
            DateToPoints.Clear();
            LocToPoints.Clear();
            foreach (Label label in _Labels)
            {
                this.Controls.Remove(label);
            }
            float width = panTimeline.Width;
            float height = panTimeline.Height;
            Point point1;
            Point point2;
            _DateToEvents = new Dictionary<DateTime, List<Event>>(); // maybe have to use Dictionary<DateTime EventDate, List<string> EventNames> for this one
            Dictionary<int, DateTime> dateIndexer = new Dictionary<int, DateTime>();
            int index = 0;
            //find the amount of unique dates
            foreach (Event _event in _Events)
            {
                if (!_DateToEvents.ContainsKey(_event.Date))
                {
                    _DateToEvents.Add(_event.Date, new List<Event>());// not instituted yet but this will allow us to have multiple events on one date.
                    dateIndexer.Add(index, _event.Date); //im too tired to know if this makes snese.
                    index++;
                }
                _DateToEvents[_event.Date].Add(_event);
            }
            for (int i = 0; i < _DateToEvents.Count; i++)
            {
                point1 = new Point((int)(width / (_DateToEvents.Count + 1)) * (i + 1), 0);
                point2 = new Point((int)(width / (_DateToEvents.Count + 1)) * (i + 1), (int)Height);
                DateToPoints.Add(dateIndexer[i], (int)(width / (_DateToEvents.Count + 1)) * (i + 1));
                ConnectDots(point1, point2, Color.Black, .1f);
                LabelAxis(point1, false, dateIndexer[i].ToShortDateString());
            }
            for (int j = 0; j < _Locations.Count; j++)
            {
                point1 = new Point(0, (int)(height / (_Locations.Count + 1)) * (j + 1));
                point2 = new Point((int)width, (int)(height / (_Locations.Count + 1)) * (j + 1));
                LocToPoints.Add(_Locations[j].Name, (int)(height / (_Locations.Count + 1)) * (j + 1));
                ConnectDots(point1, point2, Color.Black, .1f);
                LabelAxis(point1, true, _Locations[j].Name);
            }
        }

        private void LabelAxis(Point point, bool location, string LabelText)
        {
            Label newLabel = new Label();
            newLabel.Name = "lbl" + LabelText.Replace(' ', '_');
            newLabel.Text = LabelText;
            if (location)
                newLabel.Location = new Point(point.X + panTimeline.Location.X - 40, point.Y + panTimeline.Location.Y);
            else
                newLabel.Location = new Point(point.X + panTimeline.Location.X, point.Y + panTimeline.Location.Y - newLabel.Height);
            this.Controls.Add(newLabel);
            _Labels.Add(newLabel);
        }

        #endregion

    }

}
