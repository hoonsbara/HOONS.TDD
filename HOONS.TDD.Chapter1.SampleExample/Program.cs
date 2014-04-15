using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOONS.TDD.Chapter1.SampleExample
{

    class Program
    {
        static void Main(string[] args)
        {
            var mCal = new MultipleCalculator();
            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine(mCal.Calculate(i));
            }
        }
    }

    public class MultipleCalculator
    {
        public string Calculate(int i)
        {
            if (i % 3 == 0 && i % 5 == 0)
                return "Joel Sarah";
            else if (i % 3 == 0)
                return "Joel";
            else if (i % 7 == 0)
                return "Noah";
            else if (i % 5 == 0)
                return "Sarah";
            else
                return i.ToString();
        }
    }
}
