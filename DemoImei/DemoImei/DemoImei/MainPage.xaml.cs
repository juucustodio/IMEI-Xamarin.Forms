using System;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace DemoImei
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            //Verify Permission
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Phone);
            if (status != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Phone);
                //Best practice to always check that the key exists
                if (results.ContainsKey(Permission.Phone))
                    status = results[Permission.Phone];
            }

            //Get Imei
            LblImei.Text = "IMEI = " + DependencyService.Get<IServiceImei>().GetImei();

        }
    }
}
