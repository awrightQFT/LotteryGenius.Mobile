using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGenius.Mobile.Models
{
    public class MegaWinners
    {
        public int id { get; set; }
        public string ball1 { get; set; }
        public string ball2 { get; set; }
        public string ball3 { get; set; }
        public string ball4 { get; set; }
        public string ball5 { get; set; }
        public string megaball { get; set; }
        public string megaplier { get; set; }
        public DateTime draw_date { get; set; }
        public string jackpot { get; set; }
        public IEnumerable<MegamillionWinners> picks { get; set; }
    }
}