using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.AuthModule
{
    public enum SignUpFailType
    {
        LoginWrongFormat, LoginExists, PasswordWrongFormat, TitleWrongFormat, Error
    }

    public static class SignUpFailReason
    {
        private static Dictionary<SignUpFailType, ErrorTexts> _errors = new Dictionary<SignUpFailType, ErrorTexts>();

        static SignUpFailReason()
        {
            _errors.Add(SignUpFailType.LoginExists, new ErrorTexts("Указанный логин уже существует", "Login already exists"));
            _errors.Add(SignUpFailType.LoginWrongFormat, new ErrorTexts("", ""));          
            _errors.Add(SignUpFailType.PasswordWrongFormat, new ErrorTexts("", ""));
            _errors.Add(SignUpFailType.TitleWrongFormat, new ErrorTexts("", ""));
            _errors.Add(SignUpFailType.Error, new ErrorTexts("Ошибка. Повторите позже", "Error. Try again later"));
        }

        public static string GetText(SignUpFailType type, LocalesSupported locale)
        {
            ErrorTexts error;
            _errors.TryGetValue(type, out error);
            if (error == null) _errors.TryGetValue(SignUpFailType.Error, out error);
            return error.GetText(locale);
        }
    }
}
