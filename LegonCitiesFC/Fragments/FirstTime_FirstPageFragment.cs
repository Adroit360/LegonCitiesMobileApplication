using Android.OS;
using Android.Views;
using Android.Widget;
using LegonCitiesFC.Activities;
using Refractored.Controls;
using System;
using System.Collections.Generic;

namespace LegonCitiesFC.Fragments
{
    public class FirstTime_FirstPageFragment : Android.Support.V4.App.Fragment
    {
        View view;
        ImageView _ImgLeftArrow;
        ImageView _ImgRightArrow;
        CircleImageView _ImgFavPlayer;
        TextView _TxtPlayerName;
        Button _NextButton;
        int currentImageIndex = 0;
        List<Tuple<int, string>> playerlistData = new List<Tuple<int, string>>() {
            new Tuple<int, string>(Resource.Drawable.player2,"Player 2"),
            new Tuple<int, string>(Resource.Drawable.player3,"Player 3"),
            new Tuple<int, string>(Resource.Drawable.player4,"Player 4")
        };
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            view = inflater.Inflate(Resource.Layout.fragment_firsttime_first, container, false);
            var skipButton = view.FindViewById<Button>(Resource.Id.btn_skip_ft);
            skipButton.Click += (Activity as FirstTimeActivity).SkipButton_Click;

            _ImgFavPlayer = view.FindViewById<CircleImageView>(Resource.Id.ftf_img_favplayer);
            _ImgLeftArrow = view.FindViewById<ImageView>(Resource.Id.ftf_img_leftarrow);
            _ImgLeftArrow.Click += _ImgLeftArrow_Click;
            _ImgRightArrow = view.FindViewById<ImageView>(Resource.Id.ftf_img_rightarrow);
            _ImgRightArrow.Click += _ImgRightArrow_Click;
            _TxtPlayerName = view.FindViewById<TextView>(Resource.Id.ftf_txt_playername);
            _NextButton = view.FindViewById<Button>(Resource.Id.btn_next_ft);
            _NextButton.Click += _NextButton_Click;
            setSelectedFavPlayer(currentImageIndex);

            return view;
        }

        private void _NextButton_Click(object sender, EventArgs e)
        {
            (Activity as FirstTimeActivity).FirstTimeViewPager.SetCurrentItem(1, true);
        }


        private void _ImgRightArrow_Click(object sender, EventArgs e)
        {
            if (currentImageIndex == playerlistData.Count - 1)
                currentImageIndex = 0;
            else
                currentImageIndex++;

            setSelectedFavPlayer(currentImageIndex);
        }

        private void _ImgLeftArrow_Click(object sender, EventArgs e)
        {
            if (currentImageIndex == 0)
                currentImageIndex = playerlistData.Count - 1;
            else
                currentImageIndex--;

            setSelectedFavPlayer(currentImageIndex);

        }



        void setSelectedFavPlayer(int index)
        {
            var selectedFavPlayer = playerlistData[index];
            _ImgFavPlayer.SetImageResource(selectedFavPlayer.Item1);
            _TxtPlayerName.Text = selectedFavPlayer.Item2;

        }

    }
}