using System;
using System.Collections.Generic;

namespace CarTrade {
    class Game {

        public List<Player> players;
        public Player currentPlayer;
        public int currentPlayerIndex;

        public string gameDifficulty;
        public List<Client> clients;
        public List<Car> carShop;
        private decimal startingAmount;

        public Game(List<Player> players, string gameDifficulty, List<Client> clients, List<Car> carShop){
            this.players = players;
            this.gameDifficulty = gameDifficulty;
            this.clients = clients;
            this.carShop = carShop;
        }

        public static List<Player> CreatePlayers(List<string> list, string difficulty) {
            List<Player> players = new List<Player>();
            list.RemoveAt(list.Count - 1);
            int iteration = Convert.ToInt32(list[0]);
            list.RemoveAt(0);

            for (int i=0; i<iteration; i++){
                players.Add(new Player(list[i], Game.getAmountFromDifficulty(difficulty)));
            }

            return players;
        }

        public static string GetDifficulty(List<string> list){
            string difficulty = list[^1];
            return difficulty;
        }

        public static decimal getAmountFromDifficulty(string difficulty){
            var amount = difficulty switch {
                "easy" => 200000,
                "medium" => 100000,
                "hard" => 50000,
                _ => 200000,
            };
            return Convert.ToDecimal(amount);
        }

        //TODO
        public void Start(){
            startingAmount = getAmountFromDifficulty(gameDifficulty);
            currentPlayer = players[0];
            currentPlayerIndex = 0;
            ConsoleKeyInfo ck = Menus.MainMenu(currentPlayer);
            OptionChoiceMainMenu(ck);
        }

        public void OptionChoiceMainMenu(ConsoleKeyInfo ck){
            switch (ck.Key) {
                case ConsoleKey.B:
                    Menus.Clean();
                    Menus.BuyCarMenu();
                    break;
                case ConsoleKey.V:
                    Menus.Clean();
                    Menus.ViewOwnedCarsMenu();
                    break;
                case ConsoleKey.R:
                    Menus.Clean();
                    Menus.RepairCarMenu();
                    break;
                case ConsoleKey.A:
                    Menus.Clean();
                    Menus.BuyAdMenu();
                    break;
                case ConsoleKey.S:
                    Menus.Clean();
                    Menus.SellCarMenu();
                    break;
                case ConsoleKey.H:
                    Menus.Clean();
                    Menus.CheckHistoryMenu();
                    break;
                case ConsoleKey.P:
                    Menus.Clean();
                    Menus.CheckPaymentsMenu();
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
