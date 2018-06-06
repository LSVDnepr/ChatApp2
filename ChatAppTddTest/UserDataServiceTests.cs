using System;
using NUnit.Framework;
using Moq;
using ChatAppTdd.Repository;
using ChatAppTdd.AuthModule;
using ChatAppTdd.Entities;

namespace ChatAppTddTest
{
    [TestFixture]
    public class UserDataServiceTests
    {
        [Test]
        public void AuthorizeUserLoginNullTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.AuthorizeUser(null, "123456"), Throws.ArgumentNullException);
        }

        [Test]
        public void AuthorizeUserPasswordNullTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.AuthorizeUser("login", null), Throws.ArgumentNullException);
        }

        [Test]
        public void AuthorizeUserLoginEmptyTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.AuthorizeUser("", "123456"), Throws.ArgumentException);
        }

        [Test]
        public void AuthorizeUserPasswordEmptyTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.AuthorizeUser("login", ""), Throws.ArgumentException);
        }


        [Test]
        public void AuthorizeUserLoginNotExistTest()
        {
            IUserDataService service = new UserDataService();
            try
            {
                service.AuthorizeUser("non existent login", "123456");
            } catch (ChatAuthException ex)
            {
                Assert.That(ex.LoginFailType,Is.EqualTo(LoginFailType.WrongLogin));
            }
            Assert.Fail("Exception LoginFailType.WrongLogin expected");
        }

        [Test]
        public void AuthorizeUserWrongPasswordTest()
        {
            IUserDataService service = new UserDataService();
            try
            {
                service.AuthorizeUser("login", "Bad password");
            }
            catch (ChatAuthException ex)
            {
                Assert.That(ex.LoginFailType, Is.EqualTo(LoginFailType.WrongPassword));
            }
            Assert.Fail("Exception LoginFailType.WrongPassword expected");
        }

        [Test]
        public void CheckLoginExistsLoginNullTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.CheckLoginExists(null), Throws.ArgumentNullException);
        }

        [Test]
        public void CheckLoginExistsLoginEmptyTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.CheckLoginExists(""), Throws.ArgumentException);
        }

        [Test]
        public void CheckLoginExistsPositiveTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.CheckLoginExists("login"), Is.EqualTo(true));
        }

        [Test]
        public void CheckLoginExistsNegativeTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.CheckLoginExists("nonexistent login"), Is.EqualTo(false));
        }

        [Test]
        public void GetUserDataNullTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.GetUserData(null), Throws.ArgumentNullException);
        }

        [Test]
        public void GetUserDataEmptyTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.GetUserData(""), Throws.ArgumentException);
        }

        [Test]
        public void GetUserDataPositiveTest()
        {
            IUserDataService service = new UserDataService();
            IUserData usrData=service.GetUserData(service.AuthorizeUser("login","password"));
            Assert.That(usrData, Is.Not.Null);
            Assert.That(usrData.SessionID, Is.Not.Null);
            Assert.That(usrData.Title, Is.Not.Null);
            Assert.That(usrData.UserID, Is.Not.Null);
        }
        [Test]
        public void GetUserDataNegativeTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.GetUserData("BadSession0123"), Throws.ArgumentException);
        }

        [Test]
        public void GetUserIdDataNullTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.GetUserIdBySessionId(null), Throws.ArgumentNullException);
        }

        [Test]
        public void GetUserIdDataEmptyTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.GetUserIdBySessionId(""), Throws.ArgumentException);
        }

        [Test]
        public void GetUserIdDataPositiveTest()
        {
            IUserDataService service = new UserDataService();
            string id = service.GetUserIdBySessionId(service.AuthorizeUser("login", "password"));
            Assert.That(id, Is.Not.Null);
        }
        [Test]
        public void GetUserIdDataNegativeTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.GetUserIdBySessionId("BadSession0123"), Throws.ArgumentException);
        }

        [Test]
        public void RegisterUserLoginNullTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.RegisterUser(null,"Password","Title"), Throws.ArgumentNullException);
        }
        [Test]
        public void RegisterUserPasswordNullTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.RegisterUser("Login", null, "Title"), Throws.ArgumentNullException);
        }
        [Test]
        public void RegisterUserTitleNullTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.RegisterUser("Login", "Password", null), Throws.ArgumentNullException);
        }

        [Test]
        public void RegisterUserLoginEmptyTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.RegisterUser("", "Password", "Title"), Throws.ArgumentException);
        }
        [Test]
        public void RegisterUserPasswordEmptyTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.RegisterUser("Login", "", "Title"), Throws.ArgumentException);
        }
        [Test]
        public void RegisterUserTitleEmptyTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.RegisterUser("Login", "Password", ""), Throws.ArgumentException);
        }

        [Test]
        public void RegisterUserAlreadyExistsTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.RegisterUser("Login", "Password", "Title"), Throws.ArgumentException);
        }

        [Test]
        public void RegisterUserDataPositiveTest()
        {
            IUserDataService service = new UserDataService();
            string login = ConvertToBase(DateTime.Today.Ticks,32);
            string pwd = ConvertToBase(DateTime.Today.Ticks, 32);
            string title = ConvertToBase(DateTime.Today.Ticks, 32);
            string id = service.RegisterUser(login, pwd,title);
            Assert.That(id, Is.Not.Null);
        }

        /*
                2.5. public string RegisterUser(string login, string password, string title)
                2.5.4. if args are not null=> if exists throws exception
                2.5.5. if args are not null=> if doesn't exist Generates and returns SessionId (check it's valid, check it's not null)
                 */
        public String ConvertToBase(long num, int nbase)
        {
            String chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // check if we can convert to another base
            if (nbase < 2 || nbase > chars.Length)
                return "";

            int r;
            String newNumber = "";

            // in r we have the offset of the char that was converted to the new base
            while (num >= nbase)
            {
                r = (int)num % nbase;
                newNumber = chars[r] + newNumber;
                num = num / nbase;
            }
            // the last number to convert
            newNumber = chars[(int)num] + newNumber;

            return newNumber;
        }
    }
}
