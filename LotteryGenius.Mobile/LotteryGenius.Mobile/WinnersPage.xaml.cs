using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotteryGenius.Mobile.Models;
using LotteryGenius.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LotteryGenius.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WinnersPage : ContentPage
    {
        private WinnersViewModel _vm;
        private ViewCell lastCell;

        public WinnersPage()
        {
            BindingContext = _vm = new WinnersViewModel();
            InitializeComponent();
        }

        private void Cell_OnTapped(object sender, EventArgs e)
        {
            if (lastCell != null)
            {
                lastCell.View.BackgroundColor = Color.Transparent;
            }
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.LightGray;
                lastCell = viewCell;
            }
        }

        private async void PicksList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var winnerDetailPage = new WinnerDetailPage();
            winnerDetailPage.BindingContext = e.SelectedItem as LotteryWinner;
            await Navigation.PushModalAsync(winnerDetailPage);
        }
    }
}