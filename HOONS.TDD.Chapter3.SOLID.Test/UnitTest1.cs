using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HOONS.TDD.Chapter3.SOLID.LiskovSubstitution;

namespace HOONS.TDD.Chapter3.SOLID.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Save to Database
            List<Customer> customers = new List<Customer>();
            customers.Add(new SilverCustomer());
            customers.Add(new GoldCustomer());
            customers.Add(new Customer());

            foreach (Customer c in customers)
            {
                if (typeof (ISpecialService).IsAssignableFrom(c.GetType()))
                {
                    (c as ISpecialService).SetSpecialService("");
                }
            }
        }
    }
}
