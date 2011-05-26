using System;
using System.Windows;
using System.Windows.Controls;
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
            
            sector1TextBox.Tag = 0;
            sector2TextBox.Tag = 0;
            sector3TextBox.Tag = 0;

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
            var sectorNumber = 0;
            var sectorTime = 0;

            var sectorTextBox = sender as TextBox;
            if (sectorTextBox != null)
            {
                sectorNumber = sectorTextBox == sector1TextBox ? 1 : 2;
                sectorTime = (int)sectorTextBox.Tag;
            }
            NavigationService.Navigate(new Uri(string.Format("/SectorTimeInputPage.xaml?sector={0}&time={1}", sectorNumber, sectorTime), UriKind.Relative));

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
                TextBox sectorTextBox = null;
                switch (sectorTimeInputPage.Sector)
                {
                    case 1:
                        sectorTextBox = sector1TextBox;
                        break;

                    case 2:
                        sectorTextBox = sector2TextBox;
                        break;
                }

                if (sectorTextBox != null)
                {
                    sectorTextBox.Text = sectorTimeInputPage.ViewModel.ToString();
                    sectorTextBox.Tag = sectorTimeInputPage.ViewModel.ToMilliseconds();
                }
            }

            base.OnNavigatedTo(e);
        }
    }
}