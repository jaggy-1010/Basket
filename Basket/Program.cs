using Basket;

Tools.welcome();

Console.Write("Please enter the cashier login: ");
var cashierLogin = Console.ReadLine();
var basketInFile = new BasketInFile(cashierLogin);

basketInFile.InitializeBasketNumber();
var newBasketNumber = basketInFile.OpenNewBasket();
Console.WriteLine($"Your new basket number: {newBasketNumber}\n");

var basketNumberIntroducedToFile = basketInFile.InputNewBasket();
Console.WriteLine($"The basket has been introduced under the number: {basketNumberIntroducedToFile}");

string currentBasketTotal = basketInFile.GetCurrentBasketTotal(basketNumberIntroducedToFile);
Console.WriteLine($"Current basket total: {currentBasketTotal}");

var globalBasketStatistics = basketInFile.GetStatistics();
Console.WriteLine();
Console.WriteLine("Global statistics for the all cashiers and baskets:");
Console.WriteLine($"Global baskets number: {globalBasketStatistics.Count}");
Console.WriteLine($"Global baskets value: {globalBasketStatistics.Sum:N2}");
Console.WriteLine($"Global smallest basket value: {globalBasketStatistics.Min}");
Console.WriteLine($"Global highest basket value: {globalBasketStatistics.Max}");
Console.WriteLine($"Global average basket value: {globalBasketStatistics.Average:N2}");

Console.WriteLine();
Console.WriteLine("Basket statistics for the selected day.");
var dailyBasketStatistics = basketInFile.GetDailyStatistics();
Console.WriteLine($"Baskets number: {dailyBasketStatistics.Count}");
Console.WriteLine($"Value of all baskets on the selected day: {dailyBasketStatistics.Sum}");
Console.WriteLine($"Smallest basket value : {dailyBasketStatistics.Min}");
Console.WriteLine($"Highest basket value: {dailyBasketStatistics.Max}");
Console.WriteLine($"Average basket value: {dailyBasketStatistics.Average}");