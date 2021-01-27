/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 09/12/2020
 * FILE NAME: DataDeserializer.cs
 * PURPOSE: Holds the logic for all operations that read data from an external file. The data is used to construct objects.
 * LAYER: Data Access
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
    class DataDeserializer
    {
        // Deserializer for data that holds information of all individuals (inc. ID and phone number)
        public static void peopleDeserializer(string filePath)
        {
            XmlSerializer peopleDes = new XmlSerializer(typeof(List<Person>));
            // If the specified file path exists, continue with the operation, else create the file in the intended directory and then continue the operation
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            else
            {
                using (FileStream perFS = File.OpenRead(filePath))
                {
                    // Any data that is found in the external file, is stored in the list listOfPeople (ref. DataAccess.cs)
                    DataAccess.listOfPeople = (List<Person>)peopleDes.Deserialize(perFS);
                }
            }
        }

        // Deserializer for data that holds information of all locations (inc. type and name)
        public static void locationDeserializer(string filePath)
        {
            XmlSerializer locDes = new XmlSerializer(typeof(List<Location>));
            // If the specified file path exists, continue with the operation, else create the file in the intended directory and then continue the operation
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            else
            {
                using (FileStream locFS = File.OpenRead(filePath))
                {
                    // Any data that is found in the external file, is stored in the list listOfLocations (ref. DataAccess.cs)
                    DataAccess.listOfLocations = (List<Location>)locDes.Deserialize(locFS);
                }
            }
        }

        // Deserializer for data that holds information of occured contacts (inc. two individuals involved and date)
        public static void contactDeserializer(string filePath)
        {
            XmlSerializer conDes = new XmlSerializer(typeof(List<ProxyContact>));
            // If the specified file path exists, continue with the operation, else create the file in the intended directory and then continue the operation
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            else
            {
                using (FileStream conFS = File.OpenRead(filePath))
                {
                    // Any data that is found in the external file, is stored in the list proxyContact (ref. DataAccess.cs)
                    DataAccess.proxyContact = (List<ProxyContact>)conDes.Deserialize(conFS);
                }
            }
        }

        // Deserializer for data that holds information of occured visits (inc. location, individual details and date)
        public static void visitDeserializer(string filePath)
        {
            XmlSerializer visDes = new XmlSerializer(typeof(List<ProxyVisit>));
            // If the specified file path exists, continue with the operation, else create the file in the intended directory and then continue the operation
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            else
            {
                using (FileStream visFS = File.OpenRead(filePath))
                {
                    // Any data that is found in the external file, is stored in the list proxyVisit (ref. DataAccess.cs)
                    DataAccess.proxyVisit = (List<ProxyVisit>)visDes.Deserialize(visFS);
                }
            }
        }
    }
}
