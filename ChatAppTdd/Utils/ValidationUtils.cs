using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.Utils
{
    public static class ValidationUtils
    {
        public static bool ValidateLogin(string login)
        {

            //Login validation criteria
            //(min length = 6, max = 128 chars, A-Z, a-z,0-9-_)

            throw new NotImplementedException();
          //  return true;
        }

        public static bool ValidatePassword(string password)
        {

            //Password validation criteria min length = 2!!! not 1
            //(min length = 2, max = 50 chars, 
            //Any + digits apostrophe('), grave accent(`), hyphen(-), dash(–), numbers
            //Password must contains at least one letter and digit.
            throw new NotImplementedException();
            //  return true;
        }

        public static bool ValidateTitle(string title)
        {

            //Title validation criteria
            //(min length = 6, max = 128 chars, 
            //не должно начинаться с цифры A-Z,a-z,0-9,_ ,whitespace, -

            throw new NotImplementedException();
            //  return true;
        }


        public static bool ValidateUserId(string userId)
        {
            //   ид юзера(string, сожержит только цифры)


            //Title validation criteria
            //(min length = 6, max = 128 chars, 
            //не должно начинаться с цифры A-Z,a-z,0-9,_ ,whitespace, -

            throw new NotImplementedException();
            //  return true;
        }


        public static bool ValidatSessionId(string sessionId)
        {
            //ид сессии(string 14 содержит a-z,0-9)


            throw new NotImplementedException();
            //  return true;
        }



       

    }
}
