using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    // No-argument constructor: 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // One-argument constructor: top/1
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Two-argument constructor: top/bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getter and Setter for top
    public int GetTop()
    {
        return _top;
    }
    public void SetTop(int top)
    {
        _top = top;
    }

    // Getter and Setter for bottom
    public int GetBottom()
    {
        return _bottom;
    }
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Returns fraction as string
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Returns decimal value
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}
