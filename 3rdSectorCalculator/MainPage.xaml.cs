using System.Windows;
using Microsoft.Phone.Controls;

namespace ThirdSectorCalculator
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            Loaded += MainPage_Loaded;
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
//            if (!App.ViewModel.IsDataLoaded)
//            {
//                App.ViewModel.LoadData();
//            }
        }
    }
}