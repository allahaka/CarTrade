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

        readonly CarGenerator carG = new CarGenerator();
        readonly ClientGenerator cg = new ClientGenerator();
        readonly Helpers help = new Helpers();

        Game game;

        public Game(List<Player> players, string gameDifficulty, List<Client> clients, List<Car> carShop){
            this.players = players;
            this.gameDifficulty = gameDifficulty;
            this.clients = clients;
            this.carShop = carShop;
        }

        public static List<Player> CreatePlayers(List<string> list, string difficulty){
            List<Player> players = new List<Player>();
            list.RemoveAt(list.Count - 1);
            int iteration = Convert.ToInt32(list[0]);
            list.RemoveAt(0);

            for(int i=0; i < iteration; i++){
                players.Add(new Player(list[i], Game.getAmountFromDifficulty(difficulty)));
            }

            return players;
        }

        public static string GetDifficulty(List<string> list){
            string difficulty = list[^1];
            return difficulty;
        }

        public static decimal getAmountFromDifficulty(string difficulty){
            var amount = difficulty switch{
                "easy" => 1000000,
                "medium" => 400000,
                "hard" => 200000,
                _ => 200000,
            };
            return Convert.ToDecimal(amount);
        }

        public void Start(Game game){
            this.game = game;
            startingAmount = getAmountFromDifficulty(gameDifficulty);
            currentPlayer = players[0];
            currentPlayerIndex = 0;
            ConsoleKeyInfo ck = Menus.MainMenu(currentPlayer);
            MainMenuLogic(ck);
        }
        
        public static void BackToMainMenu(Player currentPlayer, Game game){
            ConsoleKeyInfo ck = Menus.MainMenu(currentPlayer);
            game.MainMenuLogic(ck);
        }

        public void MainMenuLogic(ConsoleKeyInfo ck){
            switch(ck.Key){
                case ConsoleKey.B:
                    Menus.Clean();
                    Menus.BuyCarMenu(carShop, currentPlayer, game);
                    break;
                case ConsoleKey.V:
                    Menus.Clean();
                    Menus.ViewOwnedCarsMenu(currentPlayer, game);
                    break;
                case ConsoleKey.A:
                    Menus.Clean();
                    Menus.BuyAdMenu(currentPlayer, game);
                    break;
                case ConsoleKey.S:
                    Menus.Clean();
                    Menus.SellCarMenu(currentPlayer, game, clients);
                    break;
                case ConsoleKey.H:
                    Menus.Clean();
                    Menus.CheckHistoryMenu();
                    break;
                case ConsoleKey.P:
                    Menus.Clean();
                    Menus.CheckPaymentsMenu(currentPlayer, game);
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
            if(currentPlayer.account >= car.FinalPrice() + 0.02m * car.FinalPrice()){
                carShop = carG.GenerateCar(30);
                currentPlayer.account -= car.FinalPrice() + 0.02m * car.FinalPrice();
                currentPlayer.ownedCars.Add(car);
                Console.WriteLine($"You paid additional 2% of taxes which is {0.02m * car.FinalPrice()} \nNext Player move\n");
                NextPlayer();
                BackToMainMenu(currentPlayer, game);
            }else{
                Console.WriteLine("You don't have enough money to buy this \n\n");
                BackToMainMenu(currentPlayer, game);
            }
        }

        public void RepairCarMenuLogic(Player player, int index, decimal price, int chance) {
            Car car = player.ownedCars[index];
            if(price <= player.account){
                player.account -= price;
                car.RepairCar(chance);
                Console.WriteLine("Car was given to repair check if it was a success \nNext Player move\n");
                NextPlayer();
                BackToMainMenu(player, game);
            }else{
                Console.WriteLine("Not enough money to repair this car \n\n");
                BackToMainMenu(player, game);
            }
        }

        public void BuyAdMenuLogic(int value){
            if(value <= currentPlayer.account){
                currentPlayer.account -= value;
                List<Client> newClients = new List<Client>();
                var number = value switch{
                    0 => 5,
                    1000 => 2,
                    300 => 1,
                    _ => 1,
                };
                if(value == 0){
                    newClients = cg.GenerateClient(help.RandomNumber(number));
                }else{
                    newClients = cg.GenerateClient(number);
                }

                foreach(Client c in newClients){
                    clients.Add(c);
                }
                Console.WriteLine("You markted your buisness \nNext Player move\n");
                NextPlayer();
                BackToMainMenu(currentPlayer, game);
            }else{
                Console.WriteLine("Not enough money to buy this add \n\n");
                BackToMainMenu(currentPlayer, game);
            }
        }

        public void SellCarMenuLogic(Car car){
            currentPlayer.account += car.FinalPrice() * 0.98m;
            currentPlayer.ownedCars.Remove(car);
            int numberOfClients = clients.Count;
            clients = cg.GenerateClient(numberOfClients);
            Console.WriteLine($"You sold the Car, you paid 2% of Taxes which was {car.FinalPrice() * 0.02m} \nNext Player move\n");
            NextPlayer();
            BackToMainMenu(currentPlayer, game);
        }

        //TODO
        public void CheckHistoryMenuLogic(){

        }
        
        public void CheckPaymentsMenuLogic(decimal sum){
            sum *= 5.0m;
            if(currentPlayer.account >= sum){
                currentPlayer.account -= sum;
                foreach(Car car in currentPlayer.ownedCars){
                    car.RepairCar(100);
                }
                Console.WriteLine($"Cars were given to repair check if it was a success \nNext Player move\n");
                NextPlayer();
                BackToMainMenu(currentPlayer, game);
            }else{
                Console.WriteLine("Not enough money to Repair all cars \n\n");
                BackToMainMenu(currentPlayer, game);
            }
        }

        public void NextPlayer(){ 
            if(players.Count == 1){
                currentPlayer.MadeMove();
            }else{ 
                if(currentPlayer == players[^1]){
                    currentPlayer.MadeMove();
                    currentPlayerIndex = 0;
                    currentPlayer = players[0];
                }else{
                    currentPlayer.MadeMove();
                    currentPlayerIndex++;
                    currentPlayer = players[currentPlayerIndex];
                }
            }
        }
    }
}
