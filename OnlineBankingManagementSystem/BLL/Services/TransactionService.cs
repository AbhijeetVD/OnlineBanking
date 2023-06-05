using OnlineBankingManagementSystem.BLL.DTOs;
using OnlineBankingManagementSystem.DAL.Repositories;
using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.BLL.Services
{
    public class TransactionService : ITransactionService
    {
        public readonly ITransactionRepo _transactionrepo;
        public TransactionService(ITransactionRepo transactionrepo)
        {
            this._transactionrepo = transactionrepo;
        }
        public TransactionDTO AddTransaction(TransactionDTO transaction)
        {
            try
            {
                var add = new Transaction
                {
                    TransactionDate = DateTime.Now,
                    TransactionId = transaction.TransactionId,
                    AccountNumber = transaction.AccountNumber,
                    Amount = transaction.Amount,
                    ReceiverAccountNumber = transaction.ReceiverAccountNumber,
                };
                _transactionrepo.Add(add);
                return new TransactionDTO {
                    TransactionDate = DateTime.Now,
                    TransactionId = transaction.TransactionId,
                    Amount = transaction.Amount,
                    ReceiverAccountNumber = transaction.ReceiverAccountNumber,
                    AccountNumber = transaction.AccountNumber,
                };          
            }
            catch (Exception e) { 
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public IEnumerable<TransactionDTO> GetAllTransactions()
        {
            try
            {
                var transactions = _transactionrepo.GetAll();
                return transactions.Select(t => new TransactionDTO
                {
                    TransactionDate = DateTime.Now,
                    TransactionId = t.TransactionId,
                    Amount = t.Amount,
                    ReceiverAccountNumber = t.ReceiverAccountNumber,
                    AccountNumber= t.AccountNumber,
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public IEnumerable<TransactionDTO> GetTransactionByAccountNumber(int accountNumber)
        {
            try
            {
                var transactions = _transactionrepo.GetByAccountNumber(accountNumber);
                return transactions.Select(t => new TransactionDTO
                {
                    TransactionDate = DateTime.Now,
                    TransactionId = t.TransactionId,
                    Amount = t.Amount,
                    ReceiverAccountNumber = t.ReceiverAccountNumber,
                    AccountNumber = t.AccountNumber,
                });
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public TransactionDTO GetTransactionById(int transactionId)
        {
            try
            {
                var transaction = _transactionrepo.GetById(transactionId);
                if(transaction == null)
                {
                    throw new Exception("Transaction now found!");
                }
                return new TransactionDTO
                {
                    TransactionDate = DateTime.Now,
                    TransactionId = transactionId,
                    Amount = transaction.Amount,
                    ReceiverAccountNumber = transaction.ReceiverAccountNumber,
                    AccountNumber = transaction.AccountNumber,
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
