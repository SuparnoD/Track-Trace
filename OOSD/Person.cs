/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 09/12/2020
 * FILE NAME: Person.cs
 * PURPOSE: Acts as a constructor for Person which is used to hold informations of an individual
 * LAYER: Business Object
 */
using System;
using System.Runtime.Serialization;

namespace OOSD
{
    [Serializable()]
    public class Person : ISerializable
    {
        private int id;
        private string phoneNumber;

        public Person(int id, string phoneNumber)
        {
            this.id = id;
            this.phoneNumber = phoneNumber;
        }

        public Person()
        {

        }

        // PROPERTY: A unique ID
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        // PROPERTY: An individual's phone number
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        // Returns the ID of the Person (for UI purposes) in the case this object is used to instantiate another object/variable
        public override string ToString()
        {
            return ID.ToString();
        }

        // Attributes for Serialization/Deserialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", ID);
            info.AddValue("Phone Number", PhoneNumber);
        }

        // Attributes for Serialization/Deserialization
        public Person(SerializationInfo info, StreamingContext context)
        {
            ID = (int)info.GetValue("ID", typeof(int));
            PhoneNumber = (string)info.GetValue("Phone Number", typeof(string));
        }
    }
}
