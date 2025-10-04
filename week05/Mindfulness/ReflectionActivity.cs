using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

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
