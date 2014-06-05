using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOONS.TDD.Chapter3.SOLID.SingleReponsibility
{
class Customer_BanExample
{
    public void Add()
    {
        try
        {
            // 어떤 코드
        }
        catch (Exception ex)
        {
            System.IO.File.WriteAllText(@"c:\Error.txt", ex.ToString());
        }
    }
}

class FileLogger
{
    public void Handle(string error)
    {
        System.IO.File.WriteAllText(@"c:\Error.txt", error);
    }
}
    

class Customer
{
    private FileLogger obj = new FileLogger();
    public virtual void Add()
    {
        try
        {
            // Database code goes here
        }
        catch (Exception ex)
        {
            obj.Handle(ex.ToString());
        }
    }
}
}
