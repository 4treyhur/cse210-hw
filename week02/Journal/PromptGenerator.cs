using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts;
    private List<string> _unusedPrompts;
    private Random _random;

    public PromptGenerator()
    {
        _random = new Random();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is something new I learned today?",
            "What am I most grateful for right now?",
            "What small act of kindness did I give or receive today?",
            "What challenge did I face today and how did I handle it?",
            "What is one goal I want to focus on tomorrow?"
        };
        _unusedPrompts = new List<string>(_prompts);
    }

    // Picks a random prompt without repeating one until all have been used.
    public string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_prompts);
        }

        int index = _random.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);

        return prompt;
    }
}
