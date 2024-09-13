using System;

namespace BlockchainExplorer.App.Exceptions 
{
    public class AddressNotFound : Exception
    {
        public AddressNotFound(string message) : base(message)
        {}
    }
}