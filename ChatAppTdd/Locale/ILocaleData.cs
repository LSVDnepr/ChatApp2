using System;
using System.Collections.Generic;
using System.Text;
using ChatAppTdd.AuthModule;
using ChatAppTdd.Locale;

namespace ChatAppTdd
{
    public interface ILocaleData
    {
        string LoginText { get; }
        string PasswordText { get; }
        string LogInBtnText { get; }
        string SignUpBtnText { get; }

        string GetErrorText(SignUpFailType err);
        string GetErrorText(LoginFailType err);

    }
}
