using System;
using System.Collections.Generic;
using System.Text;

namespace CarTrade
{
    class Generators
    {
        public Car GenerateCar() {

            string type = CarType();
            string segment = CarSegment();
            string brand = GenerateBrand(segment);
            decimal value = 0.0m;
            decimal mileage = RandomDecimal(new Random(), 6, 2);
            string colour = "";
            int cargoSpace = 0;
            Car car = new Car(value, brand, mileage, colour, segment, type, cargoSpace);
            car.CreateParts();
            return car;
        }

        public string CarType() {

            int typeRand = RandomNumber(1000);

            if (typeRand <= 600) {
                return "normal";
            } else if (typeRand > 600 && typeRand <= 900) {
                return "cargo";
            } else {
                return "motorcycle";
            }
        }

        public string CarSegment() {

            int segRand = RandomNumber(1000);

            if (segRand <= 500) {
                return "budget";
            } else if (segRand > 500 && segRand <= 950) {
                return "standard";
            } else {
                return "premium";
            }
        }

        public string GenerateBrand(string segment){

            string[] budget = new string[8] { "Fiat", "Honda", "Hyundai", "Kia", "Opel", "Peugeot", "Renault", "Toyota" };
            string[] standard = new string[10] { "Audi", "BMW", "Chevrolet", "Ford", "Jeep", "Land Rover", "Lexus", "Mercedes-Benz", "Volkswagen", "Volvo" };
            string[] premium = new string[9] { "Alfa Romeo", "Aston Martin", "Bugatti", "Dodge", "Ferrari", "Lamborghini", "McLaren", "Rolls-Royce", "Tesla" };

            switch(segment){
                case "budget":
                    return budget[RandomNumber(budget.Length)];
                case "standard":
                    return standard[RandomNumber(standard.Length)];
                case "premium":
                    return premium[RandomNumber(premium.Length)];
                default:
                    return budget[RandomNumber(budget.Length)];
            }
        }

        //TODO
        public decimal GenerateBasePrice(string segment, string type) {
            decimal value = Convert.ToDecimal(RandomNumber(50000, 10000));
            return 0.0m;
        }

        //helper function
        public int RandomNumber(int max, int min = 0) {
            Random rng = new Random();
            return rng.Next(min, max);
        }

        static decimal RandomDecimal(Random randomNumberGenerator, int precision, int scale) {
            if (randomNumberGenerator == null)
                throw new ArgumentNullException("randomNumberGenerator");
            if (!(precision >= 1 && precision <= 28))
                throw new ArgumentOutOfRangeException("precision", precision, "Precision must be between 1 and 28.");
            if (!(scale >= 0 && scale <= precision))
                throw new ArgumentOutOfRangeException("scale", precision, "Scale must be between 0 and precision.");

            Decimal d = 0m;
            for (int i = 0; i < precision; i++) {
                int r = randomNumberGenerator.Next(0, 10);
                d = d * 10m + r;
            }
            for (int s = 0; s < scale; s++) {
                d /= 10m;
            }
            return d;
        }
    }
}
