using System.Text;

/** Alapvető programozási tételek
 *
 *  - [Összegzés](#összegzés)
 *  - [Megszámolás](#megszámolás)
 *  - [Maximum kiválasztás](#maximum-kiválasztás)
 *      - [Minimum kiválasztás](#minimum-kiválasztás)
 *  - [Feltételes maximum keresés](#feltételes-maximum-keresés)
 *  - [Keresés](#keresés)
 *  - [Eldöntés](#eldöntés)
 *     - [Mind eldöntés](#mind-eldöntés)
 *  - [Kiválasztás](#kiválasztás)
 *  - [Másolás](#másolás)
 *  - [Kiválogatás](#kiválogatás)
 *  
 *  CTRL + BAL_EGÉR_GOMB -al oda ugrik a függvényhez (Visual Studio 2022-ben)
 */

namespace programozasi_tetelek
{
    internal class Program
    {
        public struct Ember
        {
            public string nev;
            public int magassag;

            public Ember(string nev, int magassag)
            {
                this.nev = nev;
                this.magassag = magassag;
            }

            public readonly override string ToString()
            {
                return $"{{{nev},{magassag}cm}}";
            }
        }
        static void Main()
        {
            Console.WriteLine("Próba program az alapvető programozási tételekhez!\n");

            Console.WriteLine("Összegzés");
            ConsoleLine();
            OsszegzesPelda();
            ConsoleLine(0, 2);

            Console.WriteLine("Megszámolás");
            ConsoleLine();
            MegszamolasPelda();
            ConsoleLine(0, 2);

            Console.WriteLine("Maximum és minimum kiválasztás");
            ConsoleLine();
            MaxMinKivalasztasPelda();
            ConsoleLine(0, 2);

            Console.WriteLine("Feltételes maximum keresés");
            ConsoleLine();
            FeltetelesMaximumPelda();
            ConsoleLine(0, 2);

            Console.WriteLine("Keresés");
            ConsoleLine();
            KeresesPelda();
            ConsoleLine(0, 2);

            Console.WriteLine("Eldöntés");
            ConsoleLine();
            EldontesPelda();
            ConsoleLine(0, 2);

            Console.WriteLine("Mind eldöntés");
            ConsoleLine();
            MindEldontesPelda();
            ConsoleLine(0, 2);

            Console.WriteLine("Kiválasztás");
            ConsoleLine();
            KivalasztasPelda();
            ConsoleLine(0, 2);

            Console.WriteLine("Másolás");
            ConsoleLine();
            MasolasPelda();
            ConsoleLine(0, 2);

            Console.WriteLine("Kiválogatás");
            ConsoleLine();
            KivalogatasPelda();
            ConsoleLine(0, 2);
        }

        private static void KivalogatasPelda()
        {
            double[] homC = { 0, 20, 40, 21, -22 };
            Console.WriteLine("Válogassuk ki a 20C° nagyobb értékeket egy másik tömbbe!");
            Console.WriteLine($"Bemenet: {TombToString(ref homC)}");
            Console.WriteLine("Várt kimenet: [40,21]");
            double[] nagyobb20 = Kivalogatas(ref homC);
            Console.WriteLine($"nagyobb20: {TombToString(ref nagyobb20)}");
        }

        private static double[] Kivalogatas(ref double[] homC)
        {
            double[] nagyobb20 = new double[homC.Length];
            int db = 0;
            for (int i = 0; i < homC.Length; i++)
            {
                if (homC[i] > 20)
                {
                    nagyobb20[db] = homC[i];
                    db++;
                }
            }
            // return nagyobb20; Ha a feltételünk tartalmazhat 0-t akkor inkább ezt használjuk vagy ne tömböt hanem példuál Listát használj!
            return nagyobb20.Where(item => (item != 0)).ToArray();
        }

        private static void MasolasPelda()
        {
            double[] homC = { 0, 20, 40, 21, -22 };
            Console.WriteLine("Szeretnénk a hőmérsékleti adatainkat át konvertálni C° -ból F°-be.");
            Console.WriteLine($"Bemenet: {TombToString(ref homC)}");
            Console.WriteLine("Várt kimenet: [32, 68, 104, 69.8, -7.6]");
            double[] homF = Masolas(ref homC);
            Console.WriteLine($"HomF: {TombToString(ref homF)}");
        }

