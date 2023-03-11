using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");

namespace P4_Projekt_1
{
   

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test");
            using (var streamReader = new StreamReader(@"hotele.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture)) //CultureInfo - formatowanie 
                {
                    var records = csvReader.GetRecords<dynamic>().ToList();
                }
            }
        }


        //1. Wczytać dane z pliku hotele.csv z użyciem biblioteki CsvHelper
        //2. Wyszukać wszystkie hotele, których nazwa zaczyna się na literę 's'
    }
}