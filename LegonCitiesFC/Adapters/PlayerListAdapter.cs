using Android.Support.V7.Widget;
using Android.Views;
using Refractored.Controls;
using System;

namespace LegonCitiesFC.Adapters
{
    class PlayerListAdapter : RecyclerView.Adapter
    {
        public event EventHandler<PlayerListAdapterClickEventArgs> ItemClick;
        public event EventHandler<PlayerListAdapterClickEventArgs> ItemLongClick;
        int[] items = { Resource.Drawable.teamplayer, Resource.Drawable.player2, Resource.Drawable.player3, Resource.Drawable.player4 };

        public PlayerListAdapter()
        {
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
            var id = Resource.Layout.template_player_image;
            itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            var vh = new PlayerListAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as PlayerListAdapterViewHolder;
            holder.Image.SetImageResource(items[position]);
        }

        public override int ItemCount => items.Length;

        void OnClick(PlayerListAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(PlayerListAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class PlayerListAdapterViewHolder : RecyclerView.ViewHolder
    {
        public CircleImageView Image { get; set; }


        public PlayerListAdapterViewHolder(View itemView, Action<PlayerListAdapterClickEventArgs> clickListener,
                            Action<PlayerListAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            Image = itemView.FindViewById<CircleImageView>(Resource.Id.tpi_cimage);
            itemView.Click += (sender, e) => clickListener(new PlayerListAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new PlayerListAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class PlayerListAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}