using System;

class Program
{
    static void Main(string[] args)
    {
        // Extras implemented:
        // - Shuffled prompts/questions for variety
        // - Listing activity stops accepting input when time expires
        // - Spinner & countdown utilities centralized in base class
        var app = new MindfulnessApp();
        app.Run();
    }
}