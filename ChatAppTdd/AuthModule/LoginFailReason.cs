using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.AuthModule
{
    public enum LoginFailType
    {
        WrongLogin, WrongPassword, NetworkError, Error
    }

    public static class LoginFailReason
    {
        private static Dictionary<LoginFailType, ErrorTexts> _errors = new Dictionary<LoginFailType, ErrorTexts>();

        static LoginFailReason() {
            _errors.Add(LoginFailType.WrongLogin,new ErrorTexts("Указанный логин не существует","Login does not exist"));
            _errors.Add(LoginFailType.WrongPassword, new ErrorTexts("", ""));
            _errors.Add(LoginFailType.NetworkError, new ErrorTexts("", ""));
            _errors.Add(LoginFailType.Error, new ErrorTexts("Ошибка. Повторите позже", "Error. Try again later"));
        }

        public static string GetText(LoginFailType type, LocalesSupported locale)
        {
            ErrorTexts error;
            _errors.TryGetValue(type,out error);
            if (error==null) _errors.TryGetValue(LoginFailType.Error, out error);
            return error.GetText(locale);
        }
    }
}
