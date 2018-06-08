using Foundation;
using System;
using UIKit;
using ChatAppTdd.AuthModule;
using ChatAppTdd.Repository;
using ChatAppTdd.iOS.AuthModule;

namespace ChatAppTdd.iOS
{
    public partial class AuthorizeVC : UIViewController
    {
        public AuthorizeVC (IntPtr handle) : base (handle)
        {
        }


		public override void ViewDidLoad()
        {
            base.ViewDidLoad();
               InitializeViper();
        }


        private void InitializeViper()
		{
			IAuthPresenter presenter = new AuthPresenter(_authPageView, new AuthRouter(NavigationController));
			IAuthInteractor interactor = new AuthInteractor(new UserDataService(), presenter);

		}

    }
}