using System;
using System.Collections.Generic;
using System.Text;
using ChatAppTdd.AuthModule;

namespace ChatAppTdd.Locale
{
    public class LocaleDataRu : ILocaleData
    {
        public string LoginText => "Логин";

        public string PasswordText => "Пароль";

        public string LogInBtnText => "Авторизоваться";

        public string SignUpBtnText => "Зарегистрироваться";


        private Dictionary<SignUpFailType, string> _SingUpErrors = new Dictionary<SignUpFailType, string>();
        private Dictionary<LoginFailType, string> _LoginErrors = new Dictionary<LoginFailType, string>();

        public LocaleDataRu()
        {
            //SingUpErrors
            _SingUpErrors.Add(SignUpFailType.LoginExists, "Указанный логин уже существует");
            _SingUpErrors.Add(SignUpFailType.LoginWrongFormat,"");
            _SingUpErrors.Add(SignUpFailType.PasswordWrongFormat,"");
            _SingUpErrors.Add(SignUpFailType.TitleWrongFormat,"");
            _SingUpErrors.Add(SignUpFailType.Error,"Ошибка. Повторите позже");
            //LoginErrors
            _LoginErrors.Add(LoginFailType.WrongLogin, "Указанный логин не существует");
            _LoginErrors.Add(LoginFailType.WrongPassword,"");
            _LoginErrors.Add(LoginFailType.NetworkError,"");
            _LoginErrors.Add(LoginFailType.Error,"Ошибка. Повторите позже");
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
