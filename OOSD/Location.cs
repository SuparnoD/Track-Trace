/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 03/12/2020
 * FILE NAME: Location.cs
 * PURPOSE: Acts as a constructor for Location which is used to hold informations of a particular location
 * LAYER: Business
 */
using System;
using System.Runtime.Serialization;

namespace OOSD
{
    [Serializable()]
    public class Location : ISerializable
    {
        private string type;
        private string name;

        public Location(string type, string name)
        {
            this.type = type;
            this.name = name;
        }

        public Location()
        {

        }

        // PROPERTY: Type of venue (e.g hospitality, parks, bars & pubs, etc...)
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        // PROPERTY: Name of the location
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Returns the name of the location (for UI purposes) in the case this object is used to instantiate another object/variable
        public override string ToString()
        {
            return Name;
        }

        // Attributes for Serialization/Deserialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Type", Type);
            info.AddValue("Name", Name);
        }

        // Attributes for Serialization/Deserialization
        public Location(SerializationInfo info, StreamingContext context)
        {
            Type = (string)info.GetValue("Type", typeof(string));
            Name = (string)info.GetValue("Name", typeof(string));
        }
    }
}
