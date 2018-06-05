using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.AuthModule
{
    public interface IAuthInteractor
    {

        void OnLogin(string login, string password);
        void OnSignUp(string login, string password, string title);

    }
}
