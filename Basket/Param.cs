namespace Basket;

public static class Param
{
    // CONFIG:
    
    // Data Files -> BasketInFile
    public const string BASKET_VALUES = "basketValues.txt";
    public const string LAST_BASKET_NUMBER = "lastBasketNumber.txt";
    public const string CASHIER_BASKET_SUMMARY = "cashierBasketSummary.txt";
    
    // Dates -> BasketInFile
    public static DateTimeOffset Day = DateTimeOffset.Now;
    public static string CashDay = Day.ToString("d");
    public static string CashTime = Day.ToString("G");
    
    // Single basket trade levels -> Statistics
    public const double LOW_LEVEL = 20.0;
    public const double STANDARD_LEVEL = 100.0;
    public const double MIDDLE_LEVEL = 200.0;
    public const double UPPER_MIDDLE_LEVEL = 500.0;
    public const double HIGH_LEVEL = 800.0;
}