using NeuFinesse.Data.Model;
using NeuFinesse.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuFinesse.Data.DataManager
{
    public class SellerDetailDataManager : IUserRepository<SellerDetail>
    {
        readonly NeuFinesseContext _neuFinesseContext;

        public SellerDetailDataManager(NeuFinesseContext context)
        {
            _neuFinesseContext = context;
        }

        public IEnumerable<SellerDetail> GetAll()
        {
            return _neuFinesseContext.SellerDetail.ToList();
        }

        public IEnumerable<SellerDetail> GetAll(string id)
        {
             return _neuFinesseContext.SellerDetail.Where(detail => detail.UserId == id).DefaultIfEmpty().ToList();
        }

        public SellerDetail Get(string id)
        {
            return _neuFinesseContext.SellerDetail
                  .FirstOrDefault(detail => detail.UserId == id);
        }

        public void Add(SellerDetail entity)
        {
            _neuFinesseContext.SellerDetail.Add(entity);
            _neuFinesseContext.SaveChanges();
        }

        public void Update(SellerDetail sellerDetail, SellerDetail entity)
        {
            sellerDetail.UserId = entity.UserId;
            sellerDetail.SellerImage = entity.SellerImage;
            sellerDetail.Description = entity.Description;
            sellerDetail.Location = entity.Location;

            _neuFinesseContext.SaveChanges();
        }

        public void Delete(SellerDetail sellerDetail)
        {
            _neuFinesseContext.SellerDetail.Remove(sellerDetail);
            _neuFinesseContext.SaveChanges();
        }
    }
}
