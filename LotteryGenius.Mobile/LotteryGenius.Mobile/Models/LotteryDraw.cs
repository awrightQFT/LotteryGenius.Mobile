using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGenius.Mobile.Models
{
    public class LotteryDraw
    {
        public string type { get; set; }
        public string ball1 { get; set; }
        public string ball2 { get; set; }
        public string ball3 { get; set; }
        public string ball4 { get; set; }
        public string ball5 { get; set; }

        public string bonus_ball { get; set; }
        public string multiplier { get; set; }
        public string jackpot { get; set; }
        public DateTime draw_date { get; set; }
        public DateTime next_draw_date { get; set; }

        public string next_jackpot { get; set; }
        public string game_image { get; set; }
    }
}