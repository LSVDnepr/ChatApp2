using System;
using System.Collections.Generic;
using System.Text;
using ChatAppTdd.AuthModule;

namespace ChatAppTdd.Locale
{
    public class LocaleDataEn : ILocaleData
    {
        public string LoginText => "Login";

        public string PasswordText => "Password";

        public string LogInBtnText => "Login";

        public string SignUpBtnText => "Sign up";

        private Dictionary<SignUpFailType, string> _SingUpErrors = new Dictionary<SignUpFailType, string>();
        private Dictionary<LoginFailType, string> _LoginErrors = new Dictionary<LoginFailType, string>();

        public LocaleDataEn()
        {
            //SingUpErrors
            _SingUpErrors.Add(SignUpFailType.LoginExists, "Login already exists");
            _SingUpErrors.Add(SignUpFailType.LoginWrongFormat, "Wrong login format");
            _SingUpErrors.Add(SignUpFailType.PasswordWrongFormat, "Wrong password format");
            _SingUpErrors.Add(SignUpFailType.TitleWrongFormat, "Wrong title format");
            _SingUpErrors.Add(SignUpFailType.Error, "Error. Try again later");
            //LoginErrors
            _LoginErrors.Add(LoginFailType.WrongLogin, "Login does not exist");
            _LoginErrors.Add(LoginFailType.WrongPassword, "Wrong password");
            _LoginErrors.Add(LoginFailType.NetworkError, "Network error");
            _LoginErrors.Add(LoginFailType.Error, "Error. Try again later");
        }

        public string GetErrorText(SignUpFailType type)
        {
            _SingUpErrors.TryGetValue(type, out string errorText);
            if (errorText == null) _SingUpErrors.TryGetValue(SignUpFailType.Error, out errorText);
            return errorText;
        }

        public string GetErrorText(LoginFailType type)
        {
            _LoginErrors.TryGetValue(type, out string errorText);
            if (errorText == null) _LoginErrors.TryGetValue(LoginFailType.Error, out errorText);
            return errorText;
        }

    }
}
