using System;
using System.Collections.Generic;

namespace CarTrade
{
    /// <summary>
    /// 
    /// </summary>
    class Menus
    {

        /// <summary>
        /// Cleans the screen
        /// </summary>
        public static void Clean() {
            Console.Clear();
        }

        /// <summary>
        /// Collects all needed information about the game, as difficulty, amount of players and nicks of players
        /// </summary>
        /// <returns>List of <see cref="String"/> with all player names difficulty and amount of players in it</returns>
        public List<string> StartGame(){
            List<string> result = new List<string>();
            int numberPlayers;

            Console.WriteLine("How many players: ");
            
            while (!int.TryParse(Console.ReadLine(), out numberPlayers)) {
                Console.WriteLine("Please Enter a valid numerical value:");
            }

            result.Add(numberPlayers.ToString());

            Clean();

            for(int i=0; i<numberPlayers; i++){
                Console.WriteLine($"Enter the names of player{i}: ");
                string name = Console.ReadLine();
                result.Add(name);
                Clean();
            }

            Console.WriteLine("On what difficulty you want to play? ([E]asy, [M]edium, [H]ard)");

            while(true){
                string a = Console.ReadLine().ToLower();
                if( a == "e" || a == "easy"){
                    result.Add("easy");
                    break;
                }else if(a == "m" || a == "medium") {
                    result.Add("medium");
                    break;
                }else if(a == "h" || a == "hard"){
                    result.Add("hard");
                    break;
                }else{
                    Console.WriteLine("Wrong Input");
                }
            }

            Clean();

            return result;
        }


        /// <summary>
        /// Shows Main Menu for a player with actions that player can do
        /// </summary>
        /// <param name="currentPlayer"> Takes <see cref="Player"/> as param for current player info </param>
        /// <returns> ConsoleKeyInfo for Game to work on what player choose</returns>
        public static ConsoleKeyInfo MainMenu(Player currentPlayer) {
            Console.WriteLine($"Player: {currentPlayer.name}, Moves: {currentPlayer.amountOfMoves}, Account: {currentPlayer.account} \n");
            Console.WriteLine("[B]uy a car                                      [V]iew Owned cars");
            Console.WriteLine("Buy an [A]d                                      [S]ell a car ");
            Console.WriteLine("Check [H]istory of actions                       Check sum of all [P]ayments for owned cars");
            Console.WriteLine("[Q]uit");
            return Console.ReadKey();
        }

        public static void BuyCarMenu(List<Car> cars, Player currentPlayer, Game game, int index = 0, bool bought = false){
            if(bought == true){
                game.BuyCarMenuLogic(cars[index]);
            } else {
                Console.WriteLine(cars[index].DisplayCar()[0]);
                if (cars[index].type == "cargo")
                    Console.WriteLine($"Cargo Space: {cars[index].cargoSpace}");
                Console.WriteLine(cars[index].DisplayCar()[1]);
                
                if(index == cars.Count - 1) {
                    Console.WriteLine("[B]uy        [P]revious");
                    Console.WriteLine("[M]ain Menu");
                    ConsoleKeyInfo ck = Console.ReadKey();

                    switch (ck.Key) {
                        case ConsoleKey.B:
                            Menus.Clean();
                            Menus.BuyCarMenu(cars, currentPlayer, game, index, true);
                            break;
                        case ConsoleKey.P:
                            Menus.Clean();
                            Menus.BuyCarMenu(cars, currentPlayer, game, index - 1, false);
                            break;
                        case ConsoleKey.M:
                            Menus.Clean();
                            Game.BackToMainMenu(currentPlayer, game);
                            break;
                        default:
                            Menus.Clean();
                            Menus.BuyCarMenu(cars, currentPlayer, game, index, false);
                            break;
                    }
                } else if (index > 0) {
                    Console.WriteLine("[B]uy        [P]revious [N]ext");
                    Console.WriteLine("[M]ain Menu");
                    ConsoleKeyInfo ck = Console.ReadKey();

                    switch (ck.Key) {
                        case ConsoleKey.B:
                            Menus.Clean();
                            Menus.BuyCarMenu(cars, currentPlayer, game, index, true);
                            break;
                        case ConsoleKey.P:
                            Menus.Clean();
                            Menus.BuyCarMenu(cars, currentPlayer, game, index - 1, false);
                            break;
                        case ConsoleKey.N:
                            Menus.Clean();
                            Menus.BuyCarMenu(cars, currentPlayer, game, index + 1, false);
                            break;
                        case ConsoleKey.M:
                            Menus.Clean();
                            Game.BackToMainMenu(currentPlayer, game);
                            break;
                        default:
                            Menus.Clean();
                            Menus.BuyCarMenu(cars, currentPlayer, game, index, false);
                            break;
                    }
                } else {
                    Console.WriteLine("[B]uy        [N]ext");
                    Console.WriteLine("[M]ain Menu");
                    ConsoleKeyInfo ck = Console.ReadKey();

                    switch (ck.Key) {
                        case ConsoleKey.B:
                            Menus.Clean();
                            Menus.BuyCarMenu(cars, currentPlayer, game, index, true);
                            break;
                        case ConsoleKey.N:
                            Menus.Clean();
                            Menus.BuyCarMenu(cars, currentPlayer, game, index + 1, false);
                            break;
                        case ConsoleKey.M:
                            Menus.Clean();
                            Game.BackToMainMenu(currentPlayer, game);
                            break;
                        default:
                            Menus.Clean();
                            Menus.BuyCarMenu(cars, currentPlayer, game, index, false);
                            break;
                    }
                }
            }
        }

