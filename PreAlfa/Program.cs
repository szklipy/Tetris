using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreAlfa
{
    class Program
    {//EZ A VÉGLEGES VERZIÓ!!!!!
        public static int[,] palya = new int[12, 21];
        public static bool jatek = true;
        public static int pontok;
        static void Main(string[] args)
        {
            JatekTer();
            Elemek kocka = new Elemek();
            Random r = new Random();
            kocka.Spawn(r);
            Kirajzol();
            pontok = 0;

            Console.SetCursorPosition(15, 1);

            Console.WriteLine("A forma mozgatása a nyilakkal történik, ha meguntad nyomj egy Esc-et!");

            bool leert = false;

            while (jatek)
            {
                ConsoleKey be = Console.ReadKey().Key;



                if (be == ConsoleKey.DownArrow)
                {
                    if (kocka.VanEValamiAlatta() == false)//vagyis nincs alatta semmi
                    {
                        //kocka.Torles();
                        kocka.Mozgat("le");
                        Kirajzol();
                    }
                    else//vagyis ha vanealatta == false, akkor
                    {

                        leert = true;
                        pontok += 10;
                        
                    }

                }
                else if (be == ConsoleKey.RightArrow)
                {
                    if (kocka.VanEValamiJobbra() == true)
                    {
                        //kocka.Torles();
                        kocka.Mozgat("jobbra");
                        Kirajzol();
                    }
                }
                else if (be == ConsoleKey.LeftArrow)
                {
                    if (kocka.VanEValamiBalra() == true)
                    {
                        //kocka.Torles();
                        kocka.Mozgat("balra");
                        Kirajzol();
                    }
                }
                else if (be==ConsoleKey.Spacebar)
                {
                    kocka.Torles();
                    kocka.Forgatas(kocka.MelyikElem);
                    //kocka.MelyikElem = 
                    Kirajzol();
                }
                else if (be == ConsoleKey.Escape)
                {
                    jatek = false;
                }


                //frissítés akkor van ha egy forma már nem tud lejebb menni, vagyis ha a leert igaz lesz

                if (leert == true)//ilydnkor lehet/kell is frissíteni a játékot, hogy van e megtelt sor, ha igen akkor azokat lehet törölni
                {

                    if (VegeVanE() == true)
                    {
                        Console.SetCursorPosition(1, 5);
                        Console.WriteLine("GAME OVER!");
                        Console.SetCursorPosition(1, 6);
                        Console.WriteLine("Score: "+pontok);
                        Program.jatek = false;
                        Console.SetCursorPosition(1, 7);
                        Console.WriteLine("Még egy:"+"\n"+" i/n?");
                        string ujJatek = Console.ReadLine();//akar e újat játszani?
                        if (ujJatek=="i"||ujJatek=="igen")
                        {
                            Console.Clear();//a pontok miatt, mert különben nem tűnne el
                            kocka.Torles();
                            JatekTer();
                            kocka.Reset();
                            leert = true;   //ilyenkor automatikusan spawnol egy elemet NORMÁLISAN
                            pontok = 0;
                            Kirajzol();
                            Program.jatek = true;
                        }
                        


                    }
                    else
                    {
                        PalyaRendezes();//itt kapja a pontokat is
                        Console.SetCursorPosition(15, 10);
                        Console.WriteLine("Pontok: " + pontok);
                        kocka.Spawn(r);
                        Kirajzol();
                        leert = false;
                    }
                }

            }
        }

        public static void JatekTer()      //(ez lenne a teljes pálya, az ötlet.txt ben van a magyarázat
        {
            for (int i = 0; i < palya.GetLength(0); i++)
            {
                for (int j = 0; j < palya.GetLength(1); j++)
                {
                    if (i == 0 || i == palya.GetLength(0) - 1 || j == palya.GetLength(1) - 1)
                    {
                        palya[i, j] = 2;
                    }
                    else
                    {
                        palya[i, j] = 0;
                    }
                }
            }
        }

        public static void Kirajzol()
        {
            for (int i = 0; i < palya.GetLength(0); i++)
            {
                for (int j = 0; j < palya.GetLength(1); j++)
                {
                    if (palya[i, j] == 2)
                    {
                        Console.ForegroundColor = (ConsoleColor)4;  //ez csak egy random szín. hogy meg lehessen külömböztetni a formát a pályától
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine("█");//"■"
                    }
                    else if (palya[i, j] == 0)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine(" ");
                    }
                    else if (palya[i, j] == 1)
                    {
                        Console.ForegroundColor = (ConsoleColor)8;
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine("█");
                    }
                }
            }
        }

        public static bool VegeVanE()
        {
            int x = 1;
            while (x<=palya.GetLength(0)-1)
            {
                if (palya[x, 3] == 1)
                {
                    return true;
                }
                else
                {
                    x++;
                }
            }
            return false;
        }

        //TORLES
        public static int MarUresSor()
        {
            int yIdx = palya.GetLength(1) - 1;//ez így a 20. sor
            while (yIdx > 0)
            {
                int x = 1;
                while (x < palya.GetLength(0) - 2 && palya[x, yIdx] == 0)
                {
                    x++;
                }
                if (x == palya.GetLength(0) - 2)
                {
                    return yIdx;
                }
                yIdx--;
            }
            return 0;
        }


        public static int TorolendoSor()
        {
            int yIdx = 0;

            while (yIdx < palya.GetLength(1) - 1)
            {
                int x = 1;
                while (x <= palya.GetLength(0) - 2 && palya[x, yIdx] == 1)
                {
                    x++;
                }
                x--;//itt azért, mert 11 lenne és az már sok
                if (x == palya.GetLength(0) - 2)
                {
                    return yIdx;      //mert 0 tól megy
                }
                yIdx++;
            }
            return 0;
        }
        public static void Torol(int yIdx)
        {
            for (int i = 1; i < palya.GetLength(0) - 2; i++)
            {
                palya[i, yIdx] = 0;
            }
        }
        //ez a kettő lehet akár private is
        public static void Atmasol(int yIdx)
        {
            for (int i = 1; i < palya.GetLength(0) - 2; i++)
            {
                palya[i, yIdx] = palya[i, yIdx - 1];
            }
        }

        public static void PalyaRendezes()
        {//letörli, majd átmásolja, addig amíg nincs üres sor, majd ujranézi, hogy van e törlendő és előlről
            int mettol = TorolendoSor();//megkeresi az első sort ami tele van
            int meddig = MarUresSor();
            while (mettol > 0)
            {
                pontok += 100;//minden sortörlésnél kap 100 at
                              //az első tele sort letörli
                for (int i = 1; i < palya.GetLength(0) - 1; i++)
                {
                    palya[i, mettol] = 0;
                }
                while (mettol > meddig)
                {//a törölt sor fölött mindent lemásol 1 el addig amíg teljesen üres sor nem jön
                    for (int i = 1; i < palya.GetLength(0) - 1; i++)
                    {
                        palya[i, mettol] = palya[i, mettol - 1];

                    }
                    mettol--;
                }//megnézi ujra hogy van e teljes sor, és kezdődik előlről
                mettol = TorolendoSor() - 1;//ha ez nincs itt akkor nagy bajok lesznek
            }
        }
    }
}

