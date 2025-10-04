using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// Base activity class with shared behaviors
abstract class Activity
{
    private string _name;
    private string _description;
    private int _durationSeconds;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string Name => _name;

    public void Start()
    {
        Console.Clear();
        ShowStartingMessage();
        _durationSeconds = PromptForDuration();
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        PauseWithSpinner(3);

        var sw = Stopwatch.StartNew();
        Run(_durationSeconds);
        sw.Stop();

        ShowEndingMessage(sw.Elapsed);
    }

    private void ShowStartingMessage()
    {
        Console.WriteLine($"Activity: {_name}\n");
        Console.WriteLine(_description + "\n");
    }

    private int PromptForDuration()
    {
        while (true)
        {
            Console.Write("Enter the duration of the activity in seconds: ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                return seconds;
            }
            Console.WriteLine("Please enter a positive integer number of seconds.");
        }
    }

    private void ShowEndingMessage(TimeSpan elapsed)
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        PauseWithSpinner(2);
        Console.WriteLine($"You have completed the {_name} for {(int)elapsed.TotalSeconds} seconds.");
        PauseWithSpinner(3);
    }

    // Child classes implement their own behaviour within the time limit
    protected abstract void Run(int durationSeconds);

    // A simple spinner animation for a given number of seconds
    protected void PauseWithSpinner(int seconds)
    {
        var spinner = new[] { '|', '/', '-', '\\' };
        var sw = Stopwatch.StartNew();
        int i = 0;
        while (sw.Elapsed.TotalSeconds < seconds)
        {
            Console.Write(spinner[i % spinner.Length]);
            Task.Delay(250).Wait();
            Console.Write('\b');
            i++;
        }
        sw.Stop();
    }

    // Countdown that shows numbers from seconds down to 1
    protected void Countdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Task.Delay(1000).Wait();
            Console.Write('\b');
            Console.Write(' ');
            Console.Write('\b');
        }
    }
}
