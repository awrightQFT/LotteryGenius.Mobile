using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace LotteryGenius.Mobile.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        #region Setting Constants

        private const string Url = "api_url";
        private static readonly string UrlDefault = "https://lotterygeniusapi.azurewebsites.net/";

        #endregion Setting Constants

        public static string ApiUrl
        {
            get => AppSettings.GetValueOrDefault(Url, UrlDefault);
            set => AppSettings.AddOrUpdateValue(Url, value);
        }
    }
}