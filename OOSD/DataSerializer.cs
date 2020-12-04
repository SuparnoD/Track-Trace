/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 03/12/2020
 * FILE NAME: DataSerializer.cs
 * PURPOSE: Holds the logic for all operations that persist data from lists onto an external file
 * LAYER: Data
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OOSD
{
    class DataSerializer
    {
        // Serializer for data that holds information of any contacts that occured between two individuals
        public static void contactSerializer(string filePath)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
            {
                foreach (ContactRecord conRec in DataAccess.listOfContacts)
                {
                    // Properties and objects are separated by commas
                    file.WriteLine(conRec.Person.ID + "," + conRec.Person.Name + "," + conRec.Person.PhoneNumber + ","
                        + conRec.PersonTwo.ID + "," + conRec.PersonTwo.Name + "," + conRec.PersonTwo.PhoneNumber + ","
                        + conRec.Date);
                }
            }
        }

        // Serializer for data that holds information of all locations (inc. type and name)
        public static void locationSerializer(string filePath)
        {
            using (TextWriter LocTw = new StreamWriter(filePath))
            {
                XmlSerializer locationSerializer = new XmlSerializer(typeof(List<Location>));
                locationSerializer.Serialize(LocTw, DataAccess.listOfLocations);
            }

            DataAccess.listOfLocations = null;
        }

        // Serializer for data that holds information of all individuals (inc. ID, name and phone number)
        public static void personSerializer(string filePath)
        {
            using (TextWriter PerTw = new StreamWriter(filePath))
            {
                XmlSerializer peopleSerializer = new XmlSerializer(typeof(List<Person>));
                peopleSerializer.Serialize(PerTw, DataAccess.listOfPeople);
            }

            DataAccess.listOfPeople = null;
        }
    }
}
