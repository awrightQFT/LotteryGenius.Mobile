using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGenius.Mobile
{
    public class Powerball
    {
        public int id { get; set; }

        public string ball1 { get; set; }

        public string ball2 { get; set; }

        public string ball3 { get; set; }

        public string ball4 { get; set; }

        public string ball5 { get; set; }

        public string powerball { get; set; }

        public string powerplay { get; set; }

        public string jackpot { get; set; }
        public DateTime draw_date { get; set; }
        public DateTime? created_on { get; set; }
        public DateTime? modified_on { get; set; }
    }
}