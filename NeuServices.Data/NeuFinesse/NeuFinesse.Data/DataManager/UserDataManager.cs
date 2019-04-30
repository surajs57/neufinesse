using NeuFinesse.Data.Model;
using NeuFinesse.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuFinesse.Data.DataManager
{
    public class UserDataManager : IUserRepository<User>
    {
        readonly NeuFinesseContext _neuFinesseContext;

        public UserDataManager(NeuFinesseContext context)
        {
            _neuFinesseContext = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _neuFinesseContext.User.ToList();
        }

        public IEnumerable<User> GetAll(string id)
        {
            return _neuFinesseContext.User.Where(user=>user.UserId==id).DefaultIfEmpty().ToList();
        }

        public User Get(string id)
        {
            return _neuFinesseContext.User
                  .FirstOrDefault(user => user.UserId == id);
        }

        public void Add(User entity)
        {
            _neuFinesseContext.User.Add(entity);
            _neuFinesseContext.SaveChanges();
        }

        public void Update(User user, User entity)
        {
            user.UserId = entity.UserId;
            user.UserName = entity.UserName;
            user.Email = entity.Email;
            user.Role=entity.Role;

            _neuFinesseContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _neuFinesseContext.User.Remove(user);
            _neuFinesseContext.SaveChanges();
        }
    }
}
