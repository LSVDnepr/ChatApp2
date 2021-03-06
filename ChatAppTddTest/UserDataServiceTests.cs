﻿using System;
using NUnit.Framework;
using Moq;
using ChatAppTdd.Repository;
using ChatAppTdd.AuthModule;
using ChatAppTdd.Entities;
using ChatAppTdd.Locale;

namespace ChatAppTddTest
{
    [TestFixture]
    public class UserDataServiceTests
    {
        [Test]
        public void AuthorizeUserLoginNullTest()
        {
            IUserDataService service = new UserDataService();
            Assert.Throws<ArgumentNullException>(()=>service.AuthorizeUser(null, "123456", out LoginFailType code));
        }

        [Test]
        public void AuthorizeUserPasswordNullTest()
        {
            IUserDataService service = new UserDataService();
            Assert.Throws<ArgumentNullException>(() => service.AuthorizeUser("login", null, out LoginFailType code));
        }

        [Test]
        public void AuthorizeUserLoginEmptyTest()
        {
            IUserDataService service = new UserDataService();
            service.AuthorizeUser("", "123456", out LoginFailType code);
            Assert.That(code, Is.EqualTo(LoginFailType.Error));
        }

        [Test]
        public void AuthorizeUserPasswordEmptyTest()
        {
            IUserDataService service = new UserDataService();
            service.AuthorizeUser("login", "", out LoginFailType code);
            Assert.That(code, Is.EqualTo(LoginFailType.Error));
        }


        [Test]
        public void AuthorizeUserLoginNotExistTest()
        {
            IUserDataService service = new UserDataService();
            service.AuthorizeUser("non existend login", "password", out LoginFailType code);
            Assert.That(code,Is.EqualTo(LoginFailType.WrongLogin));
        }

        [Test]
        public void AuthorizeUserWrongPasswordTest()
        {
            IUserDataService service = new UserDataService();
            service.AuthorizeUser("login", "Bad password", out LoginFailType code);
            Assert.That(code, Is.EqualTo(LoginFailType.WrongPassword));
        }

        [Test]
        public void CheckLoginExistsLoginNullTest()
        {
            IUserDataService service = new UserDataService();
            Assert.Throws<ArgumentNullException>(()=>service.CheckLoginExists(null));
        }

        [Test]
        public void CheckLoginExistsLoginEmptyTest()
        {
            IUserDataService service = new UserDataService();
            Assert.Throws<ArgumentException>(()=>service.CheckLoginExists(""));
        }

        [Test]
        public void CheckLoginExistsPositiveTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.CheckLoginExists("login"), Is.True);
        }

        [Test]
        public void CheckLoginExistsNegativeTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.CheckLoginExists("nonexistent login"), Is.False);
        }

        [Test]
        public void GetUserDataNullTest()
        {
            IUserDataService service = new UserDataService();
            Assert.Throws<ArgumentNullException>(()=>service.GetUserData(null));
        }

        [Test]
        public void GetUserDataEmptyTest()
        {
            IUserDataService service = new UserDataService();
            Assert.Throws<ArgumentException>(()=>service.GetUserData(""));
        }

        [Test]
        public void GetUserDataPositiveTest()
        {
            IUserDataService service = new UserDataService();
            IUserData usrData=service.GetUserData(service.AuthorizeUser("login","password",out LoginFailType code));
            Assert.That(usrData, Is.Not.Null);
            Assert.That(usrData.SessionID, Is.Not.Null);
            Assert.That(usrData.Title, Is.Not.Null);
            Assert.That(usrData.UserID, Is.Not.Null);
        }


        [Test]
        public void GetUserDataNegativeTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.GetUserData("BadSession0123"), Is.Null);
        }

        [Test]
        public void GetUserIdDataNullTest()
        {
            IUserDataService service = new UserDataService();
            Assert.Throws<ArgumentNullException>(()=>service.GetUserIdBySessionId(null));
        }

        [Test]
        public void GetUserIdDataEmptyTest()
        {
            IUserDataService service = new UserDataService();
            Assert.Throws<ArgumentException>(()=>service.GetUserIdBySessionId(""));
        }

        [Test]
        public void GetUserIdDataPositiveTest()
        {
            IUserDataService service = new UserDataService();
            string id = service.GetUserIdBySessionId(service.AuthorizeUser("login", "password", out LoginFailType code));
            Assert.That(id, Is.Not.Null);
        }
        [Test]
        public void GetUserIdDataNegativeTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.GetUserIdBySessionId("BadSession0123"),Is.Null);
        }
        /*
        [Test]
        public void RegisterUserLoginNullTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.RegisterUser(null,"Password12","Title12"), Throws.ArgumentNullException);
        }
        [Test]
        public void RegisterUserPasswordNullTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.RegisterUser("Login12", null, "Title12"), Throws.ArgumentNullException);
        }
        [Test]
        public void RegisterUserTitleNullTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.RegisterUser("Login12", "Password12", null), Throws.ArgumentNullException);
        }

        [Test]
        public void RegisterUserLoginEmptyTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.RegisterUser("", "Password12", "Title12"), Throws.ArgumentException);
        }
        [Test]
        public void RegisterUserPasswordEmptyTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.RegisterUser("Login12", "", "Title12"), Throws.ArgumentException);
        }
        [Test]
        public void RegisterUserTitleEmptyTest()
        {
            IUserDataService service = new UserDataService();
            Assert.That(service.RegisterUser("Login12", "Password12", ""), Throws.ArgumentException);
        }

        [Test]
        public void RegisterUserAlreadyExistsTest()
        {
            IUserDataService service = new UserDataService();
            service.RegisterUser("Login12", "Password12", "Title12");
            try
            {
               service.RegisterUser("Login12", "Password12", "Title12");
            }catch (ChatSignUpException ex)
            {
                Assert.That(ex.SignUpFailType, Is.EqualTo(SignUpFailType.LoginExists));
            }
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
        */
        
        //        2.5. public string RegisterUser(string login, string password, string title)
        //        2.5.4. if args are not null=> if exists throws exception
        //        2.5.5. if args are not null=> if doesn't exist Generates and returns SessionId (check it's valid, check it's not null)
                 
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
