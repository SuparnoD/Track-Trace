using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOSD
{
    /// <summary>
    /// Interaction logic for PeopleContacts.xaml
    /// </summary>
    public partial class PeopleContacts : Window
    {
        public PeopleContacts()
        {
            InitializeComponent();

            foreach (Person person in DataAccess.listOfPeople)
            {
                peopeListBox.Items.Add(person);
            }
        }

        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Database db = new Database();
            db.Show();
            this.Close();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = Convert.ToDateTime(dateTextBox.Text);

            peopleListBox2.Items.Clear();

            foreach (ContactRecord contactRec in DataAccess.listOfContacts)
            {
                if (peopeListBox.SelectedItem.Equals(contactRec.Person))
                {
                    if (date.CompareTo(contactRec.Date) <= 0)
                    {
                        peopleListBox2.Items.Add("Name: " + contactRec.PersonTwo.Name + Environment.NewLine
                            + "Phone Number: " + contactRec.PersonTwo.PhoneNumber + Environment.NewLine
                            + "Date of Contact: " + contactRec.Date);
                    }
                }
            }
        }
    }
}
