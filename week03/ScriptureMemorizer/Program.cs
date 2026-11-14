using System;

// EXCEEDING REQUIREMENTS
// 1. Scripture library: the program works with many scriptures and picks one
//    at random each time. They are loaded from scriptures.txt (format:
//    Book|Chapter|StartVerse|EndVerse|Text). If the file is not found, a
//    built-in list is used instead.
// 2. Smarter hiding: random words are chosen only from the words that are
//    still visible, so every Enter hides new words.
// 3. Punctuation stays visible: only letters become underscores, which keeps
//    the scripture easier to read while memorizing.
// 4. Difficulty levels: the user chooses how many words are hidden per round
//    (easy = 2, medium = 4, hard = 6).
// 5. Replay: after finishing a scripture, the user can practice another one.
class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();

        if (!library.LoadFromFile("scriptures.txt"))
        {
            library.AddDefaultScriptures();
        }

        bool keepPlaying = true;

        while (keepPlaying)
        {
            int wordsPerRound = AskForDifficulty();
            Scripture scripture = library.GetRandomScripture();

            keepPlaying = Memorize(scripture, wordsPerRound);
        }

        Console.WriteLine("Goodbye!");
    }

    static int AskForDifficulty()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose a difficulty:");
            Console.WriteLine("1. Easy (2 words per round)");
            Console.WriteLine("2. Medium (4 words per round)");
            Console.WriteLine("3. Hard (6 words per round)");
            Console.Write("> ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return 2;
                case "2":
                    return 4;
                case "3":
                    return 6;
            }
        }
    }

    // Returns true if the user wants to practice another scripture.
    static bool Memorize(Scripture scripture, int wordsPerRound)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.Write("Well done! Press enter to practice another scripture or type quit: ");

                return Console.ReadLine().Trim().ToLower() != "quit";
            }

            Console.Write("Press enter to continue or type quit to finish: ");

            if (Console.ReadLine().Trim().ToLower() == "quit")
            {
                return false;
            }

            scripture.HideRandomWords(wordsPerRound);
        }
    }
}
