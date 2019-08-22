using Microsoft.VisualStudio.TestTools.UnitTesting;
using Video_Rental_A;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Rental_A.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Form1 obj = new Form1();

            Connection obj1 = new Connection();
          
            obj1.InsDelUpdt("Delete from Video where id=0");


        }

        [TestMethod]
        public void TestMethod2()
        {
            Form1 obj = new Form1();
            Connection obj1 = new Connection();
            obj1.InsDelUpdt("Delete from Video where Id=0");


        }

    }
}