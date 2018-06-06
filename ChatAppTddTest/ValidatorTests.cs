using System;
using NUnit.Framework;
using Moq;
using ChatAppTdd.Utils;

namespace ChatAppTddTest
{
    [TestFixture]
    public class ValidatorTests
    {
        //=============================================================================================
        //LOGIN VALIDATION TESTS
        [Test]
        public void ValidateLoginNullArgTest()
        {
            Assert.Throws<ArgumentNullException>(() => ValidationUtils.ValidateLogin(null));

        }

        /*
        min length = 6, 
        max = 128 chars,
         A-Z, a-z,0-9-_
         */
        [TestCase("", ExpectedResult=false)]//less than minLength=6
        [TestCase("login", ExpectedResult = false)]//less than minLength=6
        [TestCase("логин", ExpectedResult = false)]//less than minLength=6
        [TestCase("thisIsReallyLongLoginForTestingIfInteractorValidatesLoginMaximumLengthAccordingToProvidedBusinessRequirementsAndReturnsCorrectErrorInResponse", ExpectedResult = false)] //longer than maxLength=128
        [TestCase("МойLogin", ExpectedResult = false)]//contains forbidden chars
        [TestCase("&myLogin", ExpectedResult = false)]//contains forbidden chars
        [TestCase("myLogin$", ExpectedResult = false)]//contains forbidden chars
        [TestCase("my'login1", ExpectedResult = false)] //contains forbidden chars
        [TestCase("my login", ExpectedResult = false)] //contains forbidden chars
        public bool ValidateNotCorrectLoginTest(string login)
        {
            return ValidationUtils.ValidateLogin(login);

        }


        [TestCase("login_1", ExpectedResult = true)]
        [TestCase("-login_1", ExpectedResult = true)]
        [TestCase("LOGin25",ExpectedResult = true)]     
        [TestCase("12374_-7541", ExpectedResult = true)]
        public bool ValidateCorrectLoginTest(string login)
        {
            return ValidationUtils.ValidateLogin(login);

        }


        //=============================================================================================
        //PASSWORD VALIDATION TESTS
       
        [Test]
        public void ValidatePasswordNullArgTest()
        {
            Assert.Throws<ArgumentNullException>(() => ValidationUtils.ValidatePassword(null));

        }


        [TestCase("", ExpectedResult = false)] //less than min length=6
        [TestCase("pas", ExpectedResult = false)] //less than min length=6
        [TestCase("123pw", ExpectedResult = false)]//less than min length=6
        [TestCase("password", ExpectedResult = false)]//doesn't contain at least one digit
        [TestCase("пароль", ExpectedResult = false)]//doesn't contain at least one digit
        [TestCase("789456123", ExpectedResult = false)]//doesn't contain at least one letter
        [TestCase("#$%&^*!", ExpectedResult = false)]//doesn't contain at least one letter and one digit
        [TestCase("thisIsReallyLongPasswordForTestingIfInteractorValidatesPasswordMaximumLengthAccordingToProvidedBusinessRequirementsAndReturnsCorrectErrorInResponse", ExpectedResult = false)]//longer than max length
        public bool ValidateNotCorrectPasswordTest(string password)
        {
            return ValidationUtils.ValidatePassword(password);

        }


        [TestCase("password1", ExpectedResult = true)]
        [TestCase("p1234567", ExpectedResult = true)]
        [TestCase("p1234567", ExpectedResult = true)]
        [TestCase("пароль12", ExpectedResult = true)]
        [TestCase("psw%^123", ExpectedResult = true)]
        [TestCase("&psw123", ExpectedResult = true)]
        [TestCase("psw123%", ExpectedResult = true)]
        [TestCase("a#$%&^*!7", ExpectedResult = true)]
        public bool ValidateCorrectPasswordTest(string password)
        {
            return ValidationUtils.ValidatePassword(password);

        }



        //=============================================================================================
        //SESSION ID VALIDATION TESTS


        [Test]
        public void ValidateSessionIdNullArgTest()
        {
            Assert.Throws<ArgumentNullException>(() => ValidationUtils.ValidateSessionId(null));
        }


        [TestCase("", ExpectedResult = false)]//less than min length
        [TestCase("abcd", ExpectedResult = false)]//less than min length
        [TestCase("идСессии", ExpectedResult = false)]//less than min length
        [TestCase("6123456", ExpectedResult = false)]//less than min length
        [TestCase("qwertySessionIdToolong", ExpectedResult = false)]//longer than max length
        [TestCase("qwertyИдСессииToolong", ExpectedResult = false)]//longer than max length
        [TestCase("123456789123456789", ExpectedResult = false)]//longer than max length
        [TestCase("иднарусском123", ExpectedResult = false)]//forbidden chars
        public bool ValidateNotCorrectSessionIdTest(string sessionId)
        {
            return ValidationUtils.ValidateSessionId(sessionId);

        }

        

