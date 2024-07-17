namespace Basket;

public static class Tools
{
    public static void welcome()
    {
        Console.WriteLine("CASH REGISTER OPERATION.");
        Console.WriteLine("=========================");
        Console.WriteLine("Welcome in the cashier programm.");
        Console.WriteLine("After entering the cashier's login, " +
                          "enter the individual prices of the goods in the basket.\n" +
                          "When you finish, press the \"q\" key ( or \"Q\").\n");
    }
}