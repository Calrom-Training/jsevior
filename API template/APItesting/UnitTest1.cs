using Microsoft.VisualStudio.TestTools.UnitTesting;
using API_template;
namespace APItesting
{
    [TestClass]
    public class UnitTest1
    {
        

        public static bool Password_Checker(string fromUI, string fromDB)
        {
            bool result = false;
            if (fromDB == fromUI)
            {
                result = true;
            }

            return result;
        }

        [TestMethod]
        public void PasswordCheckerTestTrue()
        {
            string var1 = "testpassword";
            string var2 = "testpassword";
            bool result = Password_Checker(var1, var2);
            Assert.IsTrue(result);
        }
    }
}
