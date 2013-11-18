using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using kyazoongaRest;
using System.Collections;

namespace kyazoongaandroid
{
	[Activity (Label = "eventcat")]			
	public class eventcat : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.eventcat);
			TextView tv = FindViewById<TextView> (Resource.Id.txt);
			RestCall r=new RestCall();
			ArrayList categoriesList=r.getCategoryItemDetails (2);
			tv.Text= string.Format ("{0}  ",((ItemCategory)categoriesList[1]).Date );
			// Create your application here
		}
	}
}

