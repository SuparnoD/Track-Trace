using System;
using System.Windows;

namespace OOSD
{
    /// <summary>
    /// Interaction logic for RecordVisit.xaml
    /// </summary>
    public partial class RecordVisit : Window
    {
        public RecordVisit()
        {
            InitializeComponent();

            foreach (Person person in DataAccess.listOfPeople)
            {
                peopleListBox.Items.Add(person);
            }

            foreach (Location location in DataAccess.listOfLocations)
            {
                locListBox.Items.Add(location);
            }
        }

        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow goBack = new MainWindow();
            goBack.Show();
            this.Close();
        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime date;

            if (DateTime.TryParse(dateTxtBox.Text, out date))
            {
                try
                {
                    VisitRecord visitRec = new VisitRecord();
                    visitRec.Location = (Location)locListBox.SelectedItem;
                    visitRec.Person = (Person)peopleListBox.SelectedItem;
                    visitRec.Date = date;

                    DataAccess.listOfVisits.Add(visitRec);

                    MessageBox.Show(visitRec.Person.Name + " visited " + visitRec.Location.Name + " on " + date);
                }
                catch
                {
                    MessageBox.Show("Error! Please ensure all fields are correctly entered/selected");
                }
            }
            else
            {
                MessageBox.Show("Error! Please ensure the date is entered in DD/MM/YYYY HH:MM");
            }
        }
    }
}