        public static ConsoleKeyInfo ViewOwnedCarsMenu(Player currentPlayer, Game game, int index = 0){
            List<Car> cars = currentPlayer.ownedCars;

            if (cars.Count == 0){
                Console.WriteLine("You don't have any cars \n\n");
                Game.BackToMainMenu(currentPlayer, game);
            }

            string[] car = cars[index].DisplayCar();

            Console.WriteLine(car[0]); 
            Console.WriteLine(car[1]); 
            Console.WriteLine(car[2]); 

            if(cars.Count == 1) {
                Console.WriteLine("[R]epair a car");
                Console.WriteLine("[M]ain Menu");
                ConsoleKeyInfo ck = Console.ReadKey();

                switch (ck.Key) {
                    case ConsoleKey.M:
                        Menus.Clean();
                        Game.BackToMainMenu(currentPlayer, game);
                        break;
                    case ConsoleKey.R:
                        Menus.Clean();
                        Menus.RepairCarMenu(currentPlayer, index, game);
                        break;
                    default:
                        Menus.Clean();
                        Menus.ViewOwnedCarsMenu(currentPlayer, game, index);
                        break;
                }
            } else if (index == cars.Count - 1) {
                Console.WriteLine("[R]epair a car       [P]revious");
                Console.WriteLine("[M]ain Menu");
                ConsoleKeyInfo ck = Console.ReadKey();

                switch (ck.Key) {
                    case ConsoleKey.P:
                        Menus.Clean();
                        Menus.ViewOwnedCarsMenu(currentPlayer, game, index - 1);
                        break;
                    case ConsoleKey.M:
                        Menus.Clean();
                        Game.BackToMainMenu(currentPlayer, game);
                        break;
                    case ConsoleKey.R:
                        Menus.Clean();
                        Menus.RepairCarMenu(currentPlayer, index, game);
                        break;
                    default:
                        Menus.Clean();
                        Menus.ViewOwnedCarsMenu(currentPlayer, game, index);
                        break;
                }
            } else if (index > 0) {
                Console.WriteLine("[R]epair a car       [P]revious [N]ext");
                Console.WriteLine("[M]ain Menu");
                ConsoleKeyInfo ck = Console.ReadKey();

                switch (ck.Key) {
                    case ConsoleKey.P:
                        Menus.Clean();
                        Menus.ViewOwnedCarsMenu(currentPlayer, game, index - 1);
                        break;
                    case ConsoleKey.N:
                        Menus.Clean();
                        Menus.ViewOwnedCarsMenu(currentPlayer, game, index + 1);
                        break;
                    case ConsoleKey.M:
                        Menus.Clean();
                        Game.BackToMainMenu(currentPlayer, game);
                        break;
                    case ConsoleKey.R:
                        Menus.Clean();
                        Menus.RepairCarMenu(currentPlayer, index, game);
                        break;
                    default:
                        Menus.Clean();
                        Menus.ViewOwnedCarsMenu(currentPlayer, game, index);
                        break;
                }
            } else {
                Console.WriteLine("[R]epair a car       [N]ext");
                Console.WriteLine("[M]ain Menu");
                ConsoleKeyInfo ck = Console.ReadKey();

                switch (ck.Key) {
                    case ConsoleKey.N:
                        Menus.Clean();
                        Menus.ViewOwnedCarsMenu(currentPlayer, game, index + 1);
                        break;
                    case ConsoleKey.M:
                        Menus.Clean();
                        Game.BackToMainMenu(currentPlayer, game);
                        break;
                    case ConsoleKey.R:
                        Menus.Clean();
                        Menus.RepairCarMenu(currentPlayer, index, game);
                        break;
                    default:
                        Menus.Clean();
                        Menus.ViewOwnedCarsMenu(currentPlayer, game, index);
                        break;
                }
            }
            return Console.ReadKey();
        }

