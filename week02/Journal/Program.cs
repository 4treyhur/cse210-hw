using System;

// EXCEEDING REQUIREMENTS
// 1. CSV storage: the journal is saved as a .csv file that opens in Excel.
//    Commas and quotation marks in the content are handled correctly by
//    wrapping fields in quotes and doubling any inner quotes (and the loader
//    parses them back correctly).
// 2. Extra information: every entry also stores a mood rating from 1 to 10.
// 3. No repeated prompts: the PromptGenerator shuffles through all prompts
//    before repeating any, and the user can ask for a different prompt if the
//    one shown does not inspire them (a common reason people stop journaling).
// 4. Error handling: loading a missing or malformed file shows a friendly
//    message and keeps the current journal unchanged.
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    WriteEntry(journal, promptGenerator);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    LoadJournal(journal);
                    break;
                case "4":
                    SaveJournal(journal);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose a number from 1 to 5.");
                    break;
            }
        }
    }

    static void WriteEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();

        while (true)
        {
            Console.WriteLine(prompt);
            Console.Write("Press Enter to answer or type 'n' for a different prompt: ");
            string answer = Console.ReadLine();

            if (answer != null && answer.Trim().ToLower() == "n")
            {
                prompt = promptGenerator.GetRandomPrompt();
            }
            else
            {
                break;
            }
        }

        Console.Write("> ");
        string response = Console.ReadLine();
        int mood = AskForMood();
        string date = DateTime.Now.ToString("yyyy-MM-dd");

        journal.AddEntry(new Entry(date, prompt, response, mood));
        Console.WriteLine("Entry added.");
    }

    static int AskForMood()
    {
        while (true)
        {
            Console.Write("How was your mood today (1-10)? ");

            if (int.TryParse(Console.ReadLine(), out int mood) && mood >= 1 && mood <= 10)
            {
                return mood;
            }

            Console.WriteLine("Please enter a number between 1 and 10.");
        }
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("What is the filename? ");
        string file = Console.ReadLine();

        try
        {
            journal.LoadFromFile(file);
            Console.WriteLine("Journal loaded.");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"The journal could not be loaded: {exception.Message}");
        }
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("What is the filename? ");
        string file = Console.ReadLine();

        try
        {
            journal.SaveToFile(file);
            Console.WriteLine("Journal saved.");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"The journal could not be saved: {exception.Message}");
        }
    }
}
