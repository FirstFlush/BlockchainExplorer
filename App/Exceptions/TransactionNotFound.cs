using System;

namespace BlockchainExplorer.App.Exceptions 
{
    public class TransactionNotFound : Exception
    {
        public TransactionNotFound(string message) : base(message)
        {}
    }
}