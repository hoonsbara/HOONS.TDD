using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOONS.TDD.Chapter3.SOLID.LiskovSubstitution
{

public interface IDiscount
{
    double GetDiscount(double totalSales);
}

public interface ISpecialService
{
    void SetSpecialService(string order);
}


public class Customer : IDiscount
{
    public virtual double GetDiscount(double totalSales)
    {
        return totalSales;
    }
}
public class SilverCustomer : Customer, ISpecialService
{
    public override double GetDiscount(double totalSales)
    {
        return base.GetDiscount(totalSales) - 50;
    }
    public virtual void SetSpecialService(string order)
    {
        //Save to Database
    }
}

public class GoldCustomer : SilverCustomer
{
    public override double GetDiscount(double totalSales)
    {
        return base.GetDiscount(totalSales) - 100;
    }
    public override void SetSpecialService(string order)
    {
        

    }
}



}
