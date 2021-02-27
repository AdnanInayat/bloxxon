using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public interface IUserRepo
    {
        public IEnumerable<tUser> GetAll();
        public tUser GetById(int id);
        public bool Insert(tUser entity);
        public bool Update(tUser entity);
    }
    public class UserRepo : IUserRepo
    {
        protected readonly DatabaseContext context;
        public UserRepo(DatabaseContext context)
        {
            this.context = context;
        }
        public IEnumerable<tUser> GetAll()
        {
            return context.Users.AsEnumerable();
        }
        public tUser GetById(int id)
        {
            return context.Users.SingleOrDefault(s => s.Id == id);
        }
        public bool Insert(tUser entity)
        {
            if (entity == null) return false;
            context.Users.Add(entity);
            context.SaveChanges();
            return true;
        }
        public bool Update(tUser entity)
        {
            if (entity == null) return false;
            context.Users.Update(entity);
            context.SaveChanges();
            return true;
        }
        //public void Delete(int id)
        //{
        //    if (id == null) throw new ArgumentNullException("entity");

        //    T entity = entities.SingleOrDefault(s => s.Id == id);
        //    entities.Remove(entity);
        //    //context.SaveChanges();
        //}
    }
}
