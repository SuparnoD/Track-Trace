using System;
using System.Windows;

namespace OOSD
{
    /// <summary>
    /// Interaction logic for RecordContact.xaml
    /// </summary>
    public partial class RecordContact : Window
    {
        public RecordContact()
        {
            InitializeComponent();

            foreach (Person person in DataAccess.listOfPeople)
            {
                peopleListBox.Items.Add(person);
                peopleListBox2.Items.Add(person);
            }
        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime date;

            // Checks if the date is entered in the correct format - DD:MM:YYY
            if (DateTime.TryParse(dateTxtBox.Text, out date))
            {
                // Prevents program from crashing incase the user did not enter or select the fields properly
                try
                {
                    ContactRecord contactRec = new ContactRecord();
                    contactRec.Person = (Person)peopleListBox.SelectedItem;
                    contactRec.PersonTwo = (Person)peopleListBox2.SelectedItem;
                    contactRec.Date = date;

                    ContactRecord contactRecTwo = new ContactRecord();
                    contactRecTwo.Person = (Person)peopleListBox2.SelectedItem;
                    contactRecTwo.PersonTwo = (Person)peopleListBox.SelectedItem;
                    contactRecTwo.Date = date;

                    // Prevents program from selecting the same object
                    if (contactRec.Person.Equals(contactRec.PersonTwo))
                    {
                        MessageBox.Show("Error! Select two different persons");
                    }
                    else
                    {
                        MessageBox.Show(contactRec.Person.Name + " contacted " + contactRec.PersonTwo.Name + " on " + contactRec.Date);
                        DataAccess.listOfContacts.Add(contactRec);
                        DataAccess.listOfContacts.Add(contactRecTwo);
                    }
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

        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow goBack = new MainWindow();
            goBack.Show();
            this.Close();
        }
    }
}
