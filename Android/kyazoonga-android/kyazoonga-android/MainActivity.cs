using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using kyazoongaRest;
using System.Collections;
using Android.Util;

namespace kyazoongaandroid
{
	[Activity (Label = "kyazoonga")]
	public class MainActivity : TabActivity
	{
		//public Boolean select=false;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Tab);

			// Get our button from the layout resource,
			// and attach an event to it

			CreateTab(typeof(Cricket), "cricket", "cricket", Resource.Drawable.ic_tab_my_cricket);
			CreateTab(typeof(Events), "events", "events", Resource.Drawable.ic_tab_events);
			CreateTab(typeof(Theatre), "theatre", "theatre", Resource.Drawable.ic_tab_theatre);
			CreateTab(typeof(Sports), "sports", "sports", Resource.Drawable.ic_tab_sports);
			CreateTab(typeof(Store), "store", "store", Resource.Drawable.ic_tab_store);


			string text = Intent.GetStringExtra ("MyData") ?? "Data not available";
			Console.WriteLine (text);
			//CreateTab(text, "cricket", "cricket", Resource.Drawable.ic_tab_my_cricket,select);
			//RestCall r=new RestCall();
			///ArrayList categoriesList=r.getCategoryItemList (2);
		
			//Console.WriteLine ("{0}  ",((CategoriesItem)categoriesList[1]).title);
		}

			//StartActivity (typeof(tes));


		private void CreateTab(Type activityType, string tag, string label, int drawableId )
		{
			var intent = new Intent(this, activityType);
			intent.AddFlags(ActivityFlags.NewTask);

			var spec = TabHost.NewTabSpec(tag);
			var drawableIcon = Resources.GetDrawable(drawableId);
			spec.SetIndicator(label, drawableIcon);
			spec.SetContent(intent);

			TabHost.AddTab(spec);
			TabHost.SetCurrentTabByTag (label);

		}
	}
}


