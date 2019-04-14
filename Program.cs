using System;
using System.IO;

namespace Preglednik
{
    class Program
    {
        static public void ispisi_velicinu(float? kolicina_u_bytovima, string ime_datoteke)
        {

            const int gigabyte = 1000000000; // velicina u bitovima
            const int megabyte = 1000000;
            const int kilobyte = 1000;
            const int bajt = 1;

            if (kolicina_u_bytovima == null)
            {
                Console.WriteLine("+-----------------------------------");
            }
            else if (kolicina_u_bytovima > gigabyte)
            {
                Console.WriteLine("| {0,-60} {1,10}", ime_datoteke, String.Format("{0:0.00}", kolicina_u_bytovima / (1024 * 1024 * 1024)));
            }
            else if (kolicina_u_bytovima < gigabyte && kolicina_u_bytovima > megabyte)
            {
                Console.WriteLine("| {0,-60} {1,22} {2, 14}", ime_datoteke, String.Format("{0:0.00}", kolicina_u_bytovima / (1024 * 1024)), String.Format("{0:0.00}", kolicina_u_bytovima / 1024 ));
            }
            else if (kolicina_u_bytovima < megabyte && kolicina_u_bytovima > kilobyte)
            {
                Console.WriteLine("| {0,-60} {1, 37}", ime_datoteke, String.Format("{0:0.00}", kolicina_u_bytovima / 1024));
            }
            else if (kolicina_u_bytovima < kilobyte && kolicina_u_bytovima > bajt)
            {
                Console.WriteLine("| {0,-63} {1, 47}", ime_datoteke, String.Format("{0:0.00}", kolicina_u_bytovima / (1024 * 1024)));
            }

            // Console.WriteLine("|{0, 15} B | {1, 13} KB | {2, 4} MB |     

        }

            static void Main(string[] args)
        {
            string direktorij = null; // opcenito podrucje za postavljanja varijabli zbog try catch blokova
            FileInfo[] datoteke = null;
            float velicina = 0;

            DriveInfo[] popis_diskova = DriveInfo.GetDrives();
            direktorij = popis_diskova[0].ToString(); // odaberemo prvi disk kao default putanju, u slucaju da korisnik pokusa upisati direktorij koji ne postoji
                                                      // obicno C:/ disk, ali ne mora nuzno biti


            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(300, 100);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            Console.WriteLine("Upisite direktorij:");
            direktorij = Console.ReadLine();

            DirectoryInfo podaci_o_direktoriju = new DirectoryInfo(direktorij);

            try
            {
                datoteke = podaci_o_direktoriju.GetFiles();
            }
            catch (System.IO.DirectoryNotFoundException)
            {

                Console.WriteLine("Taj direktorij ne postoji."); Main(null);
            } // vrtimo se tako dugo, dok korisnik ne upise ispravan direktorij

            if (datoteke.Length == 0)
            {
                Console.WriteLine("U direktoriju ne postoje datoteke.");
                Main(null);
            }

            Console.WriteLine("+------------------------------------------------------------------------+-----------+--------------+------------+-----------------------------+");
            Console.WriteLine("| Naziv datoteke:                                       |             GB |        MB |           KB |          B |                             |");
            Console.WriteLine("+------------------------------------------------------------------------+-----------+--------------+------------+-----------------------------+");

            foreach (FileInfo trenutna_datoteka in datoteke)
            {
                velicina += trenutna_datoteka.Length;
                ispisi_velicinu(trenutna_datoteka.Length, trenutna_datoteka.FullName);
            }
            Console.WriteLine("+--------------------+-------------+---------+-------------------------------------------------+");
            Console.WriteLine("|{0, 15} B | {1, 13} KB | {2, 4} MB |                                          |",
                velicina,
                velicina / 1024,
                velicina / (1024 * 1024));
            Console.WriteLine("+------------------+-------------+---------+---------------------------------------------------+");

            // Console.SetCursorPosition(1, 3);
            // Console.Write(">");
            int brojRedova = datoteke.Length + 6;

            Main(null); // ovo je bilo za ocekivati..


            // int cekanjeTreperenje = 0;
            // Console.CursorVisible = false;
            // int pokazivacY = 3;
            // while (true)
            // {
            //     Console.Write(" ");
            //     System.Threading.Thread.Sleep(cekanjeTreperenje);
            //     Console.SetCursorPosition(1, pokazivacY);
            //     Console.Write(">");

            //     if (Console.KeyAvailable)
            //     {
            //         ConsoleKeyInfo pritisnutaTipka = Console.ReadKey(true);
            //         if (pritisnutaTipka.Key == ConsoleKey.DownArrow)
            //         {
            //             pokazivacY++;
            //         }
            //     }
            // }

            // Console.SetCursorPosition(0, brojRedova);
        } //Main
    }
    
}
