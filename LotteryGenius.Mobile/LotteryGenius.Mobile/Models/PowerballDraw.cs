using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGenius.Mobile.Models
{
    public class PowerballDraw
    {
        public int powerballId { get; set; }
        public string powerball1 { get; set; }
        public string powerball2 { get; set; }
        public string powerball3 { get; set; }
        public string powerball4 { get; set; }
        public string powerball5 { get; set; }

        public string powerball { get; set; }
        public string powerplay { get; set; }

        public string powerballJackpot { get; set; }
        public DateTime powerballDrawDate { get; set; }
    }
}