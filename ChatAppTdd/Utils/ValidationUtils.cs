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

            //Password validation criteria min length = 6
            //(min length = 6, max = 128 chars, 
           
             //Any + digits Any Password must contains at least one letter and digit.
          
            throw new NotImplementedException();
            //  return true;
        }

        public static bool ValidateTitle(string title)
        {

            //Title validation criteria
            //(min length = 1, max = 50 chars,          
            //Any + digits;
            //apostrophe('), grave accent(`), hyphen(-), dash(–), numbers
            //Special symbols, provided that it is not the first or last character.


            throw new NotImplementedException();
            //  return true;
        }


        public static bool ValidateUserId(string userId) //add minlength and maxLength constraint
        {
            //   ид юзера(string, содержит только цифры)

            throw new NotImplementedException();
            //  return true;
        }


        public static bool ValidateSessionId(string sessionId)
        {
            //ид сессии(string 14 содержит a-z,0-9)


            throw new NotImplementedException();
            //  return true;
        }



       

    }
}
