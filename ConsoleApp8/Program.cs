using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using CsvHelper.Configuration.Attributes;
using CsvHelper.Configuration;
using ConsoleApp8;
using static System.Net.WebRequestMethods;

namespace P4_Projekt_1
{
    //Lp.;Nazwa własna;Telefon;Email;Charakter usług;Kategoria obiektu;Rodzaj obiektu;Adres



    class Program
    {
        //1. Wczytać dane z pliku hotele.csv z użyciem biblioteki CsvHelper
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
                //Wyswietlanie wszystkiego:

                //Console.WriteLine($"Lp.: {details.LpNumber}");
                //Console.WriteLine($"{details.LpNumber,-5} {details.Nazwa_Wlasna,-30} {details.Telefon,-20} {details.Email,-30} {details.Charakter_Uslug,-20} {details.Kategoria_Obiektu,-20} {details.Rodzaj_Obiektu,-20} {details.Adres,-30}");

            }



            //////////////////////////////////////////////////////////////////////////////////////
            //2. Wyszukać wszystkie hotele, których nazwa zaczyna się na literę 's'

            var NazwaHoteluNaS = result.Where(x => x.Nazwa_Wlasna.StartsWith("S")).ToList();
            

            Console.WriteLine($"Znaleziono {NazwaHoteluNaS.Count} hoteli na literę s:");
            foreach (var hotel in NazwaHoteluNaS)
            {
                Console.WriteLine(hotel.Nazwa_Wlasna);
            }

            //3.Obliczyć ile hoteli ma charakter sezonowy

            var Charakter_Sezonowy = result.Where(x => x.Charakter_Uslug.Contains("sezonowy")).Count();
            //Szukaj w result (csvReader.GetRecords...) Nazwa_Wlasna zaczynająca się od S, wsadz do listy
            //var NazwaHoteluNaS = result.Where(x => x.Nazwa_Wlasna.StartsWith("s")).ToList();

            Console.WriteLine($"Znaleziono {Charakter_Sezonowy} hoteli na o charakterze sezonowym");




            //4.Wyświetlić wszystkie typy charakterów usług bez powtórzeń

            var Charakter_Uslug = result.Select(x => x.Charakter_Uslug).Distinct();
            

            Console.WriteLine($"Znaleziono {Charakter_Uslug.Count()} Unikalnych charakterów usług");
            foreach (var x in Charakter_Uslug)
            {
                Console.WriteLine(x);
            }


            //5.Wyświetlić wszystkie kategorie hoteli bez powtórzeń

            var Kategorie = result.Select(x => x.Kategoria_Obiektu).Distinct();


            Console.WriteLine($"Znaleziono {Kategorie.Count()} kategorii hoteli");
            foreach (var x in Kategorie)
            {
                Console.WriteLine(x);
            }




            //6.Wyświetlić hotele, które pochodzą z okolicy Bielska - Białej(numer telefonu zaczyna się 33)

            var HoteleZBielska = result
                .Where(x => 
                    x.Telefon.StartsWith("33")
                    || x.Telefon.StartsWith("033")
                    || x.Telefon.StartsWith("(033")
                    || x.Telefon.StartsWith("(0 33")
                    || x.Telefon.StartsWith("(33")

                    );

            foreach (var x in HoteleZBielska)
            {
                Console.WriteLine(x.Telefon);
            }


        }

        public sealed class HotelMap : ClassMap<Hotel> //hotelmap dziedziczy po ClassMap<Hotel>, deserializuje plik csv do listy obiektow hotel
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



        


    }







  

   
}