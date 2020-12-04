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
        string filePath = @"C:\Users\supar\Documents\Uni";
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            /*                LIST OF PEOPLE SERIALIZER                */
            DataSerializer.personSerializer(filePath + "/people_data.xml");

            /*                LIST OF LOCATION SERIALIZER              */
            DataSerializer.locationSerializer(filePath + "/location_data.xml");

            /*                LIST OF CONTACTS SERIALIZER               */
            DataSerializer.contactSerializer(filePath + "/contact.csv");
        }

        void App_Startup(object sender, StartupEventArgs e)
        {
            /*                LIST OF PEOPLE DESERIALIZER                */
            DataDeserializer.peopleDeserializer(filePath + "/people_data.xml");

            /*                LIST OF LOCATION DESERIALIZER              */
            DataDeserializer.locationDeserializer(filePath + "/location_data.xml");
        }
    }

}
