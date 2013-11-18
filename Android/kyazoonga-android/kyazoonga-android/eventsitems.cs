using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using kyazoongaRest;
using System.Collections;
using Android.Util;
using System.Collections.Generic;
using Java.Util;
using System.Text.RegularExpressions;

namespace kyazoongaandroid
{
	[Activity (Label = "eventsitems")]			
	public class eventsitems : Activity
	{
		ListView listView;
		System.Collections.ArrayList categoriesItem;
		List<Tuple<string, string,string, int,string>> items;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.events);
			string text = Intent.GetStringExtra ("MyData") ?? "Data not available";
			Console.WriteLine (text);

			String[] st = Regex.Split(text,"_");
			int n = Convert.ToInt32 (st [1]);
			Console.WriteLine (n);
//			while (st.HasMoreElements) {
//				Console.WriteLine (st.NextElement());
//			}
			try{
			

			RestCall r=new RestCall();
			categoriesItem=r.getCategoryItemList (2);
			Console.WriteLine ("{0}  ",((CategoriesItem)categoriesItem[n-1]).id);
			items = new List<Tuple<string, string,string, int,string>>();
			items.Add (new Tuple<string, string, string,int,string> (((CategoriesItem)categoriesItem [n-1]).title, "venus :" + ((CategoriesItem)categoriesItem [n-1]).venue, "date :", Resource.Drawable.loifl,((CategoriesItem)categoriesItem [n-1]).id));
		
			listView = FindViewById<ListView> (Resource.Id.List);
			listView.Adapter = new ImageAndTexts (this, items);
				listView.ItemClick += OnListItemClick;
			}catch(Exception e)
			{
			}
		}
			protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
			{

				var listView = sender as ListView;
				var t = items[e.Position];
				Android.Widget.Toast.MakeText(this, t.Item1, Android.Widget.ToastLength.Short).Show();
				Console.WriteLine("Clicked on " + t);
				//StartActivity (typeof(eventcat));
				var activity2 = new Intent (this, typeof(eventcat));
				activity2.PutExtra ("MyData", t.Item5);
				StartActivity (activity2);
			}
		



			// Create your application here
		}
	}


