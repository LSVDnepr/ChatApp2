using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.Utils
{
    public class ValidationWorker : IValidationWorker
    {
        //private static readonly int _loginMinLength;

        public ValidationWorker()
        {
        }

        //валидировать с помощью регулярных выражений???

        public bool ValidateLogin(string login)
        {
            if (login==null)
            {
                throw new ArgumentNullException("Passed login argument is null! Recheck!");
            }
            string checkLogin = login.Trim();
           
            int minLength = 6;
            int maxLength = 128;
            // char[] specialChars = new char[] { '-', '_' };
            string specialChars = "-_";

            if (checkLogin.Length<minLength||checkLogin.Length>maxLength)
            {
                Console.WriteLine("Failed On checkLogin.Length<minLength||checkLogin.Length>maxLength");
                return false;
            }

            foreach(var ch in checkLogin)
            {

                if ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || Char.IsDigit(ch)|| specialChars.IndexOf(ch) != -1)
                {
                    continue;
                }
                Console.WriteLine("Failed On char ch="+ch+ " ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || specialChars.IndexOf(ch) != -1)");
                return false;
            }

            /*
              min length = 6, 
              max = 128 chars,
              A-Z, a-z,0-9-_
            */
            return true;


        }

        public bool ValidatePassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("Passed password argument is null! Recheck!");
            }
            string checkPass = password.Trim();
           

            /*
           min length=6
           maxLength=128
           Any+digits(Допускаются буквы любого языка+цифры) 
           Special Symbols
           Any
           Password must contains at least one letter and digit.
            */

            int minLength = 6;
            int maxLength = 128;

            int digitsCalc = 0;
            int lettersCalc = 0;

            if (checkPass.Length<minLength||checkPass.Length>maxLength)
            {
                Console.WriteLine("Failed on checkPass.Length<minLength||checkPass.Length>maxLength");
                return false;
            }

            foreach(var ch in checkPass)
            {
                if (Char.IsLetter(ch))
                {
                    lettersCalc++;
                }

                if (Char.IsDigit(ch))
                {
                    digitsCalc++;
                }

            }

            if (lettersCalc==0||digitsCalc==0)
            {
                Console.WriteLine("letters calc = " + lettersCalc);
                Console.WriteLine("digits calc = " + digitsCalc);
                return false;
            }
           
            return true;

        }


        //ид сессии(string 14 содержит A-Z, a-z,0-9)
        public bool ValidateSessionId(string sessionId)
        {
            if (sessionId == null)
            {
                throw new ArgumentNullException("Passed sessionId argument is null! Recheck!");
            }

            string checkSessionId = sessionId.Trim();

            int sessionIdLength = 14;
            if (sessionId.Length !=sessionIdLength)

            {
                return false;
            }

            foreach(var ch in sessionId)
            {
               if((ch<'A'||ch>'Z')&&(!Char.IsDigit(ch)&&((ch < 'a' || ch > 'z'))))
                {
                    return false;
                }
            }
            

            return true;

        }

        public bool ValidateTitle(string title)
        {
            if (title == null)
            {
                throw new ArgumentNullException("Passed title argument is null! Recheck!");
            }

            string checkTitle = title.Trim();

            int minLength = 1;
            int maxLength = 50;

            if (title.Length < minLength || title.Length > maxLength)
            {
                return false;
            }

            //  char[] specialChars = new char[] { '\'', '`', '-', '–' };
            string specialChars = "\'-`–";
            /*
        min length=1
        max length=50

        Language: 
        Any+digits(Допускаются буквы любого языка+цифры) 
        Special Symbols
        apostrophe('), grave accent(`), hyphen(-), dash(–), numbers

        Правила:
        For both text fields use trim();
        Special symbols, provided that it is not the first or last character. Нельзя. чтобы первым или последним символом была цифра???
            */
            if (specialChars.IndexOf(checkTitle[0])!=-1|| Char.IsDigit(checkTitle[0]))
            {

                Console.WriteLine("Failed on first char");
                return false;
            }

            if (specialChars.IndexOf(checkTitle[checkTitle.Length-1]) != -1 || Char.IsDigit(checkTitle[checkTitle.Length-1]))
            {
                Console.WriteLine("Failed on last char");
                return false;
            }

            foreach(var ch in checkTitle)
            {
                if (!Char.IsLetter(ch) && !Char.IsDigit(ch) && specialChars.IndexOf(ch)==-1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool ValidateUserId(string userId)
        {
            /*
           minlength=8
           maxLengh=10
           ид юзера(string, содержит только цифры)
           */
            int minLength = 8;
            int maxLengh = 10;
            
            if (userId == null)
            {
                throw new ArgumentNullException("Passed userId argument is null! Recheck!");
            }
            string checkUserId = userId.Trim();
            if (checkUserId.Length<minLength||checkUserId.Length>maxLengh)
            {
                Console.WriteLine("id length=" + checkUserId.Length);
                return false;
            }

            foreach (var ch in userId)
            {
               if (!Char.IsDigit(ch))
                {
                    Console.WriteLine("char " + ch + "Is not a digit");
                    return false;
                }
            }


            return true;
           


        }


    }
}
