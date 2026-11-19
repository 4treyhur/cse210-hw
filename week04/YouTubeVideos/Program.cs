using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Cook Perfect Rice", "Kitchen Basics", 480);
        video1.AddComment(new Comment("Maria", "Finally my rice doesn't stick together!"));
        video1.AddComment(new Comment("Carlos", "Great tips, thanks for sharing."));
        video1.AddComment(new Comment("Ana", "I love the pot you used. Which brand is it?"));
        videos.Add(video1);

        Video video2 = new Video("Learn C# in 10 Minutes", "Code Academy", 615);
        video2.AddComment(new Comment("Luis", "Clear and easy to follow."));
        video2.AddComment(new Comment("Sofia", "Could you make a video about classes next?"));
        video2.AddComment(new Comment("Diego", "This helped me pass my exam."));
        video2.AddComment(new Comment("Valeria", "Please slow down a little in the middle."));
        videos.Add(video2);

        Video video3 = new Video("Top 5 Hiking Trails in Hidalgo", "Adventure Mexico", 925);
        video3.AddComment(new Comment("Pedro", "The view at minute 8 is amazing!"));
        video3.AddComment(new Comment("Lucia", "I want to visit all of them this year."));
        video3.AddComment(new Comment("Jorge", "Thanks for including the difficulty levels."));
        videos.Add(video3);

        Video video4 = new Video("Unboxing the Latest Wireless Headphones", "Tech Corner", 372);
        video4.AddComment(new Comment("Elena", "The sound quality looks incredible."));
        video4.AddComment(new Comment("Miguel", "Is the battery really that good?"));
        video4.AddComment(new Comment("Camila", "Nice video, subscribed!"));
        video4.AddComment(new Comment("Andres", "Please do a comparison with the older model."));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}
