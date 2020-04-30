
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace LegonCitiesFC.Activities
{
    [Activity(Label = "Legon Cities Fc", MainLauncher = true, Theme = "@style/AppTheme.SplashScreen", Icon = "@drawable/logo", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : Activity
    {
        Handler myHandler;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_splash);

            myHandler = new Handler();

            myHandler.PostDelayed(goToMainActivity, 2000);

            // Create your application here
        }

        void goToMainActivity()
        {
            var mainActivityIntent = new Intent(this, typeof(FirstTimeActivity));
            StartActivity(mainActivityIntent);
            Finish();
        }
    }
}