using System;
using System.Collections.Generic;
using System.Text;

namespace CarTrade
{
    class Menus
    {
        public void MainMenu() {
            Console.WriteLine("1. [B]uy a car                           2. [V]iew Owned cars");
            Console.WriteLine("3. [R]epair a car                        4. Buy an [A]d");
            Console.WriteLine("5. [S]ell a car                          6. [C]heck account");
            Console.WriteLine("7. Check [H]istory of actions            8. Check sum of all [P]ayments for owned cars");
            ConsoleKeyInfo ck = Console.ReadKey();

            switch (ck.Key) {
                case ConsoleKey.B:
                    this.BuyCarMenu();
                    break;
                case ConsoleKey.V:
                    this.ViewOwnedCarsMenu();
                    break;
                case ConsoleKey.R:
                    this.RepairCarMenu();
                    break;
                case ConsoleKey.A:
                    this.BuyAdMenu();
                    break;
                case ConsoleKey.S:
                    this.SellCarMenu();
                    break;
                case ConsoleKey.C:
                    this.CheckAccountMenu();
                    break;
                case ConsoleKey.H:
                    this.CheckHistoryMenu();
                    break;
                case ConsoleKey.P:
                    this.CheckPaymentsMenu();
                    break;
            } 
        }

        public void BuyCarMenu() { 
        
        }

        public void ViewOwnedCarsMenu()
        {

        }

        public void RepairCarMenu()
        {

        }

        public void BuyAdMenu()
        {

        }

        public void SellCarMenu()
        {

        }

        public void CheckAccountMenu()
        {

        }
        public void CheckHistoryMenu()
        {

        }
        public void CheckPaymentsMenu()
        {

        }
    }
}
