using NeuFinesse.Data.Model;
using NeuFinesse.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuFinesse.Data.DataManager
{
    public class WishListDataManager : IUserRepository<WishList>
    {
        readonly NeuFinesseContext _neuFinesseContext;

        public WishListDataManager(NeuFinesseContext context)
        {
            _neuFinesseContext = context;
        }

        public IEnumerable<WishList> GetAll()
        {
            return _neuFinesseContext.WishList.ToList();
        }

        public IEnumerable<WishList> GetAll(string id)
        {
            return _neuFinesseContext.WishList.Where(wishList=>wishList.UserId==id).DefaultIfEmpty().ToList();
        }

        public WishList Get(string id)
        {
            return _neuFinesseContext.WishList
                  .FirstOrDefault(e => e.UserId == id);
        }

        public void Add(WishList entity)
        {
            _neuFinesseContext.WishList.Add(entity);
            _neuFinesseContext.SaveChanges();
        }

        public void Update(WishList wishList, WishList entity)
        {
            wishList.UserId = entity.UserId;
            wishList.ItemId = entity.ItemId;

            _neuFinesseContext.SaveChanges();
        }

        public void Delete(WishList wishList)
        {
            _neuFinesseContext.WishList.Remove(wishList);
            _neuFinesseContext.SaveChanges();
        }
    }
}


