namespace CalculatorTest;

static class Program
{
    private static async Task Main()
    {
        Console.WriteLine("Testing Calculator...");

        await TestCalculation("add", 3, 4);
        await TestCalculation("sub", 8, 4);
        await TestCalculation("mul", 3, 4);
        await TestCalculation("div", 8, 4);

        Console.Write($"{Environment.NewLine}Press any key to exit...");
        Console.ReadKey(true);
    }

    private static async Task TestCalculation(string op, int numberOne, int numberTwo)
    {
        var uri = $"https://sdincloud.herokuapp.com/calc?operation={op}&numberone={numberOne}&numbertwo={numberTwo}";
        Console.WriteLine("Testing the following command:...");
        Console.WriteLine(uri);
            
        using var client = new HttpClient();
        var response = await client.GetStringAsync(uri);
            
        int localCalculation;
        switch (op)
        {
            case "add":
                Console.WriteLine($"Performing the following calculation: {numberOne} + {numberTwo}");
                localCalculation = numberOne + numberTwo;
                break;
            case "sub":
                Console.WriteLine($"Performing the following calculation: {numberOne} - {numberTwo}");
                localCalculation = numberOne - numberTwo;
                break;
            case "mul":
                Console.WriteLine($"Performing the following calculation: {numberOne} * {numberTwo}");
                localCalculation = numberOne * numberTwo;
                break;
            case "div":
                Console.WriteLine($"Performing the following calculation: {numberOne} / {numberTwo}");
                localCalculation = numberOne / numberTwo;
                break;
            default:
                return;
        }
            
        Console.WriteLine($"The server returned: {response}.");
            
        Console.WriteLine($"Calculation is equal to the locally calculated result: {Int32.Parse(response) == localCalculation}.");
        Console.WriteLine();
    }
}