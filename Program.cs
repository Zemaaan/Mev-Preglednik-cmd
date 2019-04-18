using System;
using System.IO;

namespace Preglednik
{
    class Program
    {

        static public string ispisi_tip_datoteke(string ime_datoteke)
        {
            string nastavak_datoteke = Path.GetExtension(ime_datoteke);

            if (nastavak_datoteke == ".txt")
            {
                return ("Tekstualna datoteka");
            }

            else if (nastavak_datoteke == ".docx")
            {
                return ("Word dokument");
            }

            else if (nastavak_datoteke == ".ppt")
            {
                return ("Excel prezentacija");
            }

            else if (nastavak_datoteke == ".ppt")
            {
                return ("Excel prezentacija");
            }

            else if (nastavak_datoteke == ".dll")
            {
                return ("Dodatak aplikaciji.");
            }

            else if (nastavak_datoteke == ".pdf")
            {
                return ("PDF datoteka");
            }

            else if (nastavak_datoteke == ".html")
            {
                return("Web stranica");
            }

            else if (nastavak_datoteke == ".jpg")
            {
                return "JPG slika";
            }

            else if (nastavak_datoteke == ".exe")
            {
                return "Izvršna datoteka";
            }

            return nastavak_datoteke + " datoteka";
        }

        static public void ispisi_velicinu(float? kolicina_u_bytovima, string ime_datoteke, bool nastavci)
        {

            const int gigabyte = 1000000000; // velicina u bitovima
            const int megabyte = 1000000;
            const int kilobyte = 1000;
            const int bajt = 1;

            if (kolicina_u_bytovima == null)
            {
                Console.WriteLine("+-----------------------------------");
            }

            // if (kolicina_u_bytovima / (1024 * 1024 * 1024) == 0.0000 || kolicina_u_bytovima / (1024 * 1024 * 1024) < 0.0000)
            // {
            //     Console.WriteLine("| {0,-60} {1,10} {2,11} {3,14} {4,-190}", ime_datoteke,"≈ 0", String.Format("{0:0.00}", kolicina_u_bytovima / (1024 * 1024)), String.Format("{0:0.00}", kolicina_u_bytovima / 1024), "    " + ispisi_tip_datoteke(ime_datoteke));
            // }

            if (nastavci)
            {
                Console.WriteLine("| {0,-60} {1,10} {2,11} {3,14} {4,-60}", ime_datoteke, String.Format("{0:0.0000}", kolicina_u_bytovima / (1024 * 1024 * 1024)), String.Format("{0:0.00}", kolicina_u_bytovima / (1024 * 1024)), String.Format("{0:0.00}", kolicina_u_bytovima / 1024), "   " + ispisi_tip_datoteke(ime_datoteke));
            }

            else
            {
                Console.WriteLine("| {0,-60} {1,10} {2,11} {3,14} {4,-60}", Path.GetFileNameWithoutExtension(ime_datoteke), String.Format("{0:0.0000}", kolicina_u_bytovima / (1024 * 1024 * 1024)), String.Format("{0:0.00}", kolicina_u_bytovima / (1024 * 1024)), String.Format("{0:0.00}", kolicina_u_bytovima / 1024), "   " + ispisi_tip_datoteke(ime_datoteke));
            }


            // else if (kolicina_u_bytovima < gigabyte && kolicina_u_bytovima > megabyte)
            // {
            //     Console.WriteLine("| {0,-60} {1,22} {2, 14}", ime_datoteke, String.Format("{0:0.00}", kolicina_u_bytovima / (1024 * 1024)), String.Format("{0:0.00}", kolicina_u_bytovima / 1024 ));
            // }
            // else if (kolicina_u_bytovima < megabyte && kolicina_u_bytovima > kilobyte)
            // {
            //     Console.WriteLine("| {0,-60} {1, 37}", ime_datoteke, String.Format("{0:0.00}", kolicina_u_bytovima / 1024));
            // }
            // else if (kolicina_u_bytovima < kilobyte && kolicina_u_bytovima > bajt)
            // {
            //     Console.WriteLine("| {0,-63} {1, 47}", ime_datoteke, String.Format("{0:0.00}", kolicina_u_bytovima / (1024 * 1024)));
            // }

            // Console.WriteLine("|{0, 15} B | {1, 13} KB | {2, 4} MB |     

        }

        

