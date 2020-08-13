using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ConsoleApp1
{

    class Program
    {
        //could've built more error proofing with bets over current balances and age verification.
        //overall pretty satisfied with results.


        static void Main(string[] args)
        {
            //Either preset all like this or mylist1 = mylist2
            List<string> myList1 = new List<string> { "A", "K", "K", "Q", "Q", "Q", "Q", "J", "J", "J", "J", "J", "J" };
            List<string> myList2 = new List<string> { "A", "K", "K", "Q", "Q", "Q", "Q", "J", "J", "J", "J", "J", "J" };
            List<string> myList3 = new List<string> { "A", "K", "K", "Q", "Q", "Q", "Q", "J", "J", "J", "J", "J", "J" };

            int balance = 20;
            int bet = 1;
            int win;

            int currentAge;
            int birthYear;

            Console.WriteLine("What is your year of birth?");
            bool ageVerification = Int32.TryParse(Console.ReadLine(), out birthYear);
            if (ageVerification)
            {
                currentAge = DateTime.Now.Year - birthYear;

                if (currentAge < 18)
                {
                    Console.WriteLine("You are not old enough to use this application");
                }
                else
                {


                    while (true)
                    {
                        Random rnd = new Random();
                        Console.WriteLine("what is your bet? (default: 1)");

                        int myBet;
                        bool success1 = Int32.TryParse(Console.ReadLine(), out myBet);
                        if (success1)
                        {
                            bet = myBet;
                            Console.WriteLine($"Your bet is now: {bet}");
                        }
                        else
                        {
                            Console.WriteLine("Enter a number");
                        }

                        while (balance >= 0)
                        {
                            balance = balance - bet;
                            Console.ReadLine();

                            //myList1.ForEach(Console.WriteLine);
                            //Console.WriteLine("shuffling lists");


                            //randomizing all lists
                            Myextensions.Shuffle(myList1);
                            Myextensions.Shuffle(myList2);
                            Myextensions.Shuffle(myList3);

                            //picking symbol randomly from every list(could've done with once but I guess this is more random
                            int i = rnd.Next(myList1.Count);
                            int j = rnd.Next(myList2.Count);
                            int k = rnd.Next(myList3.Count);

                            //symbol to a string
                            string ms1 = myList1[i];
                            string ms2 = myList1[j];
                            string ms3 = myList1[k];

                            Console.WriteLine($"{ms1} {ms2} {ms3} ");

                            if (ms1.Equals(ms2) && ms1.Equals(ms3))
                            {

                                switch (ms1)
                                {

                                    case "A":
                                        win = 20;
                                        win = win * bet;
                                        Console.WriteLine("Last win: " + win);
                                        balance = balance + win;
                                        Console.WriteLine("Current balance: " + balance);
                                        break;

                                    case "K":
                                        win = 8;
                                        win = win * bet;
                                        Console.WriteLine("Last win: " + win);
                                        balance = balance + 8 * bet;
                                        Console.WriteLine("Current balance: " + balance);
                                        break;
                                    case "Q":
                                        win = 4;
                                        win = win * bet;
                                        Console.WriteLine("Last win: " + win);
                                        balance = balance + 4 * bet;
                                        Console.WriteLine("Current balance: " + balance);
                                        break;
                                    case "J":
                                        win = 2;
                                        win = win * bet;
                                        Console.WriteLine("Last win: " + win);
                                        balance = balance + 2 * bet;
                                        Console.WriteLine("Current balance: " + balance);
                                        break;
                                }
                            }
                            else if (balance < 1)
                            {
                                Console.WriteLine("Out of cash, do you want to add more money? yes/no");
                                balance = 0;
                                if (Console.ReadLine() == "yes")
                                {
                                    Console.WriteLine("How much?");
                                    int addM;
                                    bool success2 = Int32.TryParse(Console.ReadLine(), out addM);
                                    if (success2)
                                    {
                                        balance = balance + addM;
                                        Console.WriteLine($"{addM} added to your balance. Your Current balance is {balance}");
                                        Console.WriteLine("place your bet");
                                        //int cBet;
                                        bool success3 = Int32.TryParse(Console.ReadLine(), out myBet);
                                        if (success3)
                                        {
                                            bet = myBet;
                                            Console.WriteLine("bet is now: " + bet);
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter a number");
                                    }

                                }
                                else if (Console.ReadLine() == "no")
                                {
                                    //shutting down doesnt work 100%, game keeps on running in background.
                                    Environment.Exit(0);
                                }
                                else if (balance < bet)
                                {

                                    Console.WriteLine("cant go to negative");
                                }
                                else
                                {
                                    Console.WriteLine("Enter a number");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Last win: 0");
                                Console.WriteLine("Current balance: " + balance);

                            }

                        }
                    }

                }
            }
            else
            {
                Console.WriteLine("try again");
            }
        }

    }
    public static class Myextensions
    {
        private static Random rng = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
    

}
