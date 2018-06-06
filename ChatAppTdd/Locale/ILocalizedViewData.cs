using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.AuthModule
{
    public interface ILocalizedViewData
    {
        string LoginText { get; }
        string PasswordText { get; }
        string LogInBtnText { get; }
        string SignUpBtnText { get; }
    }
}
