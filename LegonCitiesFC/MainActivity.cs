using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Constraints;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace LegonCitiesFC
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.SplashScreen")]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        WebView homeWebView;
        WebView exploreWebView;
        WebView shopWebView;
        WebView chatWebView;

        BottomNavigationView navigation;

        ProgressBar mainProgressBar;
        ProgressBar exploreProgressBar;
        ProgressBar shopProgressBar;
        ProgressBar chatProgressBar;

        ConstraintLayout ExplorePage;
        ConstraintLayout ShopPage;
        ConstraintLayout ChatPage;

        CardView NewsCard;
        CardView VideosCard;
        CardView FixturesCard;
        CardView PlayersCard;
        CardView ShopCard;
        CardView LegonCitiesComCard;

        Button btnChatRegister;
        Button btnChatLogin;

        int CurrentActiveNavItem;
        bool IsChatPageVisited = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            string firstTimeActionType = null;

            if (Intent.Extras != null)
                firstTimeActionType = Intent.Extras.GetString("FirstTimeActionType", "");

            homeWebView = FindViewById<WebView>(Resource.Id.home_webview);
            exploreWebView = FindViewById<WebView>(Resource.Id.explore_webview);
            shopWebView = FindViewById<WebView>(Resource.Id.shop_webview);
            chatWebView = FindViewById<WebView>(Resource.Id.chat_webview);

            btnChatRegister = FindViewById<Button>(Resource.Id.main_btn_register);
            btnChatLogin = FindViewById<Button>(Resource.Id.main_btn_login);

            btnChatRegister.Click += BtnChatRegister_Click;
            btnChatLogin.Click += BtnChatLogin_Click;

            homeWebView.Settings.JavaScriptEnabled = true;
            exploreWebView.Settings.JavaScriptEnabled = true;
            shopWebView.Settings.JavaScriptEnabled = true;
            chatWebView.Settings.JavaScriptEnabled = true;

            homeWebView.SetWebViewClient(new WebViewClient());
            exploreWebView.SetWebViewClient(new WebViewClient());
            shopWebView.SetWebViewClient(new WebViewClient());
            chatWebView.SetWebViewClient(new WebViewClient());

            homeWebView.LoadUrl("http://legoncities.com/mobilehomepage/");
            shopWebView.LoadUrl("http://legoncities.com/mobileshop/");
            chatWebView.LoadUrl("http://legoncities.com/mobilechatroom/");

            mainProgressBar = FindViewById<ProgressBar>(Resource.Id.main_progressbar);
            exploreProgressBar = FindViewById<ProgressBar>(Resource.Id.explore_progressbar);
            shopProgressBar = FindViewById<ProgressBar>(Resource.Id.shop_progressbar);
            chatProgressBar = FindViewById<ProgressBar>(Resource.Id.chat_progressbar);


            navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            ExplorePage = FindViewById<ConstraintLayout>(Resource.Id.explore_page);
            ShopPage = FindViewById<ConstraintLayout>(Resource.Id.shop_page);
            ChatPage = FindViewById<ConstraintLayout>(Resource.Id.chat_page);

            NewsCard = FindViewById<CardView>(Resource.Id.news_card);
            NewsCard.Click += Card_Click;

            VideosCard = FindViewById<CardView>(Resource.Id.videos_card);
            VideosCard.Click += Card_Click;
            FixturesCard = FindViewById<CardView>(Resource.Id.fixtures_card);
            FixturesCard.Click += Card_Click;
            PlayersCard = FindViewById<CardView>(Resource.Id.players_card);
            PlayersCard.Click += Card_Click;
            ShopCard = FindViewById<CardView>(Resource.Id.shops_card);
            ShopCard.Click += Card_Click;
            LegonCitiesComCard = FindViewById<CardView>(Resource.Id.legoncitiescom_card);
            LegonCitiesComCard.Click += Card_Click;

            mainProgressBar.Max = 100;
            exploreProgressBar.Max = 100;
            shopProgressBar.Max = 100;
            chatProgressBar.Max = 100;

            homeWebView.SetWebChromeClient(new MainWebChromeClient(mainProgressBar));
            exploreWebView.SetWebChromeClient(new MainWebChromeClient(exploreProgressBar));
            shopWebView.SetWebChromeClient(new MainWebChromeClient(shopProgressBar));
            chatWebView.SetWebChromeClient(new MainWebChromeClient(chatProgressBar));

            navigation.SetOnNavigationItemSelectedListener(this);


            if (firstTimeActionType == "signup")
            {
                navigation.SelectedItemId = Resource.Id.navigation_chat;
                BtnChatRegister_Click(null, null);
            }
            else if (firstTimeActionType == "signin")
            {
                navigation.SelectedItemId = Resource.Id.navigation_chat;
                BtnChatLogin_Click(null, null);
            }
        }

        private void BtnChatLogin_Click(object sender, System.EventArgs e)
        {
            chatWebView.LoadUrl("http://legoncities.com/mobilechatroom/");
            chatWebView.Visibility = ViewStates.Visible;
            ChatPage.Visibility = ViewStates.Gone;
            IsChatPageVisited = true;
        }

        private void BtnChatRegister_Click(object sender, System.EventArgs e)
        {
            chatWebView.LoadUrl("http://legoncities.com/mobilechatroom/");
            chatWebView.Visibility = ViewStates.Visible;
            ChatPage.Visibility = ViewStates.Gone;
            IsChatPageVisited = true;
        }

        private void Card_Click(object sender, System.EventArgs e)
        {
            var senderCard = (sender as CardView);

            exploreWebView.Visibility = ViewStates.Visible;
            ExplorePage.Visibility = ViewStates.Gone;
            ShopPage.Visibility = ViewStates.Gone;
            ChatPage.Visibility = ViewStates.Gone;

            switch (senderCard.Id)
            {
                case Resource.Id.news_card:
                    exploreWebView.LoadUrl("http://legoncities.com/mobilenews/");
                    break;
                case Resource.Id.videos_card:

                    exploreWebView.LoadUrl("http://legoncities.com/mobilevideos/");
                    break;
                case Resource.Id.fixtures_card:
                    exploreWebView.LoadUrl("http://legoncities.com/mobileleaguetable/");
                    break;
                case Resource.Id.players_card:
                    exploreWebView.LoadUrl("http://legoncities.com/team/");
                    break;
                case Resource.Id.shops_card:
                    exploreWebView.LoadUrl("http://legoncities.com/shop/");
                    break;
                case Resource.Id.legoncitiescom_card:
                    exploreWebView.Visibility = ViewStates.Gone;
                    ExplorePage.Visibility = ViewStates.Visible;
                    Intent browserIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("http://legoncities.com"));
                    StartActivity(browserIntent);
                    return;
                default:
                    break;
            }

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            ExplorePage.Visibility = ViewStates.Gone;
            ShopPage.Visibility = ViewStates.Gone;
            ChatPage.Visibility = ViewStates.Gone;

            homeWebView.Visibility = ViewStates.Gone;
            shopWebView.Visibility = ViewStates.Gone;
            chatWebView.Visibility = ViewStates.Gone;

            switch (item.ItemId)
            {
                case Resource.Id.navigation_royals:
                    homeWebView.Visibility = ViewStates.Visible;
                    //homeWebView.LoadUrl("http://legoncities.com/mobilehomepage/");
                    CurrentActiveNavItem = Resource.Id.navigation_royals;
                    return true;
                case Resource.Id.navigation_explore:
                    ExplorePage.Visibility = ViewStates.Visible;
                    CurrentActiveNavItem = Resource.Id.navigation_explore;
                    return true;
                case Resource.Id.navigation_shop:
                    shopWebView.Visibility = ViewStates.Visible;
                    //shopWebView.LoadUrl("http://legoncities.com/mobileshop/");
                    CurrentActiveNavItem = Resource.Id.navigation_shop;
                    return true;
                case Resource.Id.navigation_chat:
                    //if (IsChatPageVisited)
                    //{
                    //    chatWebView.Visibility = ViewStates.Visible;
                    //}
                    //else
                    //{
                    //    ChatPage.Visibility = ViewStates.Visible;
                    //}
                    chatWebView.Visibility = ViewStates.Visible;
                    CurrentActiveNavItem = Resource.Id.navigation_chat;

                    return true;
            }

            return false;
        }

        public override void OnBackPressed()
        {

            if (CurrentActiveNavItem == Resource.Id.navigation_royals)
            {
                if (homeWebView.CanGoBack())
                {
                    homeWebView.GoBack();
                    return;
                }
            }
            else if (CurrentActiveNavItem == Resource.Id.navigation_explore)
            {
                if (exploreWebView.CanGoBack())
                {
                    exploreWebView.GoBack();
                    return;
                }
                else if (ExplorePage.Visibility == ViewStates.Gone)
                {
                    exploreWebView.Visibility = ViewStates.Gone;
                    ExplorePage.Visibility = ViewStates.Visible;
                    return;
                }

            }
            else if (CurrentActiveNavItem == Resource.Id.navigation_shop)
            {
                if (shopWebView.CanGoBack())
                {
                    shopWebView.GoBack();
                    return;
                }
            }
            else if (CurrentActiveNavItem == Resource.Id.navigation_chat)
            {
                if (chatWebView.CanGoBack())
                {
                    chatWebView.GoBack();
                    return;
                }
            }


            base.OnBackPressed();
        }
    }
    class MainWebChromeClient : WebChromeClient
    {
        ProgressBar progressBar;
        public MainWebChromeClient(ProgressBar _progressBar)
        {
            progressBar = _progressBar;
        }
        public override void OnProgressChanged(WebView view, int newProgress)
        {

            progressBar.Progress = newProgress;

            if (newProgress == 100)
                progressBar.Visibility = ViewStates.Gone;
            else
                progressBar.Visibility = ViewStates.Visible;

            base.OnProgressChanged(view, newProgress);
        }

        public override void OnReceivedTitle(WebView view, string title)
        {
            base.OnReceivedTitle(view, title);
        }

        public override void OnReceivedIcon(WebView view, Bitmap icon)
        {
            base.OnReceivedIcon(view, icon);
        }


    }
}

