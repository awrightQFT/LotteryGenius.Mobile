using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CarouselView.FormsPlugin.Abstractions;
using LotteryGenius.Mobile.Helpers;
using LotteryGenius.Mobile.Models;
using LotteryGenius.Mobile.ViewModels;
using Newtonsoft.Json;
using Plugin.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ScrolledEventArgs = CarouselView.FormsPlugin.Abstractions.ScrolledEventArgs;

namespace LotteryGenius.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private HomeViewModel _vm;

        public HomePage()
        {
            BindingContext = _vm = new HomeViewModel();
            ConstructData();
            InitializeComponent();
        }

        private async void ConstructData()
        {
            foreach (var item in _vm.MyItemsSource)
            {
                var days = (item.next_draw_date - DateTime.Now).TotalDays;
                var hours = (item.next_draw_date - DateTime.Now).Hours;
                if (days > 0)
                {
                    item.days_until = (int)days;
                    item.hours_until = (int)hours;
                }
                else
                {
                    item.hours_until = (int)hours;
                }
            }
        }

        private void Carousel_OnPositionSelected(object sender, PositionSelectedEventArgs e)
        {
            Debug.WriteLine("Position " + e.NewValue + " selected.");
        }

        private void Carousel_OnScrolled(object sender, ScrolledEventArgs e)
        {
            Debug.WriteLine("Scrolled to " + e.NewValue + " percent.");
            Debug.WriteLine("Direction = " + e.Direction);
        }
    }
}