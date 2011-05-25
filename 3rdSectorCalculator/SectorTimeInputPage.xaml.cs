using System;
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
            var secondsListSource = new LoopingListDataSource(60);
            secondsListSource.ItemNeeded += (sender, args) =>
                                                {
                                                    args.Item = new LoopingListDataItem(string.Format("{0}", args.Index + 1));
                                                };
            secondsListSource.ItemUpdated += (sender, args) =>
                                                 {
                                                     args.Item.Text = string.Format("{0}", args.Index + 1);
                                                 };
            SecondList.DataSource = secondsListSource;

            InitializeMillisecondLoopingList(MillisecondList1);
            InitializeMillisecondLoopingList(MillisecondList2);
            InitializeMillisecondLoopingList(MillisecondList3);
        }

        private static void InitializeMillisecondLoopingList(RadLoopingList millisecondList)
        {
            var millisecondsListSource = new LoopingListDataSource(9);
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
            if (queryString.ContainsKey("sector"))
            {
                Sector = Int32.Parse(queryString["sector"]);
                PageTitle.Text = string.Format("Enter sector {0} time", Sector);
            }

            base.OnNavigatedTo(e);
        }

        void SectorTimeInputPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ViewModel.Seconds = SecondList.SelectedIndex + 1;
            ViewModel.Milliseconds = ((MillisecondList1.SelectedIndex + 1)*100) +
                                     ((MillisecondList2.SelectedIndex + 1)*10) +
                                     (MillisecondList3.SelectedIndex + 1);
        }
    }
}