using System;
using System.Collections.Generic;
using System.IO;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private Random _random;

    public ScriptureLibrary()
    {
        _random = new Random();
        _scriptures = new List<Scripture>();
    }

    // Each line: Book|Chapter|StartVerse|EndVerse|Text (lines starting with # are ignored).
    // Returns true if at least one scripture was loaded.
    public bool LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            return false;
        }

        foreach (string line in File.ReadAllLines(file))
        {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
            {
                continue;
            }

            string[] parts = line.Split('|', 5);

            if (parts.Length == 5
                && int.TryParse(parts[1], out int chapter)
                && int.TryParse(parts[2], out int startVerse)
                && int.TryParse(parts[3], out int endVerse))
            {
                Reference reference = startVerse == endVerse
                    ? new Reference(parts[0], chapter, startVerse)
                    : new Reference(parts[0], chapter, startVerse, endVerse);

                _scriptures.Add(new Scripture(reference, parts[4]));
            }
        }

        return _scriptures.Count > 0;
    }

    public void AddDefaultScriptures()
    {
        _scriptures.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));

        _scriptures.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));
    }

    public Scripture GetRandomScripture()
    {
        return _scriptures[_random.Next(_scriptures.Count)];
    }
}
