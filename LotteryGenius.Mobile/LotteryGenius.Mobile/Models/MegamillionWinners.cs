using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGenius.Mobile.Models
{
    public class MegamillionWinners
    {
        public int id { get; set; }
        public int megamillion_id { get; set; }
        public int pick_id { get; set; }
        public int prize_id { get; set; }

        public string ball1 { get; set; }

        public string ball2 { get; set; }

        public string ball3 { get; set; }

        public string ball4 { get; set; }

        public string ball5 { get; set; }

        public string megaball { get; set; }

        public string megaplier { get; set; }

        public DateTime pick_date { get; set; }

        public float prize_amount { get; set; }

        public bool isDisplayed { get; set; }
    }
}