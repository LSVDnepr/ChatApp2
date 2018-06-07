using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.AuthModule
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
        //string PasswordButtonTxt { set; }
        string SignUpBtnTxt { set; }
        void ShowErrorMessage(string message); //, может, сеттить напрямую хинт в эдит текст??
        //void SetStyle(int[] rgbaForBackground, int[] rgbaTextColor );
        // void SetStyle(string hexBackgroundColor, string hexTextColor);
        //void SetStyle(int[] backgroundColorRGB, int[] textColorRGB)!!!


    }
}
