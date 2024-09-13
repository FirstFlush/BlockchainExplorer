using System;
using System.ComponentModel.DataAnnotations;

namespace BlockchainExplorer.App.Models
{
    public class TransactionModel
    {
        [Key] // Indicates the primary key
        public int Id { get; set; }

        [Required] // Ensures this field is required
        public required string TransactionId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public TransactionTypeEnum TransactionType { get; set; }

        public string? Notes { get; set; } // Optional

    }

    public enum TransactionTypeEnum
    {
        Payment,
        Refund,
        Transfer,
        Fee,
    }
}







// namespace BlockchainExplorer.App.Models
// {
//     public class TransactionModel(string transactionId, TransactionTypeEnum type, decimal amount, DateTime date, string? notes=null)
//     {
//         public int Id { get; set; } //Primary Key
//         public string TransactionId { get; set; } = transactionId;
//         public decimal Amount { get; set; } = amount;
//         public DateTime Date { get; set; } = date;
//         public TransactionTypeEnum TransactionType { get; set; } = type;
//         public string? Notes { get; set; } = notes;
//     }


//     public enum TransactionTypeEnum
//     {
//         Payment,
//         Refund,
//         Transfer,
//         Fee,
//     }

// }

