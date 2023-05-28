using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.BLL.DTOs
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public virtual Account Account { get; set; }
        public static explicit operator Transaction(TransactionDTO transactionDTO)
        {
            if (transactionDTO == null) return null;
            return new Transaction
            {
                TransactionId = transactionDTO.TransactionId,
                AccountNumber = transactionDTO.AccountNumber,
                Amount = transactionDTO.Amount
            };
        }
        public static implicit operator TransactionDTO(Transaction transaction)
        {
            if (transaction == null) return null;
            return new TransactionDTO
            {
                TransactionId = transaction.TransactionId,
                AccountNumber = transaction.AccountNumber,
                Amount = transaction.Amount
            };
        }
    }
}
