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

namespace LotteryGenius.Mobile.ViewModels
{
    public class WinnersViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public HttpClient client;
        public List<PowerWinners> power_winners;
        public List<MegaWinners> mega_winners;
        public LotteryWinner lottery_winner;
        public WinnerList winner_list;

        public WinnersViewModel()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://lotterygeniusapi.azurewebsites.net/");
            client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "[GET]");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            build_current_powerwinners();
            build_current_megawinners();

            var pw_list = new List<LotteryWinner>();
            var pwp_list = new List<WinnerPick>();
            var mw_list = new List<LotteryWinner>();
            var mwp_list = new List<WinnerPick>();

            var new_pw_list = new WinnerList();
            var new_mw_list = new WinnerList();

            foreach (var winner in power_winners)
            {
                foreach (var winner_pick in winner.picks)
                {
                    pwp_list.Add(new WinnerPick()
                    {
                        ball1 = winner_pick.ball1,
                        ball2 = winner_pick.ball2,
                        ball3 = winner_pick.ball3,
                        ball4 = winner_pick.ball4,
                        ball5 = winner_pick.ball5,
                        bonus_ball = winner_pick.powerball,
                        bonus_play = winner_pick.powerplay,
                        isDisplayed = winner_pick.isDisplayed,
                        pick_id = winner_pick.pick_id,
                        pick_date = winner_pick.pick_date,
                        prize_id = winner_pick.prize_id,
                        prize_amount = winner_pick.prize_amount,
                        bonus_image = "powerBall.png",
                        bonus_text_color = "White"
                    });
                }

                pw_list.Add(new LotteryWinner()
                {
                    ball1 = winner.ball1,
                    ball2 = winner.ball2,
                    ball3 = winner.ball3,
                    ball4 = winner.ball4,
                    ball5 = winner.ball5,
                    bonus_ball = winner.powerball,
                    bonus_text_color = "White",
                    bonus_image = "powerBall.png",
                    bonus_play = winner.powerplay,
                    jackpot = winner.jackpot,
                    winner_id = winner.id,
                    draw_date = winner.draw_date,
                    winners = pwp_list
                });
            }

            foreach (var winner in mega_winners)
            {
                foreach (var winner_pick in winner.picks)
                {
                    mwp_list.Add(new WinnerPick()
                    {
                        ball1 = winner_pick.ball1,
                        ball2 = winner_pick.ball2,
                        ball3 = winner_pick.ball3,
                        ball4 = winner_pick.ball4,
                        ball5 = winner_pick.ball5,
                        bonus_ball = winner_pick.megaball,
                        bonus_play = winner_pick.megaplier,
                        isDisplayed = winner_pick.isDisplayed,
                        pick_id = winner_pick.pick_id,
                        pick_date = winner_pick.pick_date,
                        prize_id = winner_pick.prize_id,
                        prize_amount = winner_pick.prize_amount,
                        bonus_image = "megaBall.png",
                        bonus_text_color = "Black"
                    });
                }

                mw_list.Add(new LotteryWinner()
                {
                    ball1 = winner.ball1,
                    ball2 = winner.ball2,
                    ball3 = winner.ball3,
                    ball4 = winner.ball4,
                    ball5 = winner.ball5,
                    bonus_ball = winner.megaball,
                    bonus_text_color = "Black",
                    bonus_image = "megaBall.png",
                    bonus_play = winner.megaplier,
                    jackpot = winner.jackpot,
                    winner_id = winner.id,
                    draw_date = winner.draw_date,
                    winners = mwp_list
                });
            }

            new_pw_list.lotto_winners = pw_list;
            new_pw_list.game = "Powerball";
            new_mw_list.lotto_winners = mw_list;
            new_mw_list.game = "Megamaillions";

            MyItemsSource = new ObservableCollection<WinnerList>();
            MyItemsSource.Add(new_pw_list);
            MyItemsSource.Add(new_mw_list);
        }

        private ObservableCollection<WinnerList> _myItemsSource;

        public ObservableCollection<WinnerList> MyItemsSource
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

        private async void build_current_powerwinners()
        {
            power_winners = null;
            try
            {
                var response = client.GetAsync("/api/powerball/ShowPowerballWinners").Result;
                if (response.IsSuccessStatusCode)
                {
                    power_winners =
                        JsonConvert.DeserializeObject<List<PowerWinners>>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async void build_current_megawinners()
        {
            mega_winners = null;
            try
            {
                var response = client.GetAsync("/api/megamillion/ShowMegamillionWinners").Result;
                if (response.IsSuccessStatusCode)
                {
                    mega_winners =
                        JsonConvert.DeserializeObject<List<MegaWinners>>(await response.Content.ReadAsStringAsync());
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