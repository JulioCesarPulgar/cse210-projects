using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
            Console.Write("What is your grade percentage? ");
            string input = Console.ReadLine();
            int grade = int.Parse(input);

            string letter = "";
            string sign = "";

            if (grade >= 90)
            {
                letter = "A";
            }
            else if (grade >= 80)
            {
                letter = "B";
            }
            else if (grade >= 70)
            {
                letter = "C";
            }
            else if (grade >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            int lastDigit = grade % 10;
            // Determine sign for grades except A and F
            if (letter != "A" && letter != "F")
            {
                if (lastDigit >= 7)
                {
                    sign = "+";
                }
                else if (lastDigit < 3)
                {
                    sign = "-";
                }
            }
            // Special case for A-
            if (letter == "A" && lastDigit < 3)
            {
                sign = "-";
            }
            // F never gets a sign

            Console.WriteLine($"Your letter grade is: {letter}{sign}");

            if (grade >= 70)
            {
                Console.WriteLine("Congratulations! You passed the course.");
            }
            else
            {
                Console.WriteLine("Better luck next time!");
            }
        }
}