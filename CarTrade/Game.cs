using System;
using System.Collections.Generic;

namespace CarTrade {
    class Game{

        public List<Player> players;
        public Player currentPlayer;
        public int currentPlayerIndex;

        public string gameDifficulty;
        public List<Client> clients;
        public List<Car> carShop;
        private decimal startingAmount;

        CarGenerator carG = new CarGenerator();
        ClientGenerator cg = new ClientGenerator();

        Game game;

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
        public void Start(Game game){
            this.game = game;
            startingAmount = getAmountFromDifficulty(gameDifficulty);
            currentPlayer = players[0];
            currentPlayerIndex = 0;
            ConsoleKeyInfo ck = Menus.MainMenu(currentPlayer);
            MainMenuLogic(ck);
        }
        
        public static void BackToMainMenu(Player currentPlayer, Game game) {
            ConsoleKeyInfo ck = Menus.MainMenu(currentPlayer);
            game.MainMenuLogic(ck);
        }

        public void MainMenuLogic(ConsoleKeyInfo ck){
            switch (ck.Key) {
                case ConsoleKey.B:
                    Menus.Clean();
                    Menus.BuyCarMenu(carShop, currentPlayer, game);
                    break;
                case ConsoleKey.V:
                    Menus.Clean();
                    Menus.ViewOwnedCarsMenu(currentPlayer, game);
                    break;
                case ConsoleKey.R:
                    Menus.Clean();
                    ConsoleKeyInfo ckbrcm = Menus.RepairCarMenu();
                    RepairCarMenuLogic(ckbrcm);
                    break;
                case ConsoleKey.A:
                    Menus.Clean();
                    ConsoleKeyInfo ckbbam = Menus.BuyAdMenu();
                    BuyAdMenuLogic(ckbbam);
                    break;
                case ConsoleKey.S:
                    Menus.Clean();
                    ConsoleKeyInfo ckbscm = Menus.SellCarMenu();
                    SellCarMenuLogic(ckbscm);
                    break;
                case ConsoleKey.H:
                    Menus.Clean();
                    ConsoleKeyInfo ckbchm = Menus.CheckHistoryMenu();
                    CheckHistoryMenuLogic(ckbchm);
                    break;
                case ConsoleKey.P:
                    Menus.Clean();
                    ConsoleKeyInfo ckbcpm = Menus.CheckPaymentsMenu();
                    CheckPaymentsMenuLogic(ckbcpm);
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
                default:
                    Menus.Clean();
                    BackToMainMenu(currentPlayer, game);
                    break;
            }
        }

        public void BuyCarMenuLogic(Car car){
            if(currentPlayer.account >= car.FinalPrice()) {
                carShop = carG.GenerateCar(30);
                currentPlayer.account -= car.FinalPrice();
                currentPlayer.ownedCars.Add(car);
                BackToMainMenu(currentPlayer, game);
            } else {
                Console.WriteLine("You don't have enough money to buy this \n\n");
                BackToMainMenu(currentPlayer, game);
            }

        }

        public static void RepairCarMenuLogic(ConsoleKeyInfo ck) {

        }

        public static void BuyAdMenuLogic(ConsoleKeyInfo ck) {

        }

        public static void SellCarMenuLogic(ConsoleKeyInfo ck) {

        }

        public static void CheckHistoryMenuLogic(ConsoleKeyInfo ck) {

        }
        
        public static void CheckPaymentsMenuLogic(ConsoleKeyInfo ck) {

        }
    }
}
