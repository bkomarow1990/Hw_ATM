using System;
using System.Collections.Generic;
namespace ATM
{
    class Number
    {
        private int number;
        public void Inc()
        {
            ++number;
        }
        public Number(int number)
        {
            this.number = number;
        }
        public Number() : this(0)
        {

        }
        public override string ToString()
        {
            return $"Number : {number}";
        }
    }
    public class Account
    {
        private String login = "admin";
        private String pass = "admin";
        public Account(String login, String pass)
        {
            this.login = login;
            this.pass = pass;
        }
    }
    public interface ICard
    {
        void setPin(int old, int now);
        void setMoney(int money);
    }
    class Card : ICard
    {
        public void setPin(int old, int now)
        {
            if (old.ToString().Length!= 4 || now.ToString().Length != 4)
            {
                Console.WriteLine($"Enter correct Pin code");
                return;
            }
            if (old == pin)
            {
                pin = now;
            }
        }
        public void setMoney(int money)
        {
            this.money = money;
        }
        public int getBalance()
        {
            return money;
        }
        private int pin = 1111;
        private int money = 0;
        public Card(int pin = 1111, int money = 0)
        {
            setPin(1111, pin);
        }

    }
    class ATM
    {

        private Card card = new Card();
        public ATM(int id, Card card)
        {
            this.card = card;
            this.id = id;
        }
        public void showBalance()
        {
            Console.WriteLine($"Balance: {card.getBalance()}");

        }
        public void addMoney(int money)
        {
            card.setMoney(card.getBalance() + money);
        }
        public void withdraw(int money)
        {
            if (card.getBalance() - money < 0)
            {
                card.setMoney(0);
                return;
            }
            card.setMoney(card.getBalance()-money);
        }
        private int id=0;
    }


        class Program
        {
            static void InitCard(ref Card card)
            {
                Console.WriteLine("Enter PIN CODE ...");
                int pin = int.Parse(Console.ReadLine());
                card.setPin(1111, pin);
                Console.WriteLine("Enter balance in card ...");
                int money = int.Parse(Console.ReadLine());
                card.setMoney(money);
            }
        
            static void Main(string[] args)
            {
                Card c1= new Card();
                InitCard(ref c1);
                Console.Clear();
                ATM atm = new ATM(1,c1);

                int answer=333;
                while (answer != 0)
                {
                    Console.WriteLine($"=============================================");
                    Console.WriteLine($"1. Show balance ");
                    Console.WriteLine($"2. Add money");
                    Console.WriteLine($"3. Withdraw money");
                    Console.WriteLine($"0. EXIT ");
                    Console.WriteLine($"=============================================");
                    answer = int.Parse(Console.ReadLine());          
                    switch (answer)
                    {
                        case 1:
                            atm.showBalance();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 2:
                            {
                                Console.WriteLine($"Enter money");
                                int money = int.Parse(Console.ReadLine());
                                atm.addMoney(money);
                                Console.Clear();
                                break;
                        }
                        case 3:
                            {
                                Console.WriteLine($"Enter money");
                                int money = int.Parse(Console.ReadLine());
                                atm.withdraw(money);
                                Console.Clear();
                            }
                            break;
                        default:
                            break;
                    }
                

                }
            }
        }
    }
//  class ATM  : login* password*
//