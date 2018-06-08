using Foundation;
using System;
using UIKit;
using System.ComponentModel;
using ChatAppTdd.AuthModule;
using CoreGraphics;

namespace ChatAppTdd.iOS
{
	[DesignTimeVisible(true)]
	public partial class AuthPageView : UIView,IComponent,IAuthView
    {



		private string _loginButtonTxt;
		private string _signUpBtnTxt;

        public AuthPageView (IntPtr handle) : base (handle)
        {
			Initialize();
        }


		public AuthPageView(CGRect frame):base(frame)
		{
			Initialize();
		}


        private void Initialize()
		{
			if ((Site !=null)&&Site.DesignMode)
			{
				return;
			}

			NSBundle.MainBundle.LoadNib("AuthPageView", this, null);
			this.Frame = Bounds;
			this._authPageView.Frame = Bounds;

			_loginBtn.AddGestureRecognizer(new UITapGestureRecognizer(LoginBtnPressed));

			_signUpBtn.AddGestureRecognizer(new UITapGestureRecognizer(SignUpBtnPressed));

			_langSwitch.ValueChanged += LangSwithChecked;

			this.AddSubview(this._authPageView);


		}

		public ISite Site { get ; set ; }
        

		public string LoginLabelTxt { set => _loginLabelTxt.Text = value ?? throw new ArgumentNullException("Passed login label text is null!"); }
		public string LoginButtonTxt { set { _loginBtn.SetTitle(value, UIControlState.Normal); _loginBtn.TitleLabel.Text = value; } }
//		public string LoginButtonTxt { set => _loginBtn. = value ?? throw new ArgumentNullException("Passed login button text is null!"); }
		public string PasswordLabelTxt { set => _passwordLabelText.Text = value ?? throw new ArgumentNullException("Passed password label text is null!"); } 
		public string SignUpBtnTxt { set { _signUpBtn.SetTitle(value, UIControlState.Normal); _signUpBtn.TitleLabel.Text = value; }}

		public event EventHandler Disposed;

		public event Action<string, string> OnLoginBtnPressed;
		public event Action OnSignUpBtnPressed;
		public event Action<string> OnLocaleChanged;

		public void ShowErrorMessage(string message)
		{
			UIAlertView _error = new UIAlertView(message, message, null, "Ok", null);
            _error.Show();
		}

		private void LoginBtnPressed(UIGestureRecognizer recognizer)
		{

			if (recognizer.State==UIGestureRecognizerState.Ended)
			{
				OnLoginBtnPressed?.Invoke(_loginField.Text,_passwordField.Text);
			}

		}

		private void SignUpBtnPressed(UIGestureRecognizer recognizer)
        {

			if (recognizer.State == UIGestureRecognizerState.Ended)
            {
                OnSignUpBtnPressed?.Invoke();
            }

        }

		private void LangSwithChecked(object sender,EventArgs e)
		{

			OnLocaleChanged?.Invoke(_langSwitch.On?"RU":"EN");

		}


	}
}