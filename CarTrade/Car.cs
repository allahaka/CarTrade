using System;

namespace CarTrade
{
    class Car
    {

        // base values for car
        public readonly decimal value;
        public readonly string brand;
        public readonly decimal mileage;
        public readonly string colour;
        public readonly string segment; //premium, standard, budget
        public readonly string type; //cargo, normal, motorcycle
        public readonly int cargoSpace; //0-not important, other for cargo

        //parts for car
        public Part[] parts;

        public Car(decimal value, string brand, decimal mileage, string colour, string segment, string type, int cargoSpace=0) {
            this.value = value;
            this.brand = brand;
            this.mileage = mileage;
            this.colour = colour;
            this.segment = segment;
            this.type = type;
            this.cargoSpace = cargoSpace;
            CreateParts();
        }

        //helper method
        private bool NeedRepairing()
        {
            Random rng = new Random();
            return rng.Next(100) <= 40;
        }

        public void CreateParts() {
            parts = new Part[5];
            parts[0] = new Part("Break", NeedRepairing(), 10);
            parts[1] = new Part("Suspension", NeedRepairing(), 20);
            parts[2] = new Part("Engine", NeedRepairing(), 100);
            parts[3] = new Part("Body", NeedRepairing(), 50);
            parts[4] = new Part("Gearbox", NeedRepairing(), 50);
        }

        private decimal FinalPrice() {
            decimal final = value;
            for (int i = 0; i < 5; i++) {
                final = parts[i].needRepairing ? final + value * parts[i].valueIncrease : final;
            }
            return final;
        }

        public string[] DisplayCar() {
            string firstLine = $"The {colour} {brand} \n {type} car out of {segment} segment.";
            string secondLine = $"Price: {FinalPrice()}";
            string parts = "Status of parts: \n";
            for (int i = 0; i < 5; i++) {
                parts += $"{parts[i]}: {(this.parts[i].needRepairing ? "Repair is needed" : "Perfect")} \n";
            }
            return new String[3] {firstLine, secondLine, parts};
        }

    }
}
