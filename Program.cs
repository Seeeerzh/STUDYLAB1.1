using System;
using System.IO;
using System.Net;
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
    List<string> needed_values_licence = new List<string>();

    using(var reader = new StreamReader(@".\alcohol_licenses.csv"))
    {
      while (!reader.EndOfStream)
      {
        var line = reader.ReadLine();
        var values = line.Split(';');

        var without_qoutes_licence = values[8].Trim('"', ' ', '\t');
        needed_values_licence.Add(without_qoutes_licence);


        var without_qoutes = values[5].Trim('"', ' ', '\t');
        var street = without_qoutes.Split('.');

        needed_values.Add(street[0]);
      }


        var counts = needed_values
        .GroupBy(w => w)
        .Select(g => new {Street = g.Key, Count = g.Count()})
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

        Console.WriteLine();
        Console.WriteLine();

        var counts1 = needed_values_licence
        .GroupBy(w => w)
        .Select(g => new {Licence = g.Key, How_many_use = g.Count()})
        .ToList();

        //Console.WriteLine(counts1[1]);

        List<int> number_repetitions_licence = new List<int>();
        List<int> usable_licence = new List<int>();

        foreach(var p in counts1) 
        {
            number_repetitions_licence.Add(p.How_many_use);
        }

        var descendingOrder_licence = number_repetitions_licence.OrderByDescending(i => i);

        foreach(var p in descendingOrder_licence) 
        {
            
            usable_licence.Add(p);
        }

        for(int i = 0; i < 6; i++)
        {
            
            foreach(var p in counts1)
            {
            
                if(p.How_many_use == usable_licence[i])
                {
                    Console.WriteLine(p);
                }
            }

        }

    }

  }

}