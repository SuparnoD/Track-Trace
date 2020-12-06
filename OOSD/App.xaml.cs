/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 04/12/2020
 * FILE NAME: App.xaml.cs
 * PURPOSE: Handles events that occur when the program is started or shut down
 * LAYER: Presentation
 */
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace OOSD
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // File path to store data files for (de)serialization
        string filePath = @"../DataFiles";

        // Following events are triggered when the user exits the program
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            /*                LIST OF PEOPLE SERIALIZER                     */
            DataSerializer.personSerializer(filePath + "/people_data.xml");

            /*                LIST OF LOCATION SERIALIZER                   */
            DataSerializer.locationSerializer(filePath + "/location_data.xml");

            /*                LIST OF CONTACTS SERIALIZER                   */
            DataSerializer.contactSerializer(filePath + "/contact.csv");

            /*                LIST OF VISITS SERIALIZER                     */
            // DataSerializer.visitSerializer(filePath + "/visits.xml");
        }

        // Following events are triggered when the user starts the program
        void App_Startup(object sender, StartupEventArgs e)
        {
            /*                LIST OF PEOPLE DESERIALIZER                   */
            DataDeserializer.peopleDeserializer(filePath + "/people_data.xml");

            /*                LIST OF LOCATION DESERIALIZER                 */
            DataDeserializer.locationDeserializer(filePath + "/location_data.xml");

            // DataDeserializer.visitsDeserializer(filePath + "/visits.xml");
        }
    }

}
