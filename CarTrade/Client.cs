using System;
using System.Collections.Generic;
using System.Text;

namespace CarTrade
{
    class Client
    {
        public readonly string name;
        public readonly decimal cash;
        public readonly String interestedInType;
        public readonly String[] interestedIn;
        public readonly Part[] acceptedDamagedParts;

        public Client(string name, decimal cash, String interestedInType, String[] interestedIn, Part[] acceptedDamagedParts) {
            this.name = name;
            this.cash = cash;
            this.interestedInType = interestedInType;
            this.interestedIn = interestedIn;
            this.acceptedDamagedParts = acceptedDamagedParts;
        }
    }
}
