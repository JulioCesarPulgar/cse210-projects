using System;

// A class to represent a job with its details
public class Job
{
    public string _jobTitle = "";
    public string _company = "";
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}
