using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int idx = _random.Next(_words.Count);
            _words[idx].Hide();
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }

    public string GetDisplayText()
    {
        string display = _reference.GetDisplayText() + "\n";
        foreach (Word word in _words)
        {
            display += word.GetDisplayText() + " ";
        }
        return display.Trim();
    }
}
