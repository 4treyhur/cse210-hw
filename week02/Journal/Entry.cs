using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;
    private int _mood;

    public Entry(string date, string promptText, string entryText, int mood)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
    }

    public string Date
    {
        get { return _date; }
    }

    public string PromptText
    {
        get { return _promptText; }
    }

    public string EntryText
    {
        get { return _entryText; }
    }

    public int Mood
    {
        get { return _mood; }
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"Mood (1-10): {_mood}");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }
}
