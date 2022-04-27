# Console application to test the calculator project

This is a console application to test the cloud calculator I previously created. I chose C# because I have the most experience with it.

## Creating the application

I created the application by executing the following command in the command line: 

```
dotnet new console --framework net6.0
```

This creates a new .NET Framework 6.0 console application in the directory where the command was executed.

## Executing the HTTP-request

In the class ```Program.cs``` I added a method to execute a HTTP-request to the server and output the result to the console:

```
private static async Task TestCalculation(string op, int numberOne, int numberTwo)
    {
        var uri = $"http://sdincloud.herokuapp.com/calc?operation={op}&numberone={numberOne}&numbertwo={numberTwo}";
    
        using var client = new HttpClient();
        var response = await client.GetStringAsync(uri);
                               
        Console.WriteLine($"The server returned: {response}.");
    }
```

Furthermore I added some console statements to display which calculation was executed. 

## Verifying the result

To verify that the server is calculating the numbers correct, I added code in C# to also calculate it and to compare the results: 

```
	// ...
	
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
```
