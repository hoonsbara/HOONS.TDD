using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOONS.TDD.Chapter3.SOLID.InterfaceSegregation
{

public interface IDiscount
{
    double GetDiscount(double totalSales);
}
public interface ISpecialService
{
    void SetSpecialService(string order);
}
public class Customer
{
}
public class SilverCustomer : Customer, IDiscount, ISpecialService
{
    public double GetDiscount(double totalSales)
    {
        return totalSales - 50;
    }
    public void SetSpecialService(string order)
    {
        //Save to Database
    }
}
public class GoldCustomer : Customer,IDiscount, ISpecialService
{
    public double GetDiscount(double totalSales)
    {
        return totalSales - 100;
    }
    public void SetSpecialService(string order)
    {
        //Save to Database
    }
}
}
