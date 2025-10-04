using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var app = new MindfulnessApp();
        app.Run();
    }
}

// MindfulnessApp manages the menu and activity selection
class MindfulnessApp
{
    private readonly List<Activity> _activities;

    public MindfulnessApp()
    {
        _activities = new List<Activity>
        {
            new BreathingActivity(),
            new ReflectionActivity(),
            new ListingActivity()
        };
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("===================\n");
            Console.WriteLine("Menu Options:");
            for (int i = 0; i < _activities.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {_activities[i].Name}");
            }
            Console.WriteLine("  4. Quit\n");
            Console.Write("Select a choice from the menu: ");
            var input = Console.ReadLine();

            if (input == "4" || input?.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase) == true)
            {
                Console.WriteLine("Goodbye!");
                return;
            }

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= _activities.Count)
            {
                var activity = _activities[choice - 1];
                activity.Start();
            }
            else
            {
                Console.WriteLine("Invalid choice. Press Enter to continue.");
                Console.ReadLine();
            }
        }
    }
}

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

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    protected override void Run(int durationSeconds)
    {
        var sw = Stopwatch.StartNew();
        bool inhale = true;
        const int perCycle = 4; // seconds per in/out
        while (sw.Elapsed.TotalSeconds < durationSeconds)
        {
            if (inhale)
            {
                Console.WriteLine("\nBreathe in...");
            }
            else
            {
                Console.WriteLine("\nBreathe out...");
            }

            int remaining = (int)Math.Ceiling(Math.Min(perCycle, Math.Max(0, durationSeconds - sw.Elapsed.TotalSeconds)));
            if (remaining <= 0) break;
            Countdown(remaining);
            inhale = !inhale;
        }
        sw.Stop();
    }
}

class ReflectionActivity : Activity
{
    private readonly List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
        : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    { }

    protected override void Run(int durationSeconds)
    {
        var rnd = new Random();
        var prompt = _prompts[rnd.Next(_prompts.Count)];
        Console.WriteLine();
        Console.WriteLine(prompt);
        Console.WriteLine();

        // We'll show questions in a shuffled order and loop if needed
        var questions = _questions.OrderBy(x => rnd.Next()).ToList();
        int qi = 0;

        var sw = Stopwatch.StartNew();
        while (sw.Elapsed.TotalSeconds < durationSeconds)
        {
            var q = questions[qi % questions.Count];
            qi++;
            Console.WriteLine(q);
            // pause with spinner for a few seconds to let user reflect
            PauseWithSpinner(6);
            Console.WriteLine();
        }
        sw.Stop();
    }
}

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

/*
 * Extra notes / small feature additions (exceeds requirements):
 * - Questions and prompts are presented in a shuffled order so the session feels varied.
 * - Listing activity uses a ReadLine with timeout so the session will stop accepting input when time expires.
 * - Spinner and countdown utilities are centralized in the base Activity class to avoid duplicated code.
 */