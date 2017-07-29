using System;
using System.Diagnostics;

using Xamarin.Forms;

namespace GoogleAuthentication
{
    public partial class App : Application
    {
        public static string UserName { get; set; }
        public static ImageSource ImageUser { get; set; }
        public static string Occupation { get; private set; }

        public App()
        {
            InitializeComponent();

            MainPage = new GoogleAuthentication.MainPage();
        }

        public async static void getGoogleCode(string code)
        {
            try
            {
                if (code != "")
                {
                    GoogleLogin.ViewModels.GoogleViewModel _vm = new GoogleLogin.ViewModels.GoogleViewModel();
                    var accessToken = await _vm.GetAccessTokenAsync(code);

                    await _vm.SetGoogleUserProfileAsync(accessToken);
                    App.UserName = _vm.GoogleProfile.DisplayName;
                    string photo = _vm.GoogleProfile.Image.Url;
                    App.Occupation = _vm.GoogleProfile.Occupation;
                   
                    Debug.WriteLine(App.UserName);
                    App.ImageUser = ImageSource.FromUri(new Uri(photo));
                    App.Current.MainPage = new Views.GoogleProfile();
                    
                }
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
