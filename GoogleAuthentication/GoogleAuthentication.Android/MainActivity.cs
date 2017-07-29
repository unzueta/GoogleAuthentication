
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Content;

namespace GoogleAuthentication.Droid
{
    [Activity(Label = "GoogleAuthentication", Icon = "@drawable/icon",LaunchMode = LaunchMode.SingleInstance, Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(new[] { Intent.ActionView }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable }, DataScheme = "http", DataHost = "www.pisa.com.co", DataPath = "/oauth2redirect")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnNewIntent(Intent intent)
        {
            if (intent.Data != null)
            {
                var data = intent.Data;

                string queryParameter = data.GetQueryParameter("code");
                App.getGoogleCode(queryParameter);

            }
            base.OnNewIntent(intent);
        }
    }
}

