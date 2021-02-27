using Data.Models;
using Data.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Services
{
    public interface IUserService
    {
        public IEnumerable<tUser> GetAll();
        public tUser GetById(int id);
        public bool Insert(tUser entity);
        public bool Update(tUser entity);
    }
    public class UserService : IUserService
    {
        private IUserRepo userRepo;
        public UserService(IUserRepo _userRepo)
        {
            userRepo = _userRepo;
        }
        public IEnumerable<tUser> GetAll()
        {
            return userRepo.GetAll();
        }

        public tUser GetById(int id)
        {
            return userRepo.GetById(id);
        }

        public bool Insert(tUser entity)
        {
            return userRepo.Insert(entity);
        }

        public bool Update(tUser entity)
        {
            return userRepo.Update(entity);
        }
    }
}
