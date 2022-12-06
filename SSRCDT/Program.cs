﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSRCDT
{
    class Program
    {
        static async Task Main(string[] args)
        {
            MeatTypeLoader loader = new MeatTypeLoader();
            Console.WriteLine("hello");
            List<Fryer> normal_fryers = new List<Fryer> { new Fryer(false), new Fryer(false), new Fryer(false) };
            List<Fryer> kentucky_fryers = new List<Fryer> { new Fryer(true) };
            MeatHolder meatHolder = new MeatHolder();
            //TODO record class ami tarolja a sutoket es a methodokat

            string input = "";
            Console.WriteLine("Udv az appban!");
            while (input != "q")
            {
                Console.WriteLine("A segitsegert hasznald a '?' parancsot.");
                Console.WriteLine("Kilepes: 'q' parancs.");
                input = Console.ReadLine();
                switch (input)
                {
                    case "fry":
                        {
                            Console.WriteLine("Milyen húst szeretnél sütni? (pl. StripsMeat)");
                            string meatType = Console.ReadLine();
                            if (loader.Meats.Contains(meatType))
                            {
                                Console.WriteLine("Hány darabot sütsz? (pl. 30)");
                                bool isParsable = int.TryParse(Console.ReadLine(), out int meatCount);
                                if (isParsable)
                                {
                                    switch (meatType)  //Muszaj a switch. Elvileg az Activatorhoz tudnunk kene statikusan a tipust amire castolnank.
                                    {
                                        case "StripsMeat":
                                            {
                                                try
                                                {
                                                    int i = 0;
                                                    while (!normal_fryers[i].IsFree)
                                                    {
                                                        i += 1;
                                                    }

                                                    Task.Factory.StartNew(() => normal_fryers[i].FryMeat(new StripsMeat(meatCount), meatHolder));
                                                }
                                                catch (ArgumentOutOfRangeException)
                                                {
                                                    Console.WriteLine("Nincs szabad suto!");
                                                }
                                                break;
                                            }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Hiba: Nem számot adtál meg!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Hiba: Nem megfelelő hús típus!");
                            }
                            break;

                        }
                    case "?":
                        {
                            Console.WriteLine("A suteshez hasznald a 'fry' parancsot.");
                            break;
                        }
                    default: { Console.WriteLine("Helytelen parancs!"); break; };
                }
            }

        }

    }
}
