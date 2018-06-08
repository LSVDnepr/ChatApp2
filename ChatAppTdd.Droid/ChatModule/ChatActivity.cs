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

namespace ChatAppTdd.Droid.ChatModule
{
    [Activity(Label = "ChatActivity")]
    public class ChatActivity : Activity
    {
        public static string Extras_Key = "74185296";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ChatLayout);
            // Create your application here
        }
    }
}