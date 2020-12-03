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
    /// Interaction logic for LocVisits.xaml
    /// </summary>
    public partial class LocVisits : Window
    {
        public LocVisits()
        {
            InitializeComponent();

            foreach (Location location in DataAccess.listOfLocations)
            {
                locList.Items.Add(location);
            }
        }

        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Database db = new Database();
            db.Show();
            this.Close();
        }

        private void locList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void visitRecord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateOne = Convert.ToDateTime(date1.Text);
            DateTime dateTwo = Convert.ToDateTime(date2.Text);

            if (dateOne.CompareTo(dateTwo) > 0)
            {
                MessageBox.Show("Error! Incorrect date range.");
            }

            visitRecord.Items.Clear();

            foreach (VisitRecord visitRec in DataAccess.listOfVisits)
            {
                if (locList.SelectedItem.Equals(visitRec.Location))
                {
                    if (dateOne.CompareTo(visitRec.Date) <= 0)
                    {
                        if (dateTwo.CompareTo(visitRec.Date) >= 0)
                        {
                            visitRecord.Items.Add("Name: " + visitRec.Person.Name + Environment.NewLine
                                + "Phone Number: " + visitRec.Person.PhoneNumber + Environment.NewLine
                                + "Date of Visit: " + visitRec.Date);
                        }
                    }
                }
            }
        }
    }
}
