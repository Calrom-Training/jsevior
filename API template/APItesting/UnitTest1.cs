using Microsoft.VisualStudio.TestTools.UnitTesting;
using API_template;
namespace APItesting
{
    [TestClass]
    public class UnitTest1
    {
        DBconnection db = new DBconnection();

        [TestMethod]
        public void PasswordCheckerTestTrue()
        {
            string var1 = "testpassword";
            string var2 = "testpassword";
            bool result = db.Password_Checker(var1, var2);
            Assert.IsTrue(result);
        }
    }
}
