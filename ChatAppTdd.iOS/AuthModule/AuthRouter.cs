using System;
using ChatAppTdd.AuthModule;
using UIKit;


namespace ChatAppTdd.iOS.AuthModule
{
	public class AuthRouter : IAuthRouter
    {
		private readonly UINavigationController _navController;

		public AuthRouter(UINavigationController navigationController)
        {
			_navController = navigationController ?? throw new ArgumentNullException("Provided navigation controller is null!Recheck"); 
        }

		public void MoveToChat(string sessionId, string userId)
		{
			throw new NotImplementedException();
		}

		public void MoveToRegistration()
		{
			throw new NotImplementedException();
		}
	}
}
