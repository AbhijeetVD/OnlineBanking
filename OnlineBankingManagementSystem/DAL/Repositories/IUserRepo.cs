﻿using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.DAL.Repositories
{
    public interface IUserRepo
    {
        public IEnumerable<User> GetAll();
        public User GetByAccountNumber(int accountNumber);
        public User GetByUserId(int userId);
        public User GetByUsername(string username);
        public User GetByEmail(string email);
        public void Add(User user);
        public void Update(User user);
        public void Delete(User user);
    }
}
