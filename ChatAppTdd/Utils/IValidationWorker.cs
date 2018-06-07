using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.Utils
{
    public interface IValidationWorker
    {

    bool ValidateLogin(string login);
    bool ValidatePassword(string password);
    bool ValidateTitle(string title);
    bool ValidateUserId(string userId);
    bool ValidateSessionId(string sessionId);       

    }
}
