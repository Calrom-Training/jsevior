// <copyright file="MethodUnitTesting.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace APItesting
{
    using API_template;
    using API_template.Classes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for API_Template methods.
    /// </summary>
    [TestClass]
    public class MethodUnitTesting
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodUnitTesting"/> class. this is an overloaded constructor of the DBconnection object, which allows it to access the database from a different directory.
        /// If this is on a different pc to the original, plase change the path to match your local system.
        /// </summary>
        public MethodUnitTesting()
        {
            this.Db = new DBconnection(@"C:\\Users\\Jamie\\source\\repos\\Calrom-Training\\jsevior\\API template\\API template/sqlite_database/firstuser.db");
        }

        private DBconnection Db { get; }

        /// <summary>
        /// test for the PasswordChecker method.
        /// </summary>
        [TestMethod]
        public void PasswordCheckerTestTrue()
        {
            string var1 = "testpassword";
            string var2 = "testpassword";
            bool result = this.Db.Password_Checker(var1, var2);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// test for the PasswordChecker method.
        /// </summary>
        [TestMethod]
        public void PasswordCheckerFalseTrue()
        {
            string var1 = "testpassword";
            string var2 = "testpassword1";
            bool result = this.Db.Password_Checker(var1, var2);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Test for the LogOnAttempt method.
        /// </summary>
        [TestMethod]
        public void LogonAttemptTester()
        {
            User testuser = new User();
            testuser.UserId = 0;
            testuser.Username = "testuser";
            testuser.Password = "testpassword";
            testuser.IsSuccess = true;
            var testresult = this.Db.LogOnAttempt(testuser);
            Assert.AreEqual(testuser.Username, testresult.Username);
            Assert.AreEqual(testuser.Password, testresult.Password);
            Assert.AreEqual(testuser.UserId, testresult.UserId);
        }

        /// <summary>
        /// Test for the LogOnAttempt method.
        /// </summary>
        [TestMethod]
        public void LogonAttemptFalseTester()
        {
            User testuser = new User();
            testuser.UserId = 4;
            testuser.Username = "testuser";
            testuser.Password = "testpassword1";
            testuser.IsSuccess = false;
            var testresult = this.Db.LogOnAttempt(testuser);
            Assert.AreEqual(testuser.Username, testresult.Username);
            Assert.AreNotEqual(testuser.Password, testresult.Password);
            Assert.AreNotEqual(testuser.UserId, testresult.UserId);
        }

        /// <summary>
        /// test for the GetMessages method.
        /// </summary>
        [TestMethod]
        public void GetMessagesTester()
        {
            UserMessages testmessage = new UserMessages();
            testmessage.IsSuccess = true;
            var testresult = this.Db.GetMessages(0);
            Assert.AreEqual(testmessage.IsSuccess, testresult.IsSuccess);
        }

        /// <summary>
        /// test for the GetMessages method.
        /// </summary>
        [TestMethod]
        public void GetMessagesFalseTester()
        {
            UserMessages testmessage = new UserMessages();
            testmessage.IsSuccess = true;
            var testresult = this.Db.GetMessages(5);
            Assert.AreNotEqual(testmessage.IsSuccess, testresult.IsSuccess);
        }
    }
}