        [TestCase("validSessionId", ExpectedResult = true)]
        [TestCase("valid1234567Id", ExpectedResult = true)]
        [TestCase("12345678901234", ExpectedResult = true)]
        public bool ValidateCorrectSessionIdTest(string sessionId)
        {
            return ValidationUtils.ValidateSessionId(sessionId);

        }

        //=============================================================================================
        //TITLE VALIDATION TESTS

        [Test]
        public void ValidateTitleNullArgTest()
        {
            Assert.Throws<ArgumentNullException>(() => ValidationUtils.ValidateTitle(null));
        }


        [TestCase("", ExpectedResult = false)]//less than min length
        [TestCase("testingIfTitleIsLongerThanMaximumLengthAllowedInBusinessRequirements", ExpectedResult = false)]//longer than max length
        [TestCase("'notValid1234", ExpectedResult = false)] //Special symbol is the first char (apostrophe('))
        [TestCase("notValid'", ExpectedResult = false)] //Special symbol is the last char (apostrophe('))  
        [TestCase("`notValid1234", ExpectedResult = false)] //Special symbol is the first char (grave accent(`))
        [TestCase("notValid`", ExpectedResult = false)] //Special symbol is the last char (grave accent(`))
        [TestCase("-notValid1234", ExpectedResult = false)] //Special symbol is the first char (hyphen(-))
        [TestCase("notValid-", ExpectedResult = false)] //Special symbol is the last char (hyphen(-))
        [TestCase("–stillNotValid", ExpectedResult = false)]//Special symbol is the first char (dash(–))
        [TestCase("stillNotValid–", ExpectedResult = false)] //Special symbol is the last char (dash(–))
        [TestCase("7notValid", ExpectedResult = false)] //Special symbol is the first char (number)
        [TestCase("notValid1234", ExpectedResult = false)] //Special symbol is the last char (number)
        [TestCase("123456789", ExpectedResult = false)]  //Special symbol is the first and the last char (number)
        public bool ValidateNotCorrectTitleTest(string title)
        {
            return ValidationUtils.ValidateTitle(title);

        }


        [TestCase("m123456789t",ExpectedResult = true)]
        [TestCase("title'isValid", ExpectedResult = true)]
        [TestCase("title-isValid", ExpectedResult = true)]
        [TestCase("title123456isValid", ExpectedResult = true)]
        [TestCase("titleisValid", ExpectedResult = true)]
        [TestCase("title`isValid", ExpectedResult = true)]
        [TestCase("Valid-title", ExpectedResult = true)]
        [TestCase("title–isValid", ExpectedResult = true)]
        [TestCase("имяНаРусскомValid", ExpectedResult = true)]
        [TestCase("имя`На-Русском'Is–Valid", ExpectedResult = true)]
        public bool ValidateCorrectTitleTest(string title)
        {
            return ValidationUtils.ValidateLogin(title);

        }


        //=============================================================================================
        //USER ID VALIDATION TESTS
        /*
         minlength=8
         maxLengh=10
         string, contains digits only
         */

        [Test]
        public void ValidateUserIdNullArgTest()
        {
            Assert.Throws<ArgumentNullException>(() => ValidationUtils.ValidateUserId(null));
        }

        [TestCase("", ExpectedResult = false)] //less than min length
        [TestCase("abcd", ExpectedResult = false)] //less than min length
        [TestCase("abcd1234545", ExpectedResult = false)] //longer than max length
        [TestCase("1234567890", ExpectedResult = false)] //longer than max length
        [TestCase("qwertyid", ExpectedResult = false)] //contains forbidden chars
        [TestCase("1234abcd", ExpectedResult = false)] //contains forbidden chars
        public bool ValidateNotCorrectUserIdTest(string userId)
        {
            return ValidationUtils.ValidateTitle(userId);

        }


        [TestCase("123456", ExpectedResult = true)]
        [TestCase("0127177", ExpectedResult = true)]
        [TestCase("01272339", ExpectedResult = true)]
        public bool ValidateCorrectUserIdTest(string userId)
        {
            return ValidationUtils.ValidateTitle(userId);

        }



    }
}
