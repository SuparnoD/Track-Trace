/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 05/12/2020
 * FILE NAME: MainWindow.xaml.cs
 * PURPOSE: Handles events in response to the user's interaction with window 'MainWindow'
 * LAYER: Presentation
 */
using System;
using System.Windows;

namespace OOSD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // The 'Add Individual' button directs the user to go to the window 'AddIndividual'
        private void addPerson_Click(object sender, RoutedEventArgs e)
        {
            AddIndividual addPerson = new AddIndividual();
            addPerson.Show();
            this.Close();
        }

        // The 'Database' button directs the user to go to the window 'Database'
        private void database_Click(object sender, RoutedEventArgs e)
        {
            Database personList = new Database();
            personList.Show();
            this.Close();
        }

        // The 'Add Location' button directs the user to go to the window 'AddLocation'
        private void addLocation_Click(object sender, RoutedEventArgs e)
        {
            AddLocation addLocation = new AddLocation();
            addLocation.Show();
            this.Close();
        }

        // The 'Record Visit' button directs the user to go to the window 'RecordVisit'
        private void recordVisit_Click(object sender, RoutedEventArgs e)
        {
            RecordVisit recordVisit = new RecordVisit();
            recordVisit.Show();
            this.Close();
        }

        // The 'Record Contact' button directs the user to go to the window 'Record Contact'
        private void recordContact_Click(object sender, RoutedEventArgs e)
        {
            RecordContact recordContact = new RecordContact();
            recordContact.Show();
            this.Close();
        }

        private void listBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void listBox_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
