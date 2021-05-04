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
    }
}