        public static void RepairCarMenu(Player currentPlayer, int index, Game game){
            Car car = currentPlayer.ownedCars[index];
            Console.WriteLine("Where you want to repair your car:");
            Console.WriteLine($"[J]anusz: \n\t Price: {Decimal.Multiply(car.RepairPrice(), 1.2m)}");
            Console.WriteLine($"Maria[n]: \n\t Price: {car.RepairPrice()}");
            Console.WriteLine($"[A]drian: \n\t Price: {Decimal.Multiply(car.RepairPrice(), 0.8m)}");
            Console.WriteLine("\n [B]ack    [M]ain Menu");
            ConsoleKeyInfo ck = Console.ReadKey();

            switch(ck.Key){
                case ConsoleKey.J:
                    Menus.Clean();
                    game.RepairCarMenuLogic(currentPlayer, index, Decimal.Multiply(car.RepairPrice(), 1.2m), 100);
                    break;
                case ConsoleKey.N:
                    Menus.Clean();
                    game.RepairCarMenuLogic(currentPlayer, index, car.RepairPrice(), 90);
                    break;
                case ConsoleKey.A:
                    Menus.Clean();
                    game.RepairCarMenuLogic(currentPlayer, index, Decimal.Multiply(car.RepairPrice(), 0.8m), 80);
                    break;
                case ConsoleKey.B:
                    Menus.Clean();
                    ViewOwnedCarsMenu(currentPlayer, game, index);
                    break;
                case ConsoleKey.M:
                    Menus.Clean();
                    Game.BackToMainMenu(currentPlayer, game);
                    break;
                default:
                    Menus.Clean();
                    RepairCarMenu(currentPlayer, index, game);
                    break;
            }
        }

        public static void BuyAdMenu(Player currentPlayer, Game game) {
            Console.WriteLine("Buy Ad Menu");
            Console.WriteLine("Marketing [C]ampaign         Price: $0");
            Console.WriteLine("Promote in a [N]ewspaper     Price: $1000");
            Console.WriteLine("Promote in an [I]nternet     Price: $300");
            Console.WriteLine("\n[M]ain menu");

            ConsoleKeyInfo ck = Console.ReadKey();

            switch (ck.Key) {
                case ConsoleKey.C:
                    Menus.Clean();
                    game.BuyAdMenuLogic(0);
                    break;
                case ConsoleKey.N:
                    Menus.Clean();
                    game.BuyAdMenuLogic(1000);
                    break;
                case ConsoleKey.I:
                    Menus.Clean();
                    game.BuyAdMenuLogic(300);
                    break;
                case ConsoleKey.M:
                    Menus.Clean();
                    Game.BackToMainMenu(currentPlayer, game);
                    break;
                default:
                    Menus.Clean();
                    BuyAdMenu(currentPlayer, game);
                    break;
            }
        }

