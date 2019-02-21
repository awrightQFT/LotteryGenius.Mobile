using System;
using System.Collections.Generic;
using System.Linq;
using CarouselView.FormsPlugin.iOS;
using Foundation;
using UIKit;

namespace LotteryGenius.Mobile.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            global::Xamarin.Forms.Forms.Init();
            CarouselViewRenderer.Init();
            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(133, 187, 101);
            UITabBarItem.Appearance.SetTitleTextAttributes(
                new UITextAttributes()
                {
                    TextColor = UIColor.FromRGBA(255, 255, 255, 102)
                },
                UIControlState.Normal);

            LoadApplication(new App());

            //LoadApplication(UXDivers.Gorilla.iOS.Player.CreateApplication(
            //    new UXDivers.Gorilla.Config("Good Gorilla")
            //));

            return base.FinishedLaunching(app, options);
        }
    }
}