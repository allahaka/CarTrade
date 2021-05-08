using System;

namespace CarTrade
{
    class Client
    {
        public readonly string name;
        public readonly decimal cash;
        public readonly string interestedInType;
        public readonly string[] interestedIn; //brand interest
        public readonly bool acceptedDamagedParts;

        public Client(string name, decimal cash, string interestedInType, string[] interestedIn, bool acceptedDamagedParts) {
            this.name = name;
            this.cash = cash;
            this.interestedInType = interestedInType;
            this.interestedIn = interestedIn;
            this.acceptedDamagedParts = acceptedDamagedParts;
        }

        public void PrintClient(){
            Console.WriteLine($"{name} is looking for {interestedInType}");
            Console.WriteLine($"Brands: {interestedIn[0]}, {interestedIn[1]}");
            Console.WriteLine($"Can spend: {cash}");
            Console.WriteLine($"{(acceptedDamagedParts ? "Accept damaged car" : "Doesn't accept damaged car")}");
        }
    }
}
