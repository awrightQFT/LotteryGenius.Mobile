using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGenius.Mobile.Models
{
    public class PickList
    {
        public List<LotteryPicks> picks { get; set; }
        public string game { get; set; }
    }
}