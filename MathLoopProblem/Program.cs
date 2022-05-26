using MathLoopProblem;


bool keepGoing = true;

while (keepGoing)
{
    Console.Write("Enter a whole integer value: ");
    string? response = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(response))
    {
        Console.WriteLine("You must provide a valid whole number integer!");
        continue;
    }
          
    if (long.TryParse(response, out var value))
    {

        var helper = new MathHelper();
        Console.WriteLine("Processing ....");
        Console.WriteLine("");
        int result = helper.RunEngine(value);
        Console.WriteLine($"Number {value} took {result} iterations to enter the loop. The highest value reached was: {helper.HighestValue}");
        Console.WriteLine("");
    }
    else
    {
        Console.WriteLine("You must provide a valid whole number integer!");
        continue;
    }
}