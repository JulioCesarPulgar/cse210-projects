using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var videos = new List<Video>();

        var v1 = new Video("The Wonders of C#", "Jane Developer", 360);
        v1.AddComment(new Comment("Alice", "Great explanation!"));
        v1.AddComment(new Comment("Bob", "Loved the examples."));
        v1.AddComment(new Comment("Charlie", "Can you cover LINQ next?"));
        videos.Add(v1);

        var v2 = new Video("Intro to Data Structures", "Data Guru", 420);
        v2.AddComment(new Comment("Dana", "Very clear and helpful."));
        v2.AddComment(new Comment("Ethan", "Can you show more trees?"));
        v2.AddComment(new Comment("Fiona", "Nice pacing."));
        videos.Add(v2);

        var v3 = new Video("Cooking with Code", "Chef Coder", 300);
        v3.AddComment(new Comment("George", "I tried this recipe, loved it!"));
        v3.AddComment(new Comment("Hannah", "Funny and informative."));
        v3.AddComment(new Comment("Ian", "More savory recipes please."));
        videos.Add(v3);

        var v4 = new Video("Unity Game Jam Tips", "GameDevPro", 540);
        v4.AddComment(new Comment("Jill", "This saved me hours of work."));
        v4.AddComment(new Comment("Kyle", "Good optimization tips."));
        v4.AddComment(new Comment("Lina", "Can you share project files?"));
        videos.Add(v4);

        // Display each video's details and comments
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            video.DisplayComments();
            Console.WriteLine();
        }
    }
}