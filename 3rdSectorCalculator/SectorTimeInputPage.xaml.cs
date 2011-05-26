using Microsoft.Phone.Controls;
using Telerik.Windows.Controls;
using ThirdSectorCalculator.ViewModels;

namespace ThirdSectorCalculator
{
    public partial class SectorTimeInputPage : PhoneApplicationPage
    {
        public int Sector { get; private set; }
        public SectorTimeViewModel ViewModel { get; private set; }

        public SectorTimeInputPage()
        {
            InitializeComponent();

            InitializeLoopingLists();
            BackKeyPress += SectorTimeInputPage_BackKeyPress;

            ViewModel = new SectorTimeViewModel();
        }

        private void InitializeLoopingLists()
        {
            InitializeLoopingList(SecondList, 60);
            InitializeLoopingList(MillisecondList1, 10);
            InitializeLoopingList(MillisecondList2, 10);
            InitializeLoopingList(MillisecondList3, 10);
        }

        private static void InitializeLoopingList(RadLoopingList millisecondList, int listSize)
        {
            var millisecondsListSource = new LoopingListDataSource(listSize);
            millisecondsListSource.ItemNeeded += (sender, args) =>
            {
                args.Item = new LoopingListDataItem(string.Format("{0}", args.Index));
            };
            millisecondsListSource.ItemUpdated += (sender, args) =>
            {
                args.Item.Text = string.Format("{0}", args.Index);
            };
            millisecondList.DataSource = millisecondsListSource;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            var queryString = NavigationContext.QueryString;
            if (queryString.ContainsKey("sector"))
            {
                Sector = int.Parse(queryString["sector"]);
                PageTitle.Text = string.Format("Enter sector {0} time", Sector);
            }

            if (queryString.ContainsKey("time"))
            {
                ViewModel = new SectorTimeViewModel(int.Parse(queryString["time"]));
                SecondList.SelectedIndex = ViewModel.Seconds;
                MillisecondList1.SelectedIndex = (ViewModel.Milliseconds/100);
                MillisecondList2.SelectedIndex = ((ViewModel.Milliseconds%100)/10);
                MillisecondList3.SelectedIndex = (ViewModel.Milliseconds%10);
            }

            base.OnNavigatedTo(e);
        }

        private void SectorTimeInputPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ViewModel.Seconds = SecondList.SelectedIndex;
            ViewModel.Milliseconds = ((MillisecondList1.SelectedIndex)*100) +
                                     ((MillisecondList2.SelectedIndex)*10) +
                                     (MillisecondList3.SelectedIndex);
        }
    }
}