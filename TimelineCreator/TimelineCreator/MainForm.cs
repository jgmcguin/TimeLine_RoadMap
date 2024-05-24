using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TimelineCreator
{
    public partial class MainForm : Form
    {
        #region Application variables
        private XmlDocument doc = new XmlDocument();
        private string ROSTER_NAME = "C:\\Users\\jgmcg\\source\\repos\\TimelineCreator\\Config\\Roster.config";
        private string TIMELINE_NAME = "C:\\Users\\jgmcg\\source\\repos\\TimelineCreator\\Config\\Timeline.config";
        private Dictionary<string, string> RosterUserInput = new Dictionary<string, string>();
        private Dictionary<string, string> TimelineUserInput = new Dictionary<string, string>();
        private Dictionary<string, List<string>> EventToPeople = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> NameAndInfo = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> EventNameAndInfo = new Dictionary<string, List<string>>();
        private List<string> TraitList;
        private List<string> EventInfoList;
        #endregion
        public MainForm()
        {
            InitializeComponent();
            TraitList = new List<string> { "Name", "Birthday", "EyeColor" };
            EventInfoList = new List<string> { "Name", "Date", "Place", "People" };
            UpdateEnables();
        }
        public void UpdateUserInput()
        {
            RosterUserInput.Clear();
            RosterUserInput.Add(TraitList[0], txtNewPersonName.Text);
            RosterUserInput.Add(TraitList[1], txtNewPersonBirthday.Text);
            RosterUserInput.Add(TraitList[2], txtNewPersonEyeColor.Text);
            TimelineUserInput.Clear();
            TimelineUserInput.Add(EventInfoList[0], txtEventName.Text);
            TimelineUserInput.Add(EventInfoList[1], txtEventTime.Text);
            TimelineUserInput.Add(EventInfoList[2], txtEventLocation.Text);
            TimelineUserInput.Add(EventInfoList[3], "Temp");
        }

        private void CreateTimeline()
        {
            using (Timeline timeline = new Timeline()) 
            {
                timeline.TimeLineInfo = GetConfigInfo(TIMELINE_NAME, "Event");
                if (timeline.ShowDialog(this) == DialogResult.OK) 
                {
                    //
                }
            }
        }
        private void CheckRoster()
        {
            using (Roster roster = new Roster())
            {
                roster.RosterList = GetConfigInfo(ROSTER_NAME, "Person");
                if (roster.ShowDialog(this) == DialogResult.OK)
                {

                }
            }
        }

        private void UpdateEnables()
        {
            UpdateUserInput();
        }

        private Dictionary<string, List<string>> GetConfigInfo(string fileName, string category)
        {
            doc.Load(fileName);
            // Access the Personel node
            XmlNode AppInfo = doc.SelectSingleNode("AppInfo");
            XmlNodeList childNodes = AppInfo.ChildNodes;
            foreach (XmlNode childNode in childNodes)
            {
                if (childNode.Name == "Person")
                {
                    NameAndInfo.Add(childNode.SelectSingleNode("Name").InnerText, new List<string>());
                    foreach(string trait in TraitList)
                    { 
                        if (trait != "Name")
                            NameAndInfo[childNode.SelectSingleNode("Name").InnerText].Add(childNode.SelectSingleNode(trait).InnerText);
                    }
                }
                else if (childNode.Name == "Location")
                {
                }
                else if (childNode.Name == "Event")
                {

                    EventNameAndInfo.Add(childNode.SelectSingleNode("Name").InnerText, new List<string>());
                    foreach (string eventInfo in EventInfoList)
                    {
                        if (eventInfo != "Name")
                            EventNameAndInfo[childNode.SelectSingleNode("Name").InnerText].Add(childNode.SelectSingleNode(eventInfo).InnerText);
                    }
                }
            }
            if (category == "Person")
                return NameAndInfo;
            else if (category == "Event")
                return EventNameAndInfo;
            else
                return null;
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
        private void AddToTimelineConfig()
        {
            doc.Load(TIMELINE_NAME);
            XmlNode AppInfo = doc.SelectSingleNode("AppInfo");
            XmlElement newInfo = doc.CreateElement("Event");
            foreach (KeyValuePair<string, string> userInput in TimelineUserInput)
            {
                XmlElement newEventInfo = doc.CreateElement(userInput.Key);
                newEventInfo.InnerText = userInput.Value;
                newInfo.AppendChild(newEventInfo);
            }
            XmlNode root = doc.DocumentElement;
            root.AppendChild(newInfo);
            doc.Save(TIMELINE_NAME);
        }

        private void btnShowTimeline_Click(object sender, EventArgs e)
        {
            CreateTimeline();
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            GetConfigInfo(TIMELINE_NAME, "Event");
            AddToTimelineConfig();
            UpdateEnables();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            GetConfigInfo(ROSTER_NAME, "Person");
            AddToRosterConfig("Person");
            UpdateEnables();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            UpdateEnables();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckRoster();
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
    }
}
