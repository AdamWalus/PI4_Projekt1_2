using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{

    public class Wczytywanie
    {
        [Name("Lp.")]
        public int LpNumber { get; set; }
        [Name("Nazwa własna")]
        public string Nazwa_Wlasna { get; set; }
        [Name("Telefon")]
        public string Telefon { get; set; }
        [Name("Email")]
        public string Email { get; set; }
        [Name("Charakter usług")]
        public string Charakter_Uslug { get; set; }
        [Name("Kategoria obiektu")]
        public string Kategoria_Obiektu { get; set; }
        [Name("Rodzaj obiektu")]
        public string Rodzaj_Obiektu { get; set; }
        [Name("Adres")]
        public string Adres { get; set; }


    }
}
