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
    /// Interaction logic for AddLocation.xaml
    /// </summary>
    public partial class AddLocation : Window
    {
        public AddLocation()
        {
            InitializeComponent();
            locListBox.Items.Add("Hospitality");
            locListBox.Items.Add("Bars, Pubs & Clubs");
            locListBox.Items.Add("Hotels");
            locListBox.Items.Add("Conference Centres");
            locListBox.Items.Add("Business Centres");
            locListBox.Items.Add("Community Centres");
            locListBox.Items.Add("Sports Clubs");
            locListBox.Items.Add("Art Galleries");
            locListBox.Items.Add("Academic Venues");
            locListBox.Items.Add("Private Property");
            locListBox.Items.Add("Parks & Fields");
            locListBox.Items.Add("Others");
        }

        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow goBack = new MainWindow();
            goBack.Show();
            this.Close();
        }

        private void addPersonBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Location newLocation = new Location();
                newLocation.Type = locListBox.SelectedItem.ToString();
                newLocation.Name = locNameTextBox.Text;
                DataAccess.listOfLocations.Add(newLocation);

                locListBox.IsEnabled = false;
                locNameTextBox.IsEnabled = false;
                addLocBtn.IsEnabled = false;

                MessageBox.Show(newLocation.Name + " has been added to the database");
            }
            catch
            {
                MessageBox.Show("Error! Please ensure all fields are correctly entered/selected");
            }
        }
    }
}
