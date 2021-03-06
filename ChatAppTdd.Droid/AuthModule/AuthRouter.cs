﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ChatAppTdd.AuthModule;
using ChatAppTdd.Droid.ChatModule;
using ChatAppTdd.Droid.RegistrationModule;

namespace ChatAppTdd.Droid.AuthModule
{
    public class AuthRouter : IAuthRouter
    {
        private Context _context;

        public AuthRouter(Context context)
        {
            _context = context ?? throw new ArgumentNullException("Passed context argument is null!");
        }

        public void MoveToChat(string sessionId, string userId)
        {
            if (sessionId==null)
            {
                throw new ArgumentNullException("Passed session Id is null");
            }

            if (userId == null)
            {
                throw new ArgumentNullException("Passed user Id is null");
            }

            var intent = new Intent(_context, typeof(ChatActivity));
            intent.PutExtra(ChatActivity.Extras_Key, new string[] { sessionId, userId });
            _context.StartActivity(intent);
        }

       

        public void MoveToRegistration()
        {
            var intent = new Intent(_context, typeof(RegistrationActivity));
            _context.StartActivity(intent);
        }
    }
}