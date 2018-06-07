using System;
using System.Collections.Generic;
using System.Text;
using ChatAppTdd.AuthModule;

namespace ChatAppTdd.Locale
{
    public class LocaleStore : ILocaleStore
    {
        private ILocaleData _localeData = new LocaleDataEn();

        public void SetLocale(string localeCode)
        {
            if (localeCode.ToUpper().Equals("RU"))
            {
                _localeData = new LocaleDataRu();
                return;
            }
            if (localeCode.ToUpper().Equals("EN"))
            {
                _localeData = new LocaleDataEn();
                return;
            }
            throw new ArgumentException("Unknown locale code "+localeCode);
        }

        public string LoginText => _localeData.LoginText;

        public string PasswordText => _localeData.PasswordText;

        public string LogInBtnText => _localeData.LogInBtnText;

        public string SignUpBtnText => _localeData.SignUpBtnText;

        public string GetErrorText(SignUpFailType err)
        {
            return _localeData.GetErrorText(err);
        }

        public string GetErrorText(LoginFailType err)
        {
            return _localeData.GetErrorText(err);
        }

    }
}
