using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TimelineCreator
{
    internal class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    internal class Person
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }

        
    [XmlRoot("ArrayOfEvent")]
    public class Event
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public List<string> People { get; set; }

        // Parameterless constructor required for XmlSerializer
        public Event() { }

        public Event(string name, DateTime date, string location, List<string> people)
        {
            Name = name;
            Date = date;
            Location = location;
            People = people;
        }
    }
}
