using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using CsvHelper.Configuration.Attributes;
using CsvHelper.Configuration;

namespace P4_Projekt_1
{
    //Lp.;Nazwa własna;Telefon;Email;Charakter usług;Kategoria obiektu;Rodzaj obiektu;Adres



    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("test");
            List<dynamic> result;
            using (var streamReader = new StreamReader(@"hotele.csv", System.Text.Encoding.UTF8))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture) //CultureInfo - formatowanie 
                {
                    Delimiter = ";",
                    HasHeaderRecord=true
                };
                
                using (var csvReader = new CsvReader(streamReader, csvConfig))
                {
                    //csvReader.Configuration.Delimiter = ";";
                    result = csvReader.GetRecords<dynamic>().ToList();
                }
            }

            foreach (var details in result)
            {
               // Console.WriteLine($"Lp.: {details.LpNumber}");
                Console.WriteLine($"Nazwa własna: {details.Nazwa_Wlasna}");
                Console.WriteLine($"Telefon: {details.Telefon}");
            }

        }


        //1. Wczytać dane z pliku hotele.csv z użyciem biblioteki CsvHelper
        //2. Wyszukać wszystkie hotele, których nazwa zaczyna się na literę 's'
    }







  

   
}