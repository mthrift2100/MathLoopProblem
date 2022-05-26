namespace MathLoopProblem;

public interface IMathHelper
{

    void Start();
}

public class MathHelper : IMathHelper
{
    private int iteration = 0;
    private long highestNumber = 0;


    public void Start()
    {
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
