using Android.App;
using Android.OS;

namespace RogersPizzaria.Droid
{
    [Activity(MainLauncher = true, Theme = "@style/Theme.Splash")]
    public class Main : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            StartActivity(typeof(MainActivity));
            this.Finish();
        }
    }
}