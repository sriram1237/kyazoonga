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
using System.Threading;


namespace kyazoongaandroid
{
    

	[Activity(Theme = "@style/Theme.Splash",  NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate (bundle);
			//SetContentView(Resource.Layout.splash);
			Thread.Sleep (5000); // Simulate a long loading process on app startup.
			if (Login.loginflag == 1) 
			{
				StartActivity (typeof(Activity1));
			} else 
			{
				StartActivity (typeof(Login));
			}
		}
    }
}
