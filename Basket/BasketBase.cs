namespace Basket;

public abstract class BasketBase //: IBasket
{
    public BasketBase (string cashierLogin)
    {
	this.CashierLogin = cashierLogin;
    }

    public string CashierLogin { get; private set; }

    public abstract Statistics GetStatistics();
    public abstract void AddItemToBasket(double price);
    public abstract void AddItemToBasket(string price);
    public abstract void AddItemToBasket(int price);
    public abstract void AddItemToBasket(long price);
    public abstract void AddItemToBasket(decimal price);
    public abstract void AddItemToBasket(char price);
}