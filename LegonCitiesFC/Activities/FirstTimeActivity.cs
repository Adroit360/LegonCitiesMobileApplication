
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Preferences;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using LegonCitiesFC.Adapters;
using System;

namespace LegonCitiesFC.Activities
{
    [Activity(Label = "FirstTimeActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class FirstTimeActivity : FragmentActivity
    {
        TabLayout FirstTimeTab = null;
        public ViewPager FirstTimeViewPager = null;
        public FirstTimePagerAdapter firstTimerPageAdapter;
        public string SelectedPlayerName = "";
        public string SelectedPlayerNumber = "";
        public ISharedPreferences sharedPreferences;
        const string ISFIRSTTIME = "ISFIRSTTIME";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(this);
            if (!sharedPreferences.GetBoolean(ISFIRSTTIME, true))
            {
                SkipButton_Click(null, null);
            }
            SetContentView(Resource.Layout.activity_firsttime);

            // Create your application here

            FirstTimeTab = FindViewById<TabLayout>(Resource.Id.tb_firsttime_tab);
            FirstTimeViewPager = FindViewById<ViewPager>(Resource.Id.vp_firsttime_pager);

            firstTimerPageAdapter = new FirstTimePagerAdapter(SupportFragmentManager);
            FirstTimeViewPager.Adapter = firstTimerPageAdapter;
            FirstTimeTab.SetupWithViewPager(FirstTimeViewPager);


        }

        public void SkipButton_Click(object sender, EventArgs e)
        {
            ISharedPreferencesEditor sharedPreferencesEditor = sharedPreferences.Edit();
            sharedPreferencesEditor.PutBoolean(ISFIRSTTIME, false);
            sharedPreferencesEditor.Apply();

            var mainActivityIntent = new Intent(this, typeof(MainActivity));
            StartActivity(mainActivityIntent);
        }


    }

}
