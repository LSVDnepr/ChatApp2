using Foundation;
using System;
using UIKit;

namespace ChatAppTdd.iOS
{
    public partial class ChatPageVC : UIViewController
    {
		private string _sessionId;
		private string _userId;

		public string SessionId { get => _sessionId; set => _sessionId = value; }
        public string UserId { get => _userId; set => _userId = value; }

        public ChatPageVC (IntPtr handle) : base (handle)
        {
        }


		public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //   InitializeViper();
        }


	}
}