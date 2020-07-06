using Microsoft.VisualStudio.TestTools.UnitTesting;
using videoRentalProjectsx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoRentalProjectsx.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void countCustomerBookingTest()
        {
            
            Form1 obj=new Form1();
            int cost=obj.getMovieCost(1);
            if (cost > 0)
            {
                Assert.IsTrue(true);
            }
            else {
                Assert.IsTrue(false);
            }

        }

        [TestMethod()]
        public void countCustomerTest()
        {

            Form1 obj = new Form1();
            int cost = obj.countCustomerBooking(1);
            Assert.IsTrue(true);
        }


    }
}