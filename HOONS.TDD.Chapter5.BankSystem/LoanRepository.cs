using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HOONS.TDD.Chapter5.BankSystem
{
    public class LoanRepository
    {
        public LoanRepository()
        {
            _rate = 1.5m;
        }

        static private decimal _rate;
        public decimal GetLoanBySalary(decimal salary)
        {
            //db에 접속한다고 가정
            return salary * _rate;
        }
    }
}
