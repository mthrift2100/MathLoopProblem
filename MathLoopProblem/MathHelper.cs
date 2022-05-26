namespace MathLoopProblem;


public class MathHelper
{
    private int iteration = 0;
    private long highestNumber = 0;

    public long HighestValue { get => highestNumber; }
    public int RunEngine(long value)
    {
        highestNumber = value;
        Console.WriteLine($"Starting with {value}");
        while(value != 4)
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
