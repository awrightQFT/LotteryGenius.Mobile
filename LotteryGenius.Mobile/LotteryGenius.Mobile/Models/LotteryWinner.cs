using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGenius.Mobile.Models
{
    public class LotteryWinner
    {
        public int winner_id { get; set; }
        public string ball1 { get; set; }
        public string ball2 { get; set; }
        public string ball3 { get; set; }
        public string ball4 { get; set; }
        public string ball5 { get; set; }
        public string bonus_ball { get; set; }
        public string bonus_play { get; set; }
        public DateTime draw_date { get; set; }
        public string jackpot { get; set; }
        public string bonus_image { get; set; }
        public string bonus_text_color { get; set; }
        public List<WinnerPick> winners { get; set; }
    }
}