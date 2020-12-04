using System;
using System.Windows;
using System.Windows.Controls;

namespace OOSD
{
    /// <summary>
    /// Interaction logic for Database.xaml
    /// </summary>
    public partial class Database : Window
    {
        public Database()
        {
            InitializeComponent();

            if (DataAccess.listOfPeople.Count >= 1)
            {
                foreach (Person person in DataAccess.listOfPeople)
                {
                    peopleListBox.Items.Add("ID: " + person.ID + Environment.NewLine
                        + "Name: " + person.Name + Environment.NewLine
                        + "Phone Number: " + person.PhoneNumber + Environment.NewLine
                        + Environment.NewLine);
                }
            }
            else
            {
                peopleListBox.Items.Add("No one is currently registered");
            }

            if (DataAccess.listOfLocations.Count >= 1)
            {
                foreach (Location location in DataAccess.listOfLocations)
                {
                    locListBox.Items.Add("Location Name: " + location.Name + Environment.NewLine
                        + "Location Type: " + location.Type + Environment.NewLine
                        + Environment.NewLine);
                }
            }
            else
            {
                locListBox.Items.Add("No location is currently registered");
            }
        }

        private void peopleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow goBack = new MainWindow();
            goBack.Show();
            this.Close();
        }

        private void locVisitBtn_Click(object sender, RoutedEventArgs e)
        {
            LocVisits locVisits = new LocVisits();
            locVisits.Show();
            this.Close();
        }

        private void peopleContactBtn_Click(object sender, RoutedEventArgs e)
        {
            PeopleContacts peopleContacts = new PeopleContacts();
            peopleContacts.Show();
            this.Close();
        }
    }
}
