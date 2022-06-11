using Serilog;

namespace MathLoopProblem;

public interface IMathHelper
{

    void Start();
}

public class MathHelper : IMathHelper
{
    private readonly ILogger _Logger;
    private int iteration = 0;
    private long highestNumber = 0;


    public MathHelper(ILogger logger)
    {
        _Logger = logger;
    }

    public void Start()
    {
        bool keepGoing = true;

        while (keepGoing)
        {
            Console.Write("Enter a whole integer value: ");
            string? response = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(response))
            {
                Console.WriteLine("You must provide a valid positive whole number integer!");
                continue;
            }

            if (long.TryParse(response, out var value))
            {
                //Ensure value is greater than 0 or else we will end up iin an infinite loop.
                if (!(value > 0)) 
                {
                    Console.WriteLine("You must provide a valid positive whole number integer!");
                    continue;
                }

                Console.WriteLine("Processing ....");
                Console.WriteLine("");
                DateTime start = DateTime.Now;
                int result = RunEngine(value);
                DateTime end = DateTime.Now;
                TimeSpan runtime = (end - start);
                Console.WriteLine($"Number {value} took {result} iterations to enter the loop. The highest value reached was: {HighestValue}");
                Console.WriteLine("");
                _Logger.Information("Engine took {0} milliseconds to run.", runtime.TotalMilliseconds);
            }
            else
            {
                Console.WriteLine("You must provide a valid positive whole number integer!");
                continue;
            }
        }
    }

    long HighestValue { get => highestNumber; }
    int RunEngine(long value)
    {
        highestNumber = value;
        Console.WriteLine($"Starting with {value}");
        while (value != 4)
        {
            if (value % 2 == 0)
            {
                //Number is even so divide by 2
                value = (value / 2);
            }
            else
            {
                //Value is odd so multiply by 3 then add 1
                value = (value * 3) + 1;
            }

            highestNumber = Math.Max(highestNumber, value);
            Console.WriteLine(value);
            iteration++;
        }

        return iteration;
    }

}
