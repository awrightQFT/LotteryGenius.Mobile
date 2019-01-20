using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Support.V7.App;

namespace LotteryGenius.Mobile.Droid
{
    using Android.App;
    using Android.Content;
    using Android.OS;

    [Activity(Label = "Lottery Genius", NoHistory = true, Icon = "@drawable/lg_launcher", Theme = "@style/Theme.Splash", MainLauncher = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            this.Finish();
        }
    }
}