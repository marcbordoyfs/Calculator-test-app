using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using MarcCalculator;

namespace App1
{
    [Activity(Label = "MarcCalculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private List<TextButton> items;
        private ListView itemlist;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            itemlist = FindViewById<ListView>(Resource.Id.listView1);

            items = new List<TextButton>();
            items.Add(new TextButton()
            {
                screen ="",
                clearallname = "CE",clearname ="C",backname ="<-",dividename = "/",
                seven ="7", eight ="8", nine ="9" ,mult = "x",
                four = "4", five = "5", six = "6", sub = "-",
                one = "1", two = "2", three = "3", plus = "+",
                dot = ".", zero = "0", equal = "=",mode ="MODE"
            });

            mylistveiw adapter = new App1.mylistveiw(this, items);

            itemlist.Adapter = adapter;

    //        itemlist += Mode_Click;
    //        items[0].mode

        }
        private void Mode_Click(object sender, EventArgs e)
        {
            Console.WriteLine(items[0]);
            StartActivity(typeof(TestActivity));
        }

    }

}

