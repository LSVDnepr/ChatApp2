using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.AuthModule
{

    public interface IAuthView
    {
        event Action<string, string> OnLoginBtnPressed;
        event Action<string,string,string> OnSignUpBtnPressed;
        // event Action<LocalesSupported> OnLocaleChanged;
        event Action OnLocaleChanged;


        void SetLocalizedData(ILocalizedViewData localeData);
        void ShowErrorMessage(string message);

        string GetCurrentLocale();



    }
}
