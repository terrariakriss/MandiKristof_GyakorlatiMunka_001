using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MandiKristof_GyakorlatiMunka_001
{
    internal class Program
    {
        static List<VideoGames> adat = new List<VideoGames>();
        static void Main(string[] args)
        {
            adatbeolvas();

            Console.WriteLine("1.feladat");
            adat.Where(x => x.Rating >= 9).ToList().ForEach(y => Console.WriteLine(y.Jatekneve));
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("2.feladat");
            adat.Where(x=>x.Kiadasieve > 2015 && x.Platform == "Nintendo Switch" && x.Rating >= 8).ToList().ForEach(y => Console.WriteLine(y.Jatekneve));
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("3.feladat");
            adat.OrderByDescending(x=>x.Kiadasieve).ToList().ForEach(y => Console.WriteLine(y.Jatekneve));
            Console.WriteLine("--------------------------------------------------");
            
            Console.WriteLine("4.feladat");
            adat.OrderBy(x => x.Rating).Take(10).ToList().ForEach(y => Console.WriteLine(y.Jatekneve));
            Console.WriteLine("--------------------------------------------------");
            
            Console.WriteLine("5.feladat");
            int csoport = adat.GroupBy(x => x.Platform).Count();
            Console.WriteLine($"Platformonként {csoport} db játék van");
            Console.WriteLine("--------------------------------------------------");
            
            Console.WriteLine("6.feladat");
            adat.GroupBy(x => x.Tipus).Select(y => new
            {
                tipusNev = y.Key,
                db = y.Count()
            }).OrderByDescending(xy => xy.db).ToList().ForEach(xy => Console.WriteLine(xy));
            Console.WriteLine("--------------------------------------------------");
            
            Console.WriteLine("7.feladat");
            double atlag = adat.Average(x => x.Rating);
            Console.WriteLine($"Átlagos rating: {atlag}");
            Console.WriteLine("--------------------------------------------------");
            
            Console.WriteLine("8.feladat");
            adat.GroupBy(x=>x.Platform).ToList().Select(y=>new
            {
                platform = y.Key,
                ertekeles = y
            });
            Console.WriteLine("--------------------------------------------------");
           /*
            Console.WriteLine("9.feladat");
            
            Console.WriteLine("--------------------------------------------------");
            
            Console.WriteLine("10.feladat");

            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("11.feladat");

            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("12.feladat");

            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("13.feladat");

            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("14.feladat");

            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("15.feladat");

            Console.WriteLine("--------------------------------------------------");*/


            Console.ReadKey();
        }

        private static void adatbeolvas()
        {
            try
            {
                adat = File.ReadLines("games.csv")
                    .Skip(1)
                    .Select(x => x.Split(';'))
                    .Select(x => new VideoGames 
                    { 
                        Jatekneve = x[0],
                        Tipus = x[1],
                        Platform = x[2],
                        Kiadasieve = int.Parse(x[3]),
                        Rating = double.Parse(x[4]),
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
         
            }
        }
    }
}
