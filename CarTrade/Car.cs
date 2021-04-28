using System;
using System.Collections.Generic;
using System.Text;

namespace CarTrade
{
    class Car
    {

        // base values for car
        public readonly decimal value;
        public readonly string brand;
        public readonly decimal mileage;
        public readonly string colour;
        public readonly string segment;
        public readonly string type;
        public readonly int cargoSpace;
        public string owner;

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
            this.CreateParts();
        }

        //helper method
        private bool NeedRepairing()
        {
            Random rng = new Random();
            return rng.Next(100) <= 50;
        }

        public void CreateParts() {
            this.parts[0] = new Part("Break", NeedRepairing(), 10);
            this.parts[1] = new Part("Suspension", NeedRepairing(), 20);
            this.parts[2] = new Part("Engine", NeedRepairing(), 100);
            this.parts[3] = new Part("Body", NeedRepairing(), 50);
            this.parts[4] = new Part("Gearbox", NeedRepairing(), 50);
        }

        private decimal FinalPrice() {
            decimal final = this.value;
            for (int i = 0; i < 5; i++) {
                final = this.parts[i].needRepairing ? final + this.value * this.parts[i].valueIncrease : final;
            }
            return final;
        }

        public string[] DisplayCar() {
            string firstLine = $"The {this.colour} {this.brand} \n {this.type} car out of {this.segment} segment.";
            string secondLine = $"Price: {this.FinalPrice()}";
            string parts = "Status of parts: \n";
            for (int i = 0; i < 5; i++) {
                parts += $"{this.parts[i]}: {(this.parts[i].needRepairing ? "Repair is needed" : "Perfect")} \n";
            }
            return new String[3] {firstLine, secondLine, parts};
        }

    }
}
