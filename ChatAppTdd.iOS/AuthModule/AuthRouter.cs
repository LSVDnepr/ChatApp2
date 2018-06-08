using System;
using ChatAppTdd.AuthModule;
using UIKit;
using Foundation;


namespace ChatAppTdd.iOS.AuthModule
{
    public class AuthRouter : IAuthRouter
    {
        private readonly UINavigationController _navController;

        public AuthRouter(UINavigationController navigationController)
        {
            _navController = navigationController ?? throw new ArgumentNullException("Provided navigation controller is null! Recheck"); 
        }

        public void MoveToChat(string sessionId, string userId)
        {
            var destVC = UIStoryboard.FromName("Main", NSBundle.MainBundle).InstantiateViewController("ChatPageVC") as ChatPageVC;
            destVC.SessionId = sessionId ?? throw new ArgumentNullException("Provided sessionId is null!Recheck!");
            destVC.UserId = userId ?? throw new ArgumentNullException("Provided userId is null!Recheck!");
            _navController.PushViewController(destVC, true);
        }

        public void MoveToRegistration()
        {
            var destVC = UIStoryboard.FromName("Main", NSBundle.MainBundle).InstantiateViewController("RegisterVC")as RegisterVC;
            _navController.PushViewController(destVC, true);
        }
    }
}