        public static void SellCarMenu(Player currentPlayer, Game game, List<Client> clients, int index = 0) {
            List<Car> cars = currentPlayer.ownedCars;
            clients[index].PrintClient();
            if(index == 0) {
                Console.WriteLine("\n[S]ell     [N]ext");
                Console.WriteLine("[M]ain Menu");
                ConsoleKeyInfo ck = Console.ReadKey();

                switch (ck.Key) {
                    case ConsoleKey.S:
                        Menus.Clean();
                        if(CheckIfPossibleToSell(cars, clients[index]).Count == 0) {
                            Console.WriteLine("You don't have any cars that fits for this Client");
                            SellCarMenu(currentPlayer, game, clients, index);
                        }else {
                            List<Car> sellableCars = CheckIfPossibleToSell(cars, clients[index]);
                            SellableCars(currentPlayer, sellableCars, clients[index], index, clients, game);
                        }
                        break;
                    case ConsoleKey.N:
                        Menus.Clean();
                        SellCarMenu(currentPlayer, game, clients, index + 1);
                        break;
                    case ConsoleKey.M:
                        Menus.Clean();
                        Game.BackToMainMenu(currentPlayer, game);
                        break;
                    default:
                        Menus.Clean();
                        SellCarMenu(currentPlayer, game, clients, index);
                        break;
                }

            } else if(index == clients.Count - 1) {
                Console.WriteLine("\n[S]ell     [P]revious");
                Console.WriteLine("[M]ain Menu");
                ConsoleKeyInfo ck = Console.ReadKey();

                switch (ck.Key) {
                    case ConsoleKey.S:
                        Menus.Clean();
                        if (CheckIfPossibleToSell(cars, clients[index]).Count == 0) {
                            Console.WriteLine("You don't have any cars that fits for this Client");
                            SellCarMenu(currentPlayer, game, clients, index);
                        } else {
                            List<Car> sellableCars = CheckIfPossibleToSell(cars, clients[index]);
                            SellableCars(currentPlayer, sellableCars, clients[index], index, clients, game);
                        }
                        break;
                    case ConsoleKey.P:
                        Menus.Clean();
                        SellCarMenu(currentPlayer, game, clients, index - 1);
                        break;
                    case ConsoleKey.M:
                        Menus.Clean();
                        Game.BackToMainMenu(currentPlayer, game);
                        break;
                    default:
                        Menus.Clean();
                        SellCarMenu(currentPlayer, game, clients, index);
                        break;
                }

            } else {
                Console.WriteLine("\n[S]ell     [P]revious [N]ext");
                Console.WriteLine("[M]ain Menu");
                ConsoleKeyInfo ck = Console.ReadKey();

                switch (ck.Key) {
                    case ConsoleKey.S:
                        Menus.Clean();
                        if (CheckIfPossibleToSell(cars, clients[index]).Count == 0) {
                            Console.WriteLine("You don't have any cars that fits for this Client \n");
                            SellCarMenu(currentPlayer, game, clients, index);
                        } else {
                            List<Car> sellableCars = CheckIfPossibleToSell(cars, clients[index]);
                            SellableCars(currentPlayer, sellableCars, clients[index], index, clients, game);
                        }
                        break;
                    case ConsoleKey.P:
                        Menus.Clean();
                        SellCarMenu(currentPlayer, game, clients, index - 1);
                        break;
                    case ConsoleKey.N:
                        Menus.Clean();
                        SellCarMenu(currentPlayer, game, clients, index + 1);
                        break;
                    case ConsoleKey.M:
                        Menus.Clean();
                        Game.BackToMainMenu(currentPlayer, game);
                        break;
                    default:
                        Menus.Clean();
                        SellCarMenu(currentPlayer, game, clients, index);
                        break;
                }

            }

        }

        public static List<Car> CheckIfPossibleToSell(List<Car> cars, Client checkClient){
            List<Car> returnCars = new List<Car>();
            bool damaged = false;
            foreach(Car car in cars){ 
                if(car.type == checkClient.interestedInType){ 
                    if(car.brand == checkClient.interestedIn[0] || car.brand == checkClient.interestedIn[1]){
                        if(car.FinalPrice() <= checkClient.cash){
                            foreach(Part part in car.parts){
                                if(part.needRepairing == true){
                                    damaged = true;
                                }
                            }
                            if (checkClient.acceptedDamagedParts == false && damaged == false) {
                                returnCars.Add(car);
                            } else if(checkClient.acceptedDamagedParts == true && damaged == true) {
                                returnCars.Add(car);
                            } else if(checkClient.acceptedDamagedParts == true && damaged == false) {
                                returnCars.Add(car);
                            }
                        }
                    }
                }
            }
            return returnCars;
        }

