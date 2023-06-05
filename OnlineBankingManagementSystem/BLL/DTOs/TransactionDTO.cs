using OnlineBankingManagementSystem.DAL.Models;
using System.Data;

namespace OnlineBankingManagementSystem.BLL.DTOs
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public int ReceiverAccountNumber { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
