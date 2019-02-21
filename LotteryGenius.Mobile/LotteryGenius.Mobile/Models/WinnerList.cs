using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGenius.Mobile.Models
{
    public class WinnerList
    {
        public List<LotteryWinner> lotto_winners { get; set; }
        public string game { get; set; }
    }
}