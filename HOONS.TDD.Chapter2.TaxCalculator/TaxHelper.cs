using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOONS.TDD.Chapter2.TaxCalculator
{
    public enum TaxYear
    {
        Year2013,
        Year2014
    }

    public class TaxHelper
    {
        private readonly TaxYear _taxYear;
        private readonly ITaxRepository _taxRepo;

        public TaxHelper(TaxYear taxYear, ITaxRepository taxRepo)
        {
            this._taxYear = taxYear;
            this._taxRepo = taxRepo;
        }

        public decimal Calculate(decimal salary)
        {
            int taxRate = _taxRepo.GetTaxRate(_taxYear);
            return salary*(100 - taxRate)/100;
        }
    }
}
