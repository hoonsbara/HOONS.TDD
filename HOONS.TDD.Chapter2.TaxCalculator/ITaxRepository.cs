using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HOONS.TDD.Chapter2.TaxCalculator
{
    public interface ITaxRepository
    {
        int GetTaxRate(TaxYear taxYear);
    }
}