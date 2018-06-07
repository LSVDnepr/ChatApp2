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
using ChatAppTdd.AuthModule;

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
          /*  var intent = new Intent(_context, typeof(DetailedInfoActivity));
            intent.PutExtra(DetailedInfoActivity.EntityId_ExtraKey, entityId);
            _context.StartActivity(intent);*/
        }

       

        public void MoveToRegistration()
        {
         /*   var intent = new Intent(_context, typeof(DetailedInfoActivity));
            intent.PutExtra(DetailedInfoActivity.EntityId_ExtraKey, entityId);
            _context.StartActivity(intent);*/
        }
    }
}