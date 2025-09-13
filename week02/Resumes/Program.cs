using System;

class Program
{
    static void Main(string[] args)
    {
        // Manager at Apple
        Job job1 = new Job();
        job1._jobTitle = "Manager";
        job1._company = "Apple";
        job1._startYear = 2022;
        job1._endYear = 2025;

        // Lead at Apple
        Job job2 = new Job();
        job2._jobTitle = "Lead";
        job2._company = "Apple";
        job2._startYear = 2019;
        job2._endYear = 2022;

        // RCC - AS at Apple
        Job job3 = new Job();
        job3._jobTitle = "RCC - AS";
        job3._company = "Apple";
        job3._startYear = 2020;
        job3._endYear = 2020;

        // Predoctoral Researcher in Molecular Virology (FPI) at Universidad Politécnica de Madrid
        Job job4 = new Job();
        job4._jobTitle = "Predoctoral Researcher in Molecular Virology (FPI)";
        job4._company = "Universidad Politécnica de Madrid";
        job4._startYear = 2010;
        job4._endYear = 2015;

        // Create resume and add jobs
        Resume nachoResume = new Resume();
        nachoResume._name = "Nacho Hamada";
        nachoResume._jobs.Add(job1);
        nachoResume._jobs.Add(job2);
        nachoResume._jobs.Add(job3);
        nachoResume._jobs.Add(job4);

        // Display resume
        nachoResume.Display();

        // Option to show LinkedIn link
        Console.WriteLine();
        Console.Write("Would you like to visit Nacho's LinkedIn profile? (y/n): ");
        string answer = Console.ReadLine();
        if (answer.Trim().ToLower() == "y")
        {
            Console.WriteLine("LinkedIn link: https://www.linkedin.com/in/nachohamada/");
        }
    }
}