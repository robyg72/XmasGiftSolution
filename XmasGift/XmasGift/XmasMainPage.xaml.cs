using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XmasGift
{
    public partial class XmasMainPage : ContentPage
    {
        private ObservableCollection<GiftInfo> gifts = new ObservableCollection<GiftInfo>();

        public XmasMainPage()
        {
            InitializeComponent();
            YearPicker.SelectedIndexChanged += YearPicker_SelectedIndexChanged;
            // Fill picker with years
            YearPicker.Items.Add("2016");
            YearPicker.Items.Add("2015");
        }

        private async void YearPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedYear = YearPicker.Items[YearPicker.SelectedIndex];
            gifts = await NetworkServices.GetGiftList(selectedYear);

            if (gifts != null)
            {
                GiftsView.ItemsSource = gifts;
            }
        }
    }
}
