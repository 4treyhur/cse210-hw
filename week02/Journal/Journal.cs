using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            Console.WriteLine();
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Saves the journal as a CSV file that can be opened in Excel.
    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file, false, Encoding.UTF8))
        {
            writer.WriteLine("Date,Prompt,Response,Mood");

            foreach (Entry entry in _entries)
            {
                string line = string.Join(",",
                    EscapeCsv(entry.Date),
                    EscapeCsv(entry.PromptText),
                    EscapeCsv(entry.EntryText),
                    entry.Mood.ToString());

                writer.WriteLine(line);
            }
        }
    }

    // Replaces the current entries with the ones found in the file.
    public void LoadFromFile(string file)
    {
        string[] lines = File.ReadAllLines(file, Encoding.UTF8);
        List<Entry> loadedEntries = new List<Entry>();

        // The first line is the header, so it is skipped.
        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
            {
                continue;
            }

            List<string> fields = ParseCsvLine(lines[i]);

            if (fields.Count < 4 || !int.TryParse(fields[3], out int mood))
            {
                throw new FormatException($"Invalid entry on line {i + 1}.");
            }

            loadedEntries.Add(new Entry(fields[0], fields[1], fields[2], mood));
        }

        _entries = loadedEntries;
    }

    private string EscapeCsv(string text)
    {
        bool needsQuotes = text.Contains(",") || text.Contains("\"") || text.Contains("\n");

        if (!needsQuotes)
        {
            return text;
        }

        return "\"" + text.Replace("\"", "\"\"") + "\"";
    }

    private List<string> ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        StringBuilder current = new StringBuilder();
        bool insideQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char character = line[i];

            if (insideQuotes)
            {
                if (character == '"' && i + 1 < line.Length && line[i + 1] == '"')
                {
                    current.Append('"');
                    i++;
                }
                else if (character == '"')
                {
                    insideQuotes = false;
                }
                else
                {
                    current.Append(character);
                }
            }
            else if (character == '"')
            {
                insideQuotes = true;
            }
            else if (character == ',')
            {
                fields.Add(current.ToString());
                current.Clear();
            }
            else
            {
                current.Append(character);
            }
        }

        fields.Add(current.ToString());

        return fields;
    }
}
