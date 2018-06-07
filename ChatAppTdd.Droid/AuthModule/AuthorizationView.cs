using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using ChatAppTdd.AuthModule;

namespace ChatAppTdd.Droid.AuthModule
{
    public class AuthorizationView : LinearLayout, IAuthView
    {
        private TextView _loginLabelTxt;
        private Button _loginButton;
        private TextView _passwordLabelTxt;
        private Button _signUpBtn;
        private EditText _loginField;
        private EditText _passwordField;
        private Switch _langSwitch;



        public AuthorizationView(Context context) : base(context)
        {
      //     InitializeAuthView();
        }

        public AuthorizationView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        //    InitializeAuthView();
        }

        public AuthorizationView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
         //   InitializeAuthView();
        }

        public AuthorizationView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
         //   InitializeAuthView();
        }

        protected AuthorizationView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public string LoginLabelTxt { set => _loginLabelTxt.Text = value; }
        public string LoginButtonTxt { set => _loginButton.Text = value; }
        public string PasswordLabelTxt { set => _passwordLabelTxt.Text = value; }
        public string SignUpBtnTxt { set => _signUpBtn.Text = value; }

        public event Action<string, string> OnLoginBtnPressed;
        public event Action OnSignUpBtnPressed;
        public event Action<string> OnLocaleChanged;

        public void SetStyle(int[] rgbaForBackground, int[] rgbaTextColor)
        {
            throw new NotImplementedException();
        }

        public void ShowErrorMessage(string message)
        {
            Toast.MakeText(this.Context, message, ToastLength.Long).Show();
        }


        public void InitializeAuthView()
        {
            
            _loginLabelTxt= FindViewById<TextView>(Resource.Id.loginLabelTxt);
           
            _loginButton = FindViewById<Button>(Resource.Id.authBtn);
            _loginButton.Click += OnLoginBtnClicked;
           
            _passwordLabelTxt= FindViewById<TextView>(Resource.Id.passwordLabelTxt);
            
            _signUpBtn = FindViewById<Button>(Resource.Id.registerBtn);
            _signUpBtn.Click += OnSignUpBtnClicked;
            
            _loginField = FindViewById<EditText>(Resource.Id.loginField);
           
            _passwordField=FindViewById<EditText>(Resource.Id.passwordField);
           
            _langSwitch = FindViewById<Switch>(Resource.Id.langSwitch);         
            _langSwitch.CheckedChange += OnLangSwitchChecked;
            
    }


        private void OnLoginBtnClicked(object sender, EventArgs e)
        {
            OnLoginBtnPressed?.Invoke(_loginField.Text,_passwordField.Text);
        }

        private void OnSignUpBtnClicked(object sender, EventArgs e)
        {
            OnSignUpBtnPressed?.Invoke();
        }


        private void OnLangSwitchChecked(object sender, EventArgs e)
        {

            //поменять в интерфейсе экшн на булл значение и скорректировать презентер соответственно
            //убрать логику обработки состояния свича из вью
            string localeName = _langSwitch.Checked ? "RU" : "EN";

            OnLocaleChanged?.Invoke(localeName);
            
        }


    }
}