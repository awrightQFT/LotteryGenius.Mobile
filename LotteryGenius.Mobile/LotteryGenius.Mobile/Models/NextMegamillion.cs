using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGenius.Mobile.Models
{
    public class NextMegamillion
    {
        public int id { get; set; }
        public DateTime next_jackpot_date { get; set; }
        public string next_jackpot { get; set; }
    }
}