using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class ListingActivity : Activity
{
    private readonly List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    { }

    protected override void Run(int durationSeconds)
    {
        var rnd = new Random();
        var prompt = _prompts[rnd.Next(_prompts.Count)];
        Console.WriteLine();
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.WriteLine("You will have a few seconds to think about your answers.");
        Countdown(5);
        Console.WriteLine();
        Console.WriteLine("Start listing items. Press Enter after each item.");

        var items = new List<string>();
        var endTime = DateTime.Now.AddSeconds(durationSeconds);

        while (DateTime.Now < endTime)
        {
            int msRemaining = (int)(endTime - DateTime.Now).TotalMilliseconds;
            if (msRemaining <= 0) break;
            string line = ReadLineWithTimeout(msRemaining).Result; // synchronous wait
            if (line == null) break; // time ran out
            if (!string.IsNullOrWhiteSpace(line)) items.Add(line.Trim());
        }

        Console.WriteLine($"\nYou listed {items.Count} items.");
    }

    // Helper to read a line with a timeout (milliseconds). Returns null if timed out.
    private async Task<string> ReadLineWithTimeout(int millisecondsTimeout)
    {
        var task = Task.Run(() => Console.ReadLine());
        var completed = await Task.WhenAny(task, Task.Delay(millisecondsTimeout));
        if (completed == task)
        {
            return task.Result;
        }
        return null;
    }
}
