using NeuFinesse.Data.Model;
using NeuFinesse.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuFinesse.Data.DataManager
{
    public class InterestDataManager : IDataRepository<Interest>
    {
        readonly NeuFinesseContext _neuFinesseContext;

        public InterestDataManager(NeuFinesseContext context)
        {
            _neuFinesseContext = context;
        }

        public IEnumerable<Interest> GetAll()
        {
            return _neuFinesseContext.Interest.OrderBy(interest => interest.InterestName).ToList();
        }

        public Interest Get(long id)
        {
            return _neuFinesseContext.Interest
                  .FirstOrDefault(interest => interest.InterestId == id);
        }

        public void Add(Interest entity)
        {
            _neuFinesseContext.Interest.Add(entity);
            _neuFinesseContext.SaveChanges();
        }

        public void Update(Interest interest, Interest entity)
        {
            interest.InterestId = entity.InterestId;
            interest.InterestName = entity.InterestName;
            interest.InterestImage = entity.InterestImage;

            _neuFinesseContext.SaveChanges();
        }

        public void Delete(Interest interest)
        {
            _neuFinesseContext.Interest.Remove(interest);
            _neuFinesseContext.SaveChanges();
        }
    }
}
