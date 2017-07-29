using GoogleLogin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GoogleAuthentication
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var authRequest =
                            "https://accounts.google.com/o/oauth2/v2/auth"
                            + "?response_type=code"
                            + "&scope=openid"
                            + "&redirect_uri=" + GoogleServices.RedirectUri
                            + "&client_id=" + GoogleServices.ClientId;
            Device.OpenUri(new Uri(authRequest));
        }
    }
}
