using System;
using System.Diagnostics;

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
