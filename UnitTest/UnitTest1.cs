using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Video_Rental_A;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try {
                Form1 obj = new Form1();
                obj.ClearAll();
            }
            catch(Exception e)
            {
                StringAssert.Contains(e.Message, "Code have some kind of error");

            }

            
        }
    }
}
  