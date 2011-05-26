using Microsoft.Phone.Controls;
using Telerik.Windows.Controls;
using ThirdSectorCalculator.ViewModels;

namespace ThirdSectorCalculator
{
    public partial class LapTimeInputPage : PhoneApplicationPage
    {
        public LapTimeViewModel ViewModel { get; private set; }

        public LapTimeInputPage()
        {
            InitializeComponent();

            InitializeLoopingLists();
            BackKeyPress += LapTimeInputPage_BackKeyPress;
            ViewModel = new LapTimeViewModel();
        }

        private void InitializeLoopingLists()
        {
            InitializeLoopingList(MinuteList, 2);
            InitializeLoopingList(SecondList, 59);
            InitializeLoopingList(MillisecondList1, 9);
            InitializeLoopingList(MillisecondList2, 9);
            InitializeLoopingList(MillisecondList3, 9);
        }

        private static void InitializeLoopingList(RadLoopingList millisecondList, int listSize)
        {
            var millisecondsListSource = new LoopingListDataSource(listSize);
            millisecondsListSource.ItemNeeded += (sender, args) =>
                                                     {
                                                         args.Item = new LoopingListDataItem(string.Format("{0}", args.Index + 1));
                                                     };
            millisecondsListSource.ItemUpdated += (sender, args) =>
                                                      {
                                                          args.Item.Text = string.Format("{0}", args.Index + 1);
                                                      };
            millisecondList.DataSource = millisecondsListSource;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            var queryString = NavigationContext.QueryString;

            if (queryString.ContainsKey("time"))
            {
                ViewModel = new LapTimeViewModel(int.Parse(queryString["time"]));
                MinuteList.SelectedIndex = ViewModel.Minute - 1;
                SecondList.SelectedIndex = ViewModel.Seconds - 1;
                MillisecondList1.SelectedIndex = (ViewModel.Milliseconds / 100) - 1;
                MillisecondList2.SelectedIndex = ((ViewModel.Milliseconds % 100) / 10) - 1;
                MillisecondList3.SelectedIndex = (ViewModel.Milliseconds % 10) - 1;
            }

            base.OnNavigatedTo(e);
        }

        private void LapTimeInputPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ViewModel.Minute = MinuteList.SelectedIndex + 1;
            ViewModel.Seconds = SecondList.SelectedIndex + 1;
            ViewModel.Milliseconds = ((MillisecondList1.SelectedIndex + 1) * 100) +
                                     ((MillisecondList2.SelectedIndex + 1) * 10) +
                                     (MillisecondList3.SelectedIndex + 1);
        }
    }
}