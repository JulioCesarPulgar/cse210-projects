using System;
using System.Collections.Generic;

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
