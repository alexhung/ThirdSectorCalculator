using System;
using System.Windows;
using Microsoft.Phone.Controls;
using ThirdSectorCalculator.ViewModels;

namespace ThirdSectorCalculator
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainViewModel MainViewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;

            MainViewModel = new MainViewModel();
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void laptimeTextBox_ManipulationStarted(object sender, System.Windows.Input.ManipulationStartedEventArgs e)
        {

        }

        private void sectorTextBox_ManipulationStarted(object sender, System.Windows.Input.ManipulationStartedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SectorTimeInputPage.xaml", UriKind.Relative));

            e.Complete();
            e.Handled = true;
        }
    }
}