using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OOSD
{
    class DataAccess
    {
        public static List<Person> listOfPeople = new List<Person>();
        public static List<Location> listOfLocations = new List<Location>();
        public static List<VisitRecord> listOfVisits = new List<VisitRecord>();
        public static List<ContactRecord> listOfContacts = new List<ContactRecord>();
    }
}
