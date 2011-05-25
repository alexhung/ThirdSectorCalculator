using System;
using System.Windows;
using Microsoft.Phone.Controls;
using ThirdSectorCalculator.ViewModels;

namespace ThirdSectorCalculator
{
    public partial class MainPage : PhoneApplicationPage
    {
        private PhoneApplicationPage _nextPage;
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
            var sector = sender == sector1TextBox ? 1 : 2;
            NavigationService.Navigate(new Uri(string.Format("/SectorTimeInputPage.xaml?sector={0}", sector), UriKind.Relative));

            e.Complete();
            e.Handled = true;
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            _nextPage = e.Content as PhoneApplicationPage;

            base.OnNavigatedFrom(e);
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (_nextPage != null && _nextPage is SectorTimeInputPage)
            {
                var sectorTimeInputPage = _nextPage as SectorTimeInputPage;
            }

            base.OnNavigatedTo(e);
        }
    }
}