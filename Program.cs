using System;
using System.IO;
using System.Text.RegularExpressions;
internal class Test1010
{
  static void Main(string[] args)
  {
    using (var client = new WebClient())
        {
            client.DownloadFile("https://raw.githubusercontent.com/vilnius/licenses-and-permits/master/alcohol_licenses.csv", "alcohol_licenses.csv");
        }
    List<string> needed_values = new List<string>();

    using(var reader = new StreamReader(@".\alcohol_licenses.csv"))
    {
      while (!reader.EndOfStream)
      {
        var line = reader.ReadLine();
        var values = line.Split(';');
        var without_qoutes = values[5].Trim('"', ' ', '\t');
        var street = without_qoutes.Split('.');

        needed_values.Add(street[0]);

      }
    
        var counts = needed_values
        .GroupBy(w => w)
        .Select(g => new {Word = g.Key, Count = g.Count()})
        .ToList();

        List<int> number_repetitions = new List<int>();
        List<int> usable = new List<int>();

        foreach(var p in counts) 
        {
            number_repetitions.Add(p.Count);
        }

        var descendingOrder = number_repetitions.OrderByDescending(i => i);

        foreach(var p in descendingOrder) 
        {
            usable.Add(p);
        }
        for(int i = 0; i < 10; i++)
        {
            foreach(var p in counts)
            {
            
                if(p.Count == usable[i])
                {
                    Console.WriteLine(p);
                }
            }

        }
    }

  }

}