        private static double[] Masolas(ref double[] homC)
        {
            double[] homF = new double[homC.Length];
            for (int i = 0; i < homC.Length; i++)
            {
                homF[i] = homC[i] * 9 / 5 + 32;
            }
            return homF;
        }

        private static void KivalasztasPelda()
        {
            string[] kartyak = new string[8] { "VII", "VIII", "IX", "X", "Alsó", "Felső", "Király", "Ász" };
            int[] ertekek = new int[8] { 7, 8, 9, 10, 2, 3, 4, 11 };
            string kartya = "Király";
            Console.WriteLine("Magyarkártyáknál kíváncsiak vagyunk egy adott kártya értékére.");
            Console.WriteLine($"Bemenet: Kártya={kartya}" +
                $"Kártyák:{TombToString(ref kartyak)}\n" +
                $"Értékek:{TombToString(ref ertekek)}");
            Console.WriteLine("Várt kimenet: 4");
            (int index, int ertek) = Kivalaszt(ref kartyak, ref ertekek, kartya);
            if (index >= 0)
                Console.WriteLine($"A tömb {index+1}. heylén a következő érték áll: {ertek}");
            else
                Console.WriteLine("Nincs ilyen kártya!");
        }

        private static (int, int) Kivalaszt(ref string[] kartyak, ref int[] ertekek, string kartya)
        {
            int i = 0;
            while (i < kartyak.Length && kartyak[i] != kartya)
                i++;

            if (i == kartyak.Length)
                return (-1, -1);
            else
                return (i, ertekek[i]);
        }

        private static void MindEldontesPelda()
        {
            int[] szamok = { 7, 13, 19, 31, 97 };
            Console.WriteLine("Maradva az előző prímes példánál, döntsük el hogy egy tömb elemei mind prímszám-e vagy sem!");
            Console.WriteLine($"Bemenet: {TombToString(ref szamok)}");
            Console.WriteLine("Várt kimenet: Igaz!");
            if (MindEldontes(ref szamok))
                Console.WriteLine("Igaz!");
            else
                Console.WriteLine("Hamis!");
        }

        private static bool MindEldontes(ref int[] szamok)
        {
            int i = 0;
            bool mind = false;
            while (i < szamok.Length && PrimszamE(szamok[i]))
                i++;
            if (i == szamok.Length)
            {
                mind = true;
            }
            return mind;
        }

        private static void EldontesPelda()
        {
            int szam = 7417;
            Console.WriteLine("Döntsük el hogy 7417 prímszám-e!");
            Console.WriteLine($"Bemenet: {szam}");
            Console.WriteLine("Várt kimenet: Igen prímszám!");
            if (PrimszamE(szam))
                Console.WriteLine("Igen prímszám!");
            else
                Console.WriteLine("Nem prímszám!");
        }

        private static bool PrimszamE(int szam)
        {
            int szamGyoke = (int)Math.Sqrt(szam);
            int i = 2;
            while (i <= szamGyoke && szam % i != 0)
                i++;
            return (i > szamGyoke);
        }

        private static void KeresesPelda()
        {
            double[] homersekletek = { 10, -20, 2.3, -21, 35 };
            Console.WriteLine("Volt-e 20C° a korábbi hőmérsékleti adatainkban?");
            Console.WriteLine($"Bemenet: {TombToString(ref homersekletek)}");
            Console.WriteLine("Várt kimenet: nincs ilyen.");
            (bool van, int index) = Kereses(ref homersekletek);
            if (van)
                Console.WriteLine($"Igen van, korrigált index: {index + 1}. helyen!");
            else
                Console.WriteLine("Nincs ilyen!");
        }

        private static (bool van, int index) Kereses(ref double[] homersekletek)
        {
            int i = 0;
            bool van = false;
            int index = -1;
            while ((i < homersekletek.Length) && homersekletek[i] != 20)
                i++;
            if (i != homersekletek.Length)
            {
                van = true;
                index = i;
            }
            return (van, index);
        }

        private static void FeltetelesMaximumPelda()
        {
            double[] homersekletek = { 10, -20, 2.3, -21, 35 };
            Console.WriteLine("Adjuk meg a legmelegebb fagyos napot.");
            Console.WriteLine($"Bemenet: {TombToString(ref homersekletek)}");
            Console.WriteLine("Várt kimenet: van, index 1(+1), -20");
            (bool van, int index, double ertek) = FeltetelesMaximum(ref homersekletek);
            if (van)
                Console.WriteLine($"Igen van, korrigált index: {index + 1}, érték = {ertek}");
            else Console.WriteLine("Nincs ilyen!");
        }

