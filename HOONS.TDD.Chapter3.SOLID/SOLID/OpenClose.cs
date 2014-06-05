using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOONS.TDD.Chapter3.SOLID.OpenClose
{
    public enum CustomerType
    {
        Ordinary,
        Silver,
        Gold
    }

    public class Customer_Bad_Example
    {
        private readonly CustomerType _custType;

        public Customer_Bad_Example(CustomerType cType)
        {
            this._custType = cType;
        }

        public decimal GetDiscount(decimal totalSales)
        {
            if (_custType == CustomerType.Gold)
            {
                return totalSales - 100;
            }
            else if (_custType == CustomerType.Silver)
            {
                return totalSales - 50;
            }
            else
            {
                return totalSales;
            }
        }
    }

    public class Customer
    {
        public virtual double GetDiscount(double totalSales)
        {
            return totalSales;
        }
    }

    public class SilverCustomer : Customer
    {
        public override double GetDiscount(double totalSales)
        {
            return base.GetDiscount(totalSales) - 50;
        }
    }

    public class GoldCustomer : Customer
    {
        public override double GetDiscount(double totalSales)
        {
            return base.GetDiscount(totalSales) - 100;
        }
    }
}