        public static void SellableCars(Player currentPlayer, List<Car> cars, Client client, int clientIndex, List<Client> clients, Game game, int carIndex = 0){ 
            if(cars.Count == 1) {
                Console.WriteLine(cars[carIndex].DisplayCar()[0]);
                if (cars[carIndex].type == "cargo")
                    Console.WriteLine($"Cargo Space: {cars[carIndex].cargoSpace}");
                Console.WriteLine(cars[carIndex].DisplayCar()[1]);
                Console.WriteLine(cars[carIndex].DisplayCar()[2]);

                Console.WriteLine("\n[S]ell");
                Console.WriteLine("[B]ack   [M]ain Menu");
                ConsoleKeyInfo ck = Console.ReadKey();

                switch (ck.Key) {
                    case ConsoleKey.S:
                        Menus.Clean();
                        game.SellCarMenuLogic(cars[carIndex]);
                        break;
                    case ConsoleKey.B:
                        SellCarMenu(currentPlayer, game, clients, clientIndex);
                        break;
                    case ConsoleKey.M:
                        Menus.Clean();
                        Game.BackToMainMenu(currentPlayer, game);
                        break;
                    default:
                        SellableCars(currentPlayer, cars, client, clientIndex, clients, game, carIndex);
                        break;
                }

            }else{ 
                if(carIndex == 0){
                    Console.WriteLine("\n[S]ell     [N]ext");
                    Console.WriteLine("[B]ack   [M]ain Menu");
                    ConsoleKeyInfo ck = Console.ReadKey();

                    switch (ck.Key) {
                        case ConsoleKey.N:
                            Menus.Clean();
                            SellableCars(currentPlayer, cars, client, clientIndex, clients, game, carIndex + 1);
                            break;
                        case ConsoleKey.S:
                            Menus.Clean();
                            game.SellCarMenuLogic(cars[carIndex]);
                            break;
                        case ConsoleKey.B:
                            SellCarMenu(currentPlayer, game, clients, clientIndex);
                            break;
                        case ConsoleKey.M:
                            Menus.Clean();
                            Game.BackToMainMenu(currentPlayer, game);
                            break;
                        default:
                            SellableCars(currentPlayer, cars, client, clientIndex, clients, game, carIndex);
                            break;
                    }

                } else if(carIndex == cars.Count-1) {
                    Console.WriteLine("\n[S]ell     [P]revious");
                    Console.WriteLine("[B]ack   [M]ain Menu");
                    ConsoleKeyInfo ck = Console.ReadKey();

                    switch (ck.Key) {
                        case ConsoleKey.P:
                            Menus.Clean();
                            SellableCars(currentPlayer, cars, client, clientIndex, clients, game, carIndex - 1);
                            break;
                        case ConsoleKey.S:
                            Menus.Clean();
                            game.SellCarMenuLogic(cars[carIndex]);
                            break;
                        case ConsoleKey.B:
                            SellCarMenu(currentPlayer, game, clients, clientIndex);
                            break;
                        case ConsoleKey.M:
                            Menus.Clean();
                            Game.BackToMainMenu(currentPlayer, game);
                            break;
                        default:
                            SellableCars(currentPlayer, cars, client, clientIndex, clients, game, carIndex);
                            break;
                    }

                } else {
                    Console.WriteLine("\n[S]ell     [P]revious [N]ext");
                    Console.WriteLine("[B]ack   [M]ain Menu");
                    ConsoleKeyInfo ck = Console.ReadKey();

                    switch (ck.Key) {
                        case ConsoleKey.N:
                            Menus.Clean();
                            SellableCars(currentPlayer, cars, client, clientIndex, clients, game, carIndex + 1);
                            break;
                        case ConsoleKey.P:
                            Menus.Clean();
                            SellableCars(currentPlayer, cars, client, clientIndex, clients, game, carIndex - 1);
                            break;
                        case ConsoleKey.S:
                            Menus.Clean();
                            game.SellCarMenuLogic(cars[carIndex]);
                            break;
                        case ConsoleKey.B:
                            SellCarMenu(currentPlayer, game, clients, clientIndex);
                            break;
                        case ConsoleKey.M:
                            Menus.Clean();
                            Game.BackToMainMenu(currentPlayer, game);
                            break;
                        default:
                            SellableCars(currentPlayer, cars, client, clientIndex, clients, game, carIndex);
                            break;
                    }

                }
            }
        }

        public static ConsoleKeyInfo CheckHistoryMenu(){
            Console.WriteLine("Check History Menu");
            return Console.ReadKey();
        }

        public static ConsoleKeyInfo CheckPaymentsMenu(){
            Console.WriteLine("Check Payments Menu");
            return Console.ReadKey();
        }
    }
}
