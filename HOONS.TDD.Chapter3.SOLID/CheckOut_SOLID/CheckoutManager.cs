using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOONS.TDD.Chapter3.SOLID.CheckOut
{
public interface IPriceRepository
{
    decimal GetPrice(string code);
}

public interface IDiscountManager
{
    decimal GetDiscount(string code, decimal price);
}

public class DiscountManager : IDiscountManager
{
    private Dictionary<string, int> _itemCountList = new Dictionary<string, int>();

    public decimal GetDiscount(string code, decimal price)
    {
        if (!_itemCountList.ContainsKey(code))
        {
            _itemCountList.Add(code, 1);
        }
        //3번째는 무료 아이템
        if (_itemCountList[code] == 3)
        {
            _itemCountList[code] = 0;
            return price;
        }
        return 0;
    }
}

public class PriceRepository : IPriceRepository
{
    public decimal GetPrice(string code)
    {
        //From Database
        return 40.0m;
    }
}

public class CheckoutManager
{
    private readonly IPriceRepository _priceRepo;
    private readonly IDiscountManager _disManager;

    public CheckoutManager(IPriceRepository priceRepo, IDiscountManager disManager)
    {
        this._priceRepo = priceRepo;
        this._disManager = disManager;
    }

    private decimal _total;

    public decimal Total
    {
        get { return _total; }
    }

    public void ScanAll(List<string> items)
    {
        foreach (var code in items)
        {
            //구매
            decimal price = _priceRepo.GetPrice(code);
            _total += price;
            //할인 적용
            _total += _disManager.GetDiscount(code, price);

        }
    }
}
}