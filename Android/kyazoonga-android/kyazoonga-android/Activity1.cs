using System.Collections.Generic;
using System;
using Android.Content;

namespace kyazoongaandroid
{
    using Android.App;
    using Android.OS;
    using Android.Widget;

	[Activity(Label = "kyazoonga",Icon = "@drawable/launcher",MainLauncher = true)]
    public class Activity1 : Activity
    {
		ListView listView;
      
		List<Tuple<string, string, int>> items;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Mains);
			//LinearLayout ll = FindViewById<LinearLayout> (Resource.Id.ll);


			items = new List<Tuple<string, string, int>>();
			items.Add(new Tuple<string, string, int>("Cricket", "Bats, Legguards, Gloves, Apparel", Resource.Drawable.cricketicon));
			items.Add(new Tuple<string, string, int>("Events", "24 Ghante Aapke Apne,Diwali", Resource.Drawable.eventicon));
			items.Add(new Tuple<string, string, int>("Theatre & Arts", "KIngdom of Dreams-Zangoora,kingd", Resource.Drawable.theatreartsicon));
			items.Add(new Tuple<string, string, int>("Sports", "I-League,shillong,Lajong Fc,Bung", Resource.Drawable.sportsicon));
			items.Add(new Tuple<string, string, int>("Store", "Cricket,Music,Movies,Sports,Boo", Resource.Drawable.storeicon));
			items.Add(new Tuple<string, string, int>("View Cart", "Your chart is empty", Resource.Drawable.carticon));
			items.Add(new Tuple<string, string, int>("Transaction History", "View your transaction details", Resource.Drawable.carticon));

			listView = FindViewById<ListView> (Resource.Id.List);
			listView.Adapter = new ImageAndSubtitle_Adapter (this, items);
			listView.ItemClick += OnListItemClick;
           
        }
		protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
		{

			var listView = sender as ListView;
			var t = items[e.Position];
			Android.Widget.Toast.MakeText(this, t.Item1, Android.Widget.ToastLength.Short).Show();
			Console.WriteLine("Clicked on " + t);
			//StartActivity (typeof(MainActivity));
			var activity2 = new Intent (this, typeof(MainActivity));
			activity2.PutExtra ("MyData", t.Item1);
			StartActivity (activity2);
		}
    }
}
