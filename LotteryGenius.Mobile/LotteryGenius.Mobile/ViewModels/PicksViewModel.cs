using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public class PicksViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public HttpClient client;
        public List<PowerPicks> power_picks;
        public List<MegaPicks> mega_picks;
        public LotteryPicks lottery_picks;
        public PickList pick_list;

        public PicksViewModel()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://lotterygeniusapi.azurewebsites.net/");
            client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "[GET]");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            build_current_powerpicks();
            build_current_megapicks();

            var p = new LotteryPicks();
            var p_list = new List<LotteryPicks>();
            var m = new LotteryPicks();
            var m_list = new List<LotteryPicks>();
            var new_p_list = new PickList();
            var new_m_list = new PickList();

            foreach (var pick in power_picks)
            {
                p_list.Add(new LotteryPicks()
                {
                    ball1 = pick.ball1,
                    ball2 = pick.ball2,
                    ball3 = pick.ball3,
                    ball4 = pick.ball4,
                    ball5 = pick.ball5,
                    bonus_ball = pick.powerball,
                    bonus_text_color = "White",
                    bonus_image = "powerBall.png",
                });
            }

            foreach (var pick in mega_picks)
            {
                m_list.Add(new LotteryPicks()
                {
                    ball1 = pick.ball1,
                    ball2 = pick.ball2,
                    ball3 = pick.ball3,
                    ball4 = pick.ball4,
                    ball5 = pick.ball5,
                    bonus_ball = pick.megaball,
                    bonus_text_color = "Black",
                    bonus_image = "megaBall.png",
                });
            }

            new_p_list.picks = p_list;
            new_p_list.game = "Powerball";
            new_m_list.picks = m_list;
            new_m_list.game = "Megamillions";

            MyItemsSource = new ObservableCollection<PickList>();
            MyItemsSource.Add(new_p_list);
            MyItemsSource.Add(new_m_list);
        }

        private ObservableCollection<PickList> _myItemsSource;

        public ObservableCollection<PickList> MyItemsSource
        {
            set
            {
                _myItemsSource = value;
                OnPropertyChanged("MyItemsSource");
            }
            get { return _myItemsSource; }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void build_current_megapicks()
        {
            mega_picks = null;
            try
            {
                var response = client.GetAsync("/api/megamillion/MegamillionPicks").Result;

                if (response.IsSuccessStatusCode)
                {
                    mega_picks =
                        JsonConvert.DeserializeObject<List<MegaPicks>>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async void build_current_powerpicks()
        {
            power_picks = null;
            try
            {
                var response = client.GetAsync("/api/powerball/PowerballPicks").Result;

                if (response.IsSuccessStatusCode)
                {
                    power_picks =
                        JsonConvert.DeserializeObject<List<PowerPicks>>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}