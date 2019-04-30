using NeuFinesse.Data.Model;
using NeuFinesse.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuFinesse.Data.DataManager
{
    public class UserInterestDataManager : IUserRepository<UserInterest>
    {
        readonly NeuFinesseContext _neuFinesseContext;

        public UserInterestDataManager(NeuFinesseContext context)
        {
            _neuFinesseContext = context;
        }

        public IEnumerable<UserInterest> GetAll()
        {
            return _neuFinesseContext.UserInterest.ToList();
        }

        public IEnumerable<UserInterest> GetAll(string id)
        {
            return _neuFinesseContext.UserInterest.Where(interest=>interest.UserId==id).DefaultIfEmpty().ToList();
        }

        public UserInterest Get(string id)
        {
            return _neuFinesseContext.UserInterest
                  .FirstOrDefault(interest => interest.UserId == id);
        }

        public void Add(UserInterest entity)
        {
            _neuFinesseContext.UserInterest.Add(entity);
            _neuFinesseContext.SaveChanges();
        }

        public void Update(UserInterest userInterest, UserInterest entity)
        {
            userInterest.UserId = entity.UserId;
            userInterest.InterestId = entity.InterestId;

            _neuFinesseContext.SaveChanges();
        }

        public void Delete(UserInterest userInterest)
        {
            _neuFinesseContext.UserInterest.Remove(userInterest);
            _neuFinesseContext.SaveChanges();
        }
    }
}
