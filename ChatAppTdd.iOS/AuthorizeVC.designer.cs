// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ChatAppTdd.iOS
{
    [Register ("AuthorizeVC")]
    partial class AuthorizeVC
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        ChatAppTdd.iOS.AuthPageView _authPageView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_authPageView != null) {
                _authPageView.Dispose ();
                _authPageView = null;
            }
        }
    }
}