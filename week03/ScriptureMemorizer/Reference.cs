using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;
    private bool _isRange;

    // Constructor for single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _isRange = false;
    }

    // Constructor for verse range
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
        _isRange = true;
    }

    public string GetDisplayText()
    {
        if (_isRange)
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        else
            return $"{_book} {_chapter}:{_verse}";
    }
}
