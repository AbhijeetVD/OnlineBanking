using OnlineBankingManagementSystem.BLL.DTOs;
using OnlineBankingManagementSystem.DAL.Repositories;
using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.BLL.Services
{
    public class AccountService : IAccountService
    {
        public readonly IAccountRepo _accountrepo;
        public AccountService(IAccountRepo accountrepo)
        {
            this._accountrepo = accountrepo;
        }
        public AccountDTO AddAccount(CreateAccountDTO createaccountdto)
        {
            try
            {
                var add = new Account
                {
                    AccountNumber = createaccountdto.AccountNumber,
                    FullName = createaccountdto.FullName,
                    AccountType = createaccountdto.AccountType,
                };
                _accountrepo.Add(add);
                return new AccountDTO
                {
                    AccountNumber = add.AccountNumber,
                    FullName = add.FullName,
                    AccountType = add.AccountType,
                    Balance = add.Balance
                };
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public bool DeleteAccount(int accountNumber)
        {
            try
            {
                var delete = _accountrepo.GetByAccountNumber(accountNumber);
                if(delete == null)
                {
                    throw new Exception("Account not found!");
                }
                _accountrepo.Delete(accountNumber);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public AccountDTO GetAccountByAccountNumber(int accountNumber)
        {
            try
            {
                var account = _accountrepo.GetByAccountNumber(accountNumber);
                if(account == null)
                {
                    throw new Exception("Account not found!");
                }
                return new AccountDTO
                {
                    AccountNumber = account.AccountNumber,
                    FullName = account.FullName,
                    AccountType = account.AccountType,
                    Balance = account.Balance
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public IEnumerable<AccountDTO> GetAllAccounts()
        {
            try
            {
                var accounts = _accountrepo.GetAll();
                return accounts.Select(a => new AccountDTO {
                    AccountNumber = a.AccountNumber,
                    FullName = a.FullName,
                    AccountType = a.AccountType,
                    Balance = a.Balance
                });
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public AccountDTO UpdateAccount(int accountNumber, UpdateAccountDTO account)
        {
            try
            {
                var update = _accountrepo.GetByAccountNumber(accountNumber);
                if(update == null)
                {
                    throw new Exception("Account not found!");
                }
                update.FullName = account.FullName;
                update.AccountType = account.AccountType;
                update.Balance = account.Balance;
                _accountrepo.Update(update);
                return new AccountDTO
                {
                    AccountNumber = accountNumber,
                    FullName = account.FullName,
                    AccountType = account.AccountType,
                    Balance = account.Balance
                };
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
