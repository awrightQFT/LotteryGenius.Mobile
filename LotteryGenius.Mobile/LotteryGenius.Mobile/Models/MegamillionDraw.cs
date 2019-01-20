using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGenius.Mobile.Models
{
    public class MegamillionDraw
    {
        public int megamillionId { get; set; }
        public string megamillion1 { get; set; }
        public string megamillion2 { get; set; }
        public string megamillion3 { get; set; }
        public string megamillion4 { get; set; }
        public string megamillion5 { get; set; }

        public string megaball { get; set; }
        public string megaplier { get; set; }
        public string megamillionJackpot { get; set; }
        public DateTime megamillionDrawDate { get; set; }
    }
}