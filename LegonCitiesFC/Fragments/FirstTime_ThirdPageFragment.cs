using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using LegonCitiesFC.Activities;

namespace LegonCitiesFC.Fragments
{
    public class FirstTime_ThirdPageFragment : Android.Support.V4.App.Fragment
    {
        View view;
        public TextView TxtJerseyBackName;
        public TextView TxtJerseyBackNumber;
        Button _SkipButton;
        Button LoginButton;
        //Button SignUpButton;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            view = inflater.Inflate(Resource.Layout.fragment_firsttime_third, container, false);
            TxtJerseyBackName = view.FindViewById<TextView>(Resource.Id.ftt_txt_jerseybackname);
            TxtJerseyBackNumber = view.FindViewById<TextView>(Resource.Id.ftt_txt_jerseybacknumber);
            _SkipButton = view.FindViewById<Button>(Resource.Id.btn_ftt_skip);
            LoginButton = view.FindViewById<Button>(Resource.Id.btn_ftt_signin);
            LoginButton.Click += LoginButton_Click;
            //SignUpButton = view.FindViewById<Button>(Resource.Id.btn_ftt_signup);
            //SignUpButton.Click += SignUpButton_Click;

            _SkipButton.Click += (Activity as FirstTimeActivity).SkipButton_Click;
            return view;
        }

        //private void SignUpButton_Click(object sender, System.EventArgs e)
        //{
        //    var mainActivityIntent = new Intent(Activity, typeof(MainActivity));
        //    mainActivityIntent.PutExtra("FirstTimeActionType", "signup");
        //    StartActivity(mainActivityIntent);
        //}

        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            var mainActivityIntent = new Intent(Activity, typeof(MainActivity));
            mainActivityIntent.PutExtra("FirstTimeActionType", "signin");
            StartActivity(mainActivityIntent);

        }

        public override void OnResume()
        {
            TxtJerseyBackName.Text = (Activity as FirstTimeActivity).SelectedPlayerName;
            TxtJerseyBackNumber.Text = (Activity as FirstTimeActivity).SelectedPlayerNumber;
            base.OnResume();
        }

    }
}