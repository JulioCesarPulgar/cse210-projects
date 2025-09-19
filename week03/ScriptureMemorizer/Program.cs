using System;

class Program
{
    static void Main(string[] args)
    {
        // Scripture Memorizer Program
        // Creative feature: You can easily change the scripture or add more verses.

        // Example scripture: Proverbs 3:5-6
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.Trim().ToLower() == "quit")
                break;
            if (!scripture.AllWordsHidden())
            {
                scripture.HideRandomWords(3); // Hide 3 random words each time
            }
            else
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program will exit.");
                break;
            }
        }
    }
}