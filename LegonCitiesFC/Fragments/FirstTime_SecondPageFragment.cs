using Android.OS;
using Android.Views;
using Android.Widget;
using LegonCitiesFC.Activities;
using System;

namespace LegonCitiesFC.Fragments
{
    public class FirstTime_SecondPageFragment : Android.Support.V4.App.Fragment
    {
        View view;
        NumberPicker NumberPicker1;
        NumberPicker NumberPicker2;
        EditText TxtNameEntry;
        TextView TxtJerseyBackName;
        TextView TxtJerseyBackNumber;
        Button _NextButton;
        Button _SkipButton;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);



            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            view = inflater.Inflate(Resource.Layout.fragment_firsttime_second, container, false);

            NumberPicker1 = view.FindViewById<NumberPicker>(Resource.Id.numberpicker1);
            NumberPicker2 = view.FindViewById<NumberPicker>(Resource.Id.numberpicker2);
            TxtNameEntry = view.FindViewById<EditText>(Resource.Id.fts_etext_nameentry);
            TxtJerseyBackName = view.FindViewById<TextView>(Resource.Id.fts_txt_jerseybackname);
            TxtJerseyBackNumber = view.FindViewById<TextView>(Resource.Id.fts_txt_jerseybacknumber);
            _NextButton = view.FindViewById<Button>(Resource.Id.btn_fts_next);
            _SkipButton = view.FindViewById<Button>(Resource.Id.btn_fts_skip);


            NumberPicker1.MinValue = 0;
            NumberPicker1.MaxValue = 9;

            NumberPicker2.MinValue = 0;
            NumberPicker2.MaxValue = 9;


            NumberPicker1.ValueChanged += NumberPicker1_ValueChanged;
            NumberPicker2.ValueChanged += NumberPicker2_ValueChanged;
            TxtNameEntry.TextChanged += TxtNameEntry_TextChanged;

            _NextButton.Click += _NextButton_Click;
            _SkipButton.Click += (Activity as FirstTimeActivity).SkipButton_Click;
            return view;
        }

        private void TxtNameEntry_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            try
            {
                string jerseyName = e.Text.ToString().ToUpper();
                if (e.Text.ToString().Length > 8)
                {
                    jerseyName = e.Text.ToString().Substring(0, 8);
                    TxtNameEntry.Text = jerseyName;
                }

                TxtJerseyBackName.Text = jerseyName;

                var activity = (Activity as FirstTimeActivity);

                activity.SelectedPlayerName = jerseyName;
                activity.firstTimerPageAdapter.ThirdPageFragment.TxtJerseyBackName.Text = jerseyName;

            }
            catch
            {

            }

        }

        private void NumberPicker2_ValueChanged(object sender, NumberPicker.ValueChangeEventArgs e)
        {
            SetJerseyNumber();
        }

        private void NumberPicker1_ValueChanged(object sender, NumberPicker.ValueChangeEventArgs e)
        {
            SetJerseyNumber();
        }

        void SetJerseyNumber()
        {
            try
            {
                string jerseyNumber = null;
                if (NumberPicker1.Value == 0)
                {
                    jerseyNumber = NumberPicker2.Value.ToString();
                }
                else
                    jerseyNumber = NumberPicker1.Value.ToString() + NumberPicker2.Value.ToString();


                TxtJerseyBackNumber.Text = jerseyNumber;

                var activity = (Activity as FirstTimeActivity);

                activity.SelectedPlayerNumber = TxtJerseyBackNumber.Text.ToString();
                activity.firstTimerPageAdapter.ThirdPageFragment.TxtJerseyBackNumber.Text = jerseyNumber;

            }
            catch
            {

            }


        }


        private void _NextButton_Click(object sender, EventArgs e)
        {
            (Activity as FirstTimeActivity).FirstTimeViewPager.SetCurrentItem(2, true);
        }

    }
}