            static void Main(string[] args)
        {
            string direktorij = null; // opcenito podrucje za postavljanja varijabli zbog try catch blokova
            string naredba = null;

            FileInfo[] datoteke = null;
            float velicina = 0;

            DriveInfo[] popis_diskova = DriveInfo.GetDrives();
            direktorij = popis_diskova[0].ToString(); // odaberemo prvi disk kao default putanju, u slucaju da korisnik pokusa upisati direktorij koji ne postoji
                                                      // obicno C:/ disk, ali ne mora nuzno biti

            bool ispisi_nastavke = false;
            bool list_dir_nacin_rada = false;

            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(300, 100);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            Console.WriteLine("Upisite naredbu:");
            naredba = Console.ReadLine();

            if(naredba == "/?")
            {
                Console.WriteLine("Popis mogucih naredbi.");
                Console.WriteLine("(/?) -- Pomoć ");
                Console.WriteLine("list_dir -- Nacin sa rad sa direktorijima, nakon čega se upisuje željeni direktorij.");
                Console.WriteLine("exit -- naredba za izlazak iz određenog načina rada.");
                Console.WriteLine("set_extensions(false) - aktiviranje ispisa datoteka bez ekstenzija.");
                Console.WriteLine("set_extensions(true) - aktiviranje ispisa datoteka sa ekstenzijama.");
            }
            else if (naredba == "set_extensions(false)")
            {
                if (!ispisi_nastavke)
                {
                    Console.WriteLine("Produzenja datoteka vec su ugasene.");
                    
                }

                else
                {
                    Console.WriteLine("Nadalje se neće ispisivati produzenja datoteka.");
                    ispisi_nastavke = false;
                }
            }

            else if (naredba == "set_extensions(true)")
            {
                if (ispisi_nastavke)
                {
                    Console.WriteLine("Produzenja datoteka su vec upaljene.");
                }

                else
                {
                    Console.WriteLine("Program ce nadalje ispisivati imena datoteka sa nastavcima.");
                    ispisi_nastavke = true;
                }
            }

            else if(naredba == "list_dir")
            {
                list_dir_nacin_rada = true;
                while (list_dir_nacin_rada)
                {
                    
                    Console.WriteLine("[list_dir] Upisite direktorij:");
                    direktorij = Console.ReadLine();

                    if (direktorij == "exit")
                    {
                        list_dir_nacin_rada = false;
                        break;
                    }

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
                    Console.WriteLine("| Naziv datoteke:                                       |             GB |        MB |           KB |   Vrsta datoteke:                        |");
                    Console.WriteLine("+------------------------------------------------------------------------+-----------+--------------+------------+-----------------------------+");

                    foreach (FileInfo trenutna_datoteka in datoteke)
                    {
                        velicina += trenutna_datoteka.Length;
                        ispisi_velicinu(trenutna_datoteka.Length, trenutna_datoteka.FullName, ispisi_nastavke);
                        ispisi_tip_datoteke(trenutna_datoteka.FullName);
                    }
                    Console.WriteLine("+--------------------+-------------+---------+-------------------------------------------------+");
                    Console.WriteLine("|{0, 15} B | {1, 13} KB | {2, 4} MB |                                          |",
                        velicina,
                        velicina / 1024,
                        velicina / (1024 * 1024));
                    Console.WriteLine("+------------------+-------------+---------+---------------------------------------------------+");

                }
            }
            // Console.SetCursorPosition(1, 3);
            // Console.Write(">");
            // int brojRedova = datoteke.Length + 6;

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
