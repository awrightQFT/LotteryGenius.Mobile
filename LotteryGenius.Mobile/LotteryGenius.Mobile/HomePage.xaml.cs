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

            InitializeComponent();
        }

        //private async void ConstructData()
        //{
        //    PowerballDraw powerball = null;
        //    NextPowerball next_powerball = null;
        //    MegamillionDraw megamillion = null;
        //    NextMegamillion next_megamillion = null;

        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("https://lotterygeniusapi.azurewebsites.net/");
        //    client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "[GET]");
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    try
        //    {
        //        var response = client.GetAsync("/api/powerball/GetLatestPowerball").Result;

        //        if (response.IsSuccessStatusCode)
        //        {
        //            powerball = JsonConvert.DeserializeObject<PowerballDraw>(
        //                await response.Content.ReadAsStringAsync());
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }

        //    try
        //    {
        //        var response = client.GetAsync("/api/powerball/GetNextPowerball").Result;

        //        if (response.IsSuccessStatusCode)
        //        {
        //            next_powerball = JsonConvert.DeserializeObject<NextPowerball>(await response.Content.ReadAsStringAsync());
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }

        //    try
        //    {
        //        var response = client.GetAsync("/api/megamillion/GetLatestMegamillion").Result;

        //        if (response.IsSuccessStatusCode)
        //        {
        //            megamillion =
        //                JsonConvert.DeserializeObject<MegamillionDraw>(await response.Content.ReadAsStringAsync());
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }

        //    try
        //    {
        //        var response = client.GetAsync("/api/megamillion/GetNextMegamillion").Result;

        //        if (response.IsSuccessStatusCode)
        //        {
        //            next_megamillion =
        //                JsonConvert.DeserializeObject<NextMegamillion>(await response.Content.ReadAsStringAsync());
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine(exception);
        //        throw;
        //    }

        //    var p = new LotteryDraw()
        //    {
        //        type = "powerball",
        //        ball1 = powerball.powerball1,
        //        ball2 = powerball.powerball2,
        //        ball3 = powerball.powerball3,
        //        ball4 = powerball.powerball4,
        //        ball5 = powerball.powerball5,
        //        bonus_ball = powerball.powerball,
        //        multiplier = powerball.powerplay,
        //        draw_date = powerball.powerballDrawDate,
        //        jackpot = powerball.powerballJackpot,
        //        next_draw_date = next_powerball.next_jackpot_date,
        //        next_jackpot = next_powerball.next_jackpot
        //    };

        //    var m = new LotteryDraw()
        //    {
        //        type = "megamillions",
        //        ball1 = megamillion.megamillion1,
        //        ball2 = megamillion.megamillion2,
        //        ball3 = megamillion.megamillion3,
        //        ball4 = megamillion.megamillion4,
        //        ball5 = megamillion.megamillion5,
        //        bonus_ball = megamillion.megaball,
        //        multiplier = megamillion.megaplier,
        //        draw_date = megamillion.megamillionDrawDate,
        //        jackpot = megamillion.megamillionJackpot,
        //        next_draw_date = next_megamillion.next_jackpot_date,
        //        next_jackpot = next_megamillion.next_jackpot
        //    };

        //    Draws = new ObservableCollection<LotteryDraw>();
        //    Draws.Add(p);
        //    Draws.Add(m);

        //    //GameView.ItemsSource = Draws;
        //    //Draws = new ObservableCollection<LotteryDraw>(Draws.ToList().OrderByDescending(x => x.draw_date));
        //}
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