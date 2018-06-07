using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.AuthModule2
{
    public interface IAuthView
    {
        event Action<string, string> OnLoginBtnPressed;
        event Action OnSignUpBtnPressed;
        event Action<string> OnLocaleChanged;
        // event Action ViewWillBeShown;

        string LoginLabelTxt{ set; }
        string LoginButtonTxt { set; }
        string PasswordLabelTxt { set; }
        string PasswordButtonTxt { set; }

        void ShowErrorMessage(string message);


       
    }
}
