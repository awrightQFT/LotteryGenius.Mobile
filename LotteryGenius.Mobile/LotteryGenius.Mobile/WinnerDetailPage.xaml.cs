using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LotteryGenius.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WinnerDetailPage : ContentPage
    {
        public WinnerDetailPage()
        {
            InitializeComponent();
        }

        private async void OnDismissButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void Cell_OnTapped(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}