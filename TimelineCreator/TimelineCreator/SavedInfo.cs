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
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Location() { }
        public Location(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Person() { }
        public Person(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }

    [XmlRoot("AppInfo")]
    public class Roster
    {
        public List<Location> Locations { get; set; }
        public List<Person> People { get; set; }
        public Roster() { }
        public Roster(List<Location> locations, List<Person> people)
        {
            Locations = locations;
            People = people;
        }
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
