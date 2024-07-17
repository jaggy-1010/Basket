namespace Basket;

public class BasketInFile // : BasketBase
{
    public BasketInFile(string cashierLogin)
    {
        this.CashierLogin = cashierLogin;
    }

    public string CashierLogin { get; private set; }

    public void AddItemToBasket(double price)
    {
        using (var writer = File.AppendText(Param.BASKET_VALUES))
        {
            if (price > 0)
            {
                writer.WriteLine($"{Param.CashTime};{CashierLogin};{price:N2}");
            }
            else
            {
                throw new Exception("Acceptable values greater then 0.0");
            }
        }
    }


    public void AddItemToBasket(string price)
    {
        if (price != null)
        {
            if (double.TryParse(price, out double result))
            {
                this.AddItemToBasket(result);
            }
            else
            {
                throw new Exception(
                    "You have tried to input something what is not a price! Please input a proper value.");
            }
        }
        else
        {
            throw new Exception("Programm error! Please call our service.");
        }
    }

    public void InitializeBasketNumber()
    {
        if (!File.Exists(Param.LAST_BASKET_NUMBER))
        {
            using (var writer = File.CreateText(Param.LAST_BASKET_NUMBER))
            {
                writer.WriteLine(0);
            }
        }
    }

    public int OpenNewBasket()
    {
        using (var reader = File.OpenText(Param.LAST_BASKET_NUMBER))
        {
            var number = reader.ReadLine();
            if (Int32.TryParse(number, out int intNumber))
            {
                intNumber += 1;
            }
            else
            {
                throw new Exception("Error! Call service!");
            }

            return intNumber;
        }
    }

    public int InputNewBasket()
    {
        int intNumber = 0;
        double totalOfSingleBasket = 0.0;
        double itemValue = 0;
        using (var reader = File.OpenText(Param.LAST_BASKET_NUMBER))
        {
            var number = reader.ReadLine();
            using (var writer = File.CreateText(Param.LAST_BASKET_NUMBER))
            using (var writer2 = File.AppendText(Param.CASHIER_BASKET_SUMMARY))
            {
                while (true)
                {
                    Console.Write("Enter the price of the next good: ");
                    var input = Console.ReadLine();

                    if (input == "q" || input == "Q")
                    {
                        break;
                    }

                    try
                    {
                        itemValue = double.Parse(input);
                        this.AddItemToBasket(itemValue);
                        totalOfSingleBasket += itemValue;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Exception catched: {e.Message}");
                    }
                }


                intNumber = Int32.Parse(number);
                intNumber += 1;
                writer.WriteLine($"{intNumber}");
                writer2.WriteLine($"{Param.CashTime};{this.CashierLogin};{intNumber};{totalOfSingleBasket:N2}");
            }
        }

        return intNumber;
    }

    public string GetCurrentBasketTotal(int currentBasketNumber)
    {
        string basketTotal = " ";
        using (var reader = File.OpenText(Param.CASHIER_BASKET_SUMMARY))
        {
            var line = reader.ReadLine();

            while (line != null)
            {
                char[] charSeparator = new char[] { ';' };
                string[] results;
                results = line.Split(charSeparator, StringSplitOptions.None);
                if (results[2] == currentBasketNumber.ToString())
                {
                    basketTotal = results[3];
                    break;
                }
                else
                {
                    line = reader.ReadLine();
                }
            }
        }

        return basketTotal;
    }

    public Statistics GetStatistics()
    {
        var statistics = new Statistics();

        if (File.Exists(Param.CASHIER_BASKET_SUMMARY))
        {
            using (var reader = File.OpenText(Param.CASHIER_BASKET_SUMMARY))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    char[] charSeparator = new char[] { ';' };
                    string[] results;
                    results = line.Split(charSeparator, StringSplitOptions.None);
                    var itemStringValue = results[3];
                    var itemValue = double.Parse(itemStringValue);
                    statistics.AddItemValue(itemValue);
                    line = reader.ReadLine();
                }
            }
        }

        return statistics;
    }

    public Statistics GetDailyStatistics()
    {
        var statistics = new Statistics();

        if (File.Exists(Param.CASHIER_BASKET_SUMMARY))
        {
            Console.Write("Input a date: ");
            var input = Console.ReadLine();
            using (var reader = File.OpenText(Param.CASHIER_BASKET_SUMMARY))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    char[] charSeparator = new char[] { ';' };
                    string[] results;
                    results = line.Split(charSeparator, StringSplitOptions.None);
                    var date = results[0];
                    var dateOnly = date.Substring(0, 10);
                    if (dateOnly == input)
                    {
                        // var dateInDayOnlyFormat = DateOnly.Parse(dateOnly);
                        // var day = dateInDayOnlyFormat.Day;
                        var itemStringValue = results[3];
                        var itemValue = double.Parse(itemStringValue);
                        statistics.AddItemValue(itemValue);
                        line = reader.ReadLine();
                    }
                    else
                    {
                        line = reader.ReadLine();
                    }
                }
            }
        }

        return statistics;
    }
}