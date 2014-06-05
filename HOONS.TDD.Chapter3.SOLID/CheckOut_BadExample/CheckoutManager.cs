using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOONS.TDD.Chapter3.SOLID.CheckOut_BadExample
{
public class CheckoutManager
{
    private decimal _total;
    public decimal Total {
        get { return _total; }
        set { _total = value; }
    }

public void ScanAll(List<string> arrItems)
{
    var priceRepo =new PriceRepository();
    var dicItemCount =new Dictionary<string, int>();
    foreach (var code in arrItems)
    {
        //구매
        decimal price = priceRepo.GetPrice(code);
        _total += price;

        //2개 이상 살 경우 1개 무료 확인
        if (!dicItemCount.ContainsKey(code))
        {
            dicItemCount.Add(code,1);
        }

        //3번째는 무료 아이템
        if (dicItemCount[code] == 3)
        {
            dicItemCount[code] = 0;
            _total -= price;
        }
    }
}
}


    public class PriceRepository
{
    public decimal GetPrice(string code)
    {
        //From Database
        return 40.0m;
    }
}
}
