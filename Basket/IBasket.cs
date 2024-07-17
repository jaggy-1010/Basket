using static Basket.BasketBase;
namespace Basket;

public interface IBasket
{
    string CashierLogin { get; }

    Statistics GetStatistics();
    Statistics GetDailyStatistics();
    Statistics GetMonthlyStatistics();
    Statistics GetYearlyStatistics();
    void AddItemToBasket(double price);
    void AddItemToBasket(string price);
    void AddItemToBasket(int price);
    void AddItemToBasket(long price);
    void AddItemToBasket(decimal price);
}