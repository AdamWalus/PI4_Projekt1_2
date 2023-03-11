using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using CsvHelper.Configuration.Attributes;
using CsvHelper.Configuration;
using ConsoleApp8;

namespace P4_Projekt_1
{
    //Lp.;Nazwa własna;Telefon;Email;Charakter usług;Kategoria obiektu;Rodzaj obiektu;Adres



    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("test");
            List<Hotel> result;
            using (var streamReader = new StreamReader(@"hotele.csv", System.Text.Encoding.UTF8))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture) //CultureInfo - formatowanie 
                {
                    Delimiter = ";",
                    HasHeaderRecord=true

                };
                
                using (var csvReader = new CsvReader(streamReader, csvConfig))
                {
                    //csvReader.Configuration.Delimiter = ";";
                    //result = csvReader.GetRecords<dynamic>().ToList();
                    //csvReader.Configuration.RegisterClassMap<HotelMap>();
                    result = csvReader.GetRecords<Hotel>().ToList(); //Wczytujemy dane z CSV i zwracamy liste obiektow hotel
                }
            }




            foreach (var details in result)
            {
                // Console.WriteLine($"Lp.: {details.LpNumber}");
                Console.WriteLine($"{details.LpNumber,-5} {details.Nazwa_Wlasna,-30} {details.Telefon,-20} {details.Email,-30} {details.Charakter_Uslug,-20} {details.Kategoria_Obiektu,-20} {details.Rodzaj_Obiektu,-20} {details.Adres,-30}");

            }

        }

        public sealed class HotelMap : ClassMap<Hotel>
        {
            public HotelMap()
            {
                Map(m => m.LpNumber).Index(0);
                Map(m => m.Nazwa_Wlasna).Index(1);
                Map(m => m.Telefon).Index(2);
                Map(m => m.Email).Index(3);
                Map(m => m.Charakter_Uslug).Index(4);
                Map(m => m.Kategoria_Obiektu).Index(5);
                Map(m => m.Rodzaj_Obiektu).Index(6);
                Map(m => m.Adres).Index(7);
            }
        }


        //1. Wczytać dane z pliku hotele.csv z użyciem biblioteki CsvHelper
        //2. Wyszukać wszystkie hotele, których nazwa zaczyna się na literę 's'
    }







  

   
}