        private static (bool, int, double) FeltetelesMaximum(ref double[] homersekletek)
        {
            bool van = false;
            int maxind = -1;
            double maxert = -1;
            for (int i = 0; i < homersekletek.Length; i++)
            {
                if (homersekletek[i] < 0)
                {
                    if (van)
                    {
                        if (homersekletek[i] > maxert)
                        {
                            maxind = i;
                            maxert = homersekletek[i];
                        }
                    }
                    else
                    {
                        van = true;
                        maxind = i;
                        maxert = homersekletek[i];
                    }
                }
            }
            return (van, maxind, maxert);
        }

        private static void MaxMinKivalasztasPelda()
        {
            Ember[] emberek = {
                new ("Béla",180),
                new ("Juli", 170),
                new ("Rudolf", 150)
            };
            Console.WriteLine("Mennyi a legmagasabb illetve legalacsonyabb ember magassága?");
            Console.WriteLine($"Bemenet: {TombToString(ref emberek)}");
            Console.WriteLine("Várt kimenet: 180 és 150");
            Console.WriteLine($"Legmagassabb ember mérete: {MaxKivalasztas(ref emberek)}");
            Console.WriteLine($"Legalacsonyabb ember mérete: {MinKivalasztas(ref emberek)}");
        }

        private static int MinKivalasztas(ref Ember[] emberek)
        {
            int minErtek = emberek[0].magassag;
            for (int i = 1; i < emberek.Length; i++)
            {
                if (emberek[i].magassag < minErtek)
                {
                    minErtek = emberek[i].magassag;
                }
            }
            return minErtek;
        }

        private static int MaxKivalasztas(ref Ember[] emberek)
        {
            int maxErtek = emberek[0].magassag;
            for (int i = 1; i < emberek.Length; i++)
            {
                if (emberek[i].magassag > maxErtek)
                {
                    maxErtek = emberek[i].magassag;
                }
            }
            return maxErtek;
        }

        private static void MegszamolasPelda()
        {
            double[] homersekletiAdatok = { 10, -20, 2.3, -21, 35 };
            Console.WriteLine("Hányszor fagyott a hőmérsékleti adatok alapján?");
            Console.WriteLine($"Bemenet: {TombToString(ref homersekletiAdatok)}");
            Console.WriteLine("Várt kimenet: 2");
            Console.WriteLine($"Összesen: {Megszamolas(ref homersekletiAdatok)} napon fagyott.");
        }
        private static double Megszamolas(ref double[] elemek)
        {
            int darab = 0;
            for (int i = 0; i < elemek.Length; i++)
            {
                if (elemek[i] < 0)
                {
                    darab++;
                }
            }
            return darab;
        }

        private static void OsszegzesPelda()
        {
            int[] osztalyok = { 20, 25, 15, 20, 20 };
            Console.WriteLine("Hány gyerek jár egy iskolában, ha tudjuk az osztályok létszámát?");
            Console.WriteLine($"Bemenet: {TombToString(ref osztalyok)}");
            Console.WriteLine("Várt kimenet: 100");
            Console.WriteLine($"Összesen: {Osszegzes(ref osztalyok)} gyerek.");
        }
        private static int Osszegzes(ref int[] elemek)
        {
            int ossz = 0;
            for (int i = 0; i < elemek.Length; i++)
            {
                ossz += elemek[i];
            }
            return ossz;
        }

        private static void ConsoleLine(int spaceBefore = 0, int spaceAfter = 0)
        {
            int bufferWidth;
            for (int i = 0; i < spaceBefore; i++)
                Console.WriteLine();
            try{
            bufferWidth = Console.BufferWidth;
            } catch (Exception e){
                Console.WriteLine(e.ToString());
                bufferWidth = 20;
            }
            for (int i = 0; i < bufferWidth; i++)
                Console.Write('#');
            for (int i = 0; i < spaceAfter + 1; i++)
                Console.WriteLine();
        }

        private static string TombToString<T>(ref T[] tomb)
        {
            StringBuilder sb = new();
            sb.Append('{');
            foreach (var t in tomb)
            {
                if (t != null)
                {
                    sb.Append(t.ToString());
                    sb.Append(';');
                }
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append('}');
            return sb.ToString();
        }
    }
}