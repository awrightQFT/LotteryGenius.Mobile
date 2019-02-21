using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LotteryGenius.Mobile.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace LotteryGenius.Mobile.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public HttpClient client;
        public PowerballDraw powerball;
        public NextPowerball next_powerball;
        public MegamillionDraw megamillion;
        public NextMegamillion next_megamillion;

        public HomeViewModel()
        {
            //MyItemsSource = new ObservableCollection<TestGame>()
            //{
            //    new TestGame(){ game_type = "Powerball", multiplier_type = "PowerPlay"},
            //    new TestGame(){ game_type = "Megamillions", multiplier_type = "Megaplier"}
            //};

            //MyCommand = new Command(() =>
            //{
            //    Debug.WriteLine("Position seleclted.");
            //});
            client = new HttpClient();
            client.BaseAddress = new Uri("https://lotterygeniusapi.azurewebsites.net/");
            client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "[GET]");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            build_current_powerball();
            build_next_powerball();
            build_current_megamillions();
            build_next_megamillions();

            var p = new LotteryDraw()
            {
                type = "powerball",
                ball1 = powerball.powerball1,
                ball2 = powerball.powerball2,
                ball3 = powerball.powerball3,
                ball4 = powerball.powerball4,
                ball5 = powerball.powerball5,
                bonus_ball = powerball.powerball,
                multiplier = powerball.powerplay,
                draw_date = powerball.powerballDrawDate,
                jackpot = powerball.powerballJackpot,
                next_draw_date = next_powerball.next_jackpot_date,
                next_jackpot = next_powerball.next_jackpot,
                game_image = "powerball_pp.png",
                bonus_image = "powerBall.png",
                bonus_text_color = "White"
            };

            var m = new LotteryDraw()
            {
                type = "megamillions",
                ball1 = megamillion.megamillion1,
                ball2 = megamillion.megamillion2,
                ball3 = megamillion.megamillion3,
                ball4 = megamillion.megamillion4,
                ball5 = megamillion.megamillion5,
                bonus_ball = megamillion.megaball,
                multiplier = megamillion.megaplier,
                draw_date = megamillion.megamillionDrawDate,
                jackpot = megamillion.megamillionJackpot,
                next_draw_date = next_megamillion.next_jackpot_date,
                next_jackpot = next_megamillion.next_jackpot,
                game_image = "MegaMillions_Logo.png",
                bonus_image = "megaBall.png",
                bonus_text_color = "Black"
            };

            MyItemsSource = new ObservableCollection<LotteryDraw>();

            MyItemsSource.Add(p);
            MyItemsSource.Add(m);
        }

        private ObservableCollection<LotteryDraw> _myItemsSource;

        public ObservableCollection<LotteryDraw> MyItemsSource
        {
            set
            {
                _myItemsSource = value;
                OnPropertyChanged("MyItemsSource");
            }
            get
            {
                return _myItemsSource;
            }
        }

        public Command MyCommand { protected set; get; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void build_current_powerball()
        {
            powerball = null;
            try
            {
                var response = client.GetAsync("/api/powerball/GetLatestPowerball").Result;

                if (response.IsSuccessStatusCode)
                {
                    powerball = JsonConvert.DeserializeObject<PowerballDraw>(
                        await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async void build_next_powerball()
        {
            next_powerball = null;
            try
            {
                var response = client.GetAsync("/api/powerball/GetNextPowerball").Result;

                if (response.IsSuccessStatusCode)
                {
                    next_powerball = JsonConvert.DeserializeObject<NextPowerball>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async void build_current_megamillions()
        {
            megamillion = null;
            try
            {
                var response = client.GetAsync("/api/megamillion/GetLatestMegamillion").Result;

                if (response.IsSuccessStatusCode)
                {
                    megamillion =
                        JsonConvert.DeserializeObject<MegamillionDraw>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async void build_next_megamillions()
        {
            try
            {
                var response = client.GetAsync("/api/megamillion/GetNextMegamillion").Result;

                if (response.IsSuccessStatusCode)
                {
                    next_megamillion =
                        JsonConvert.DeserializeObject<NextMegamillion>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}