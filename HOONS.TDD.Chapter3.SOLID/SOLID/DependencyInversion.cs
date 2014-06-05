using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOONS.TDD.Chapter3.SOLID.DependencyInversion
{
    public interface ILogger
    {
        void Handle(string error);
    }

    public class LoggerFactory
    {
        public static ILogger GetLogger(string environment)
        {
            if (environment == "Web")
            {
                return new DBLogger();
            }
            else
            {
                return new FileLogger();
            }
        }
    }

    public class FileLogger : ILogger
    {
        public void Handle(string error)
        {
            System.IO.File.WriteAllText(@"c:\Error.txt", error);
        }
    }

    public class DBLogger : ILogger
    {
        public void Handle(string error)
        {
            System.IO.File.WriteAllText(@"c:\Error.txt", error);
        }
    }

    public class Customer
    {
        private readonly ILogger _obj;

        public Customer(string environment)
        {
            _obj = LoggerFactory.GetLogger(environment);
        }

        public Customer(ILogger obj)
        {
            _obj = obj;
        }

        public virtual void Add()
        {
            try
            {
                //Some codes
            }
            catch (Exception ex)
            {
                _obj.Handle(ex.ToString());
            }
        }
    }
}