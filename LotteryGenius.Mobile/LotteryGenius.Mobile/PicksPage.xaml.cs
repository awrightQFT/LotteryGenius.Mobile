using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarouselView.FormsPlugin.Abstractions;
using LotteryGenius.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ScrolledEventArgs = Xamarin.Forms.ScrolledEventArgs;

namespace LotteryGenius.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PicksPage : ContentPage
    {
        private PicksViewModel _vm;
        private ViewCell lastCell;

        public PicksPage()
        {
            BindingContext = _vm = new PicksViewModel();

            InitializeComponent();
        }

        private void Carousel_OnPositionSelected(object sender, PositionSelectedEventArgs e)
        {
            Debug.WriteLine("Position " + e.NewValue + " selected.");
        }

        private void Carousel_OnScrolled(object sender, CarouselView.FormsPlugin.Abstractions.ScrolledEventArgs e)
        {
            Debug.WriteLine("Scrolled to " + e.NewValue + " percent.");
            Debug.WriteLine("Direction = " + e.Direction);
        }

        private void PicksList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            throw new NotImplementedException();
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
    }
}