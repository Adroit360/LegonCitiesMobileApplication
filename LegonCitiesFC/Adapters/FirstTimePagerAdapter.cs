using Android.Support.V4.App;
using Android.Views;
using Java.Lang;
using LegonCitiesFC.Fragments;
using System.Collections.Generic;

namespace LegonCitiesFC.Adapters
{
    public class FirstTimePagerAdapter : FragmentPagerAdapter
    {
        public FirstTime_FirstPageFragment FirstPageFragment = new FirstTime_FirstPageFragment();
        public FirstTime_SecondPageFragment SecondPageFragment = new FirstTime_SecondPageFragment();
        public FirstTime_ThirdPageFragment ThirdPageFragment = new FirstTime_ThirdPageFragment();

        public List<string> FragmentListTitles = new List<string>();
        public FirstTimePagerAdapter(FragmentManager fm) : base(fm)
        {

        }

        public override int Count => 3;

        public override Object InstantiateItem(View Container, int position)
        {
            base.InstantiateItem(Container, position);
            if (position == 0)
            {
                return FirstPageFragment;
            }
            else if (position == 1)
            {
                return SecondPageFragment;
            }
            else if (position == 2)
            {
                return ThirdPageFragment;
            }

            return FirstPageFragment;
        }

        public override Fragment GetItem(int position)
        {
            // getItem is called to instantiate the fragment for the given page.

            switch (position)
            {
                case 0:
                    return FirstPageFragment;
                case 1: return SecondPageFragment;
                case 2: return ThirdPageFragment;
                default:
                    return FirstPageFragment;
            }
        }

        public string GetPageTitle(int position)
        {
            return "";
        }

    }
}