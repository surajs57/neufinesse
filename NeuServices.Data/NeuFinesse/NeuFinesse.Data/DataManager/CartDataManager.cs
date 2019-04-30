using NeuFinesse.Data.Model;
using NeuFinesse.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuFinesse.Data.DataManager
{
    public class CartDataManager : IUserRepository<Cart>
    {
        readonly NeuFinesseContext _neuFinesseContext;

        public CartDataManager(NeuFinesseContext context)
        {
            _neuFinesseContext = context;
        }

        public IEnumerable<Cart> GetAll()
        {
            return _neuFinesseContext.Cart.ToList();
        }

        public IEnumerable<Cart> GetAll(string id)
        {
            return _neuFinesseContext.Cart
                  .Where(cart => cart.UserId == id).DefaultIfEmpty().ToList();
        }

        public Cart Get(string id)
        {
            return _neuFinesseContext.Cart
                  .FirstOrDefault(cart => cart.UserId == id);
        }

        public void Add(Cart entity)
        {
            _neuFinesseContext.Cart.Add(entity);
            _neuFinesseContext.SaveChanges();
        }

        public void Update(Cart cart, Cart entity)
        {
            cart.UserId = entity.UserId;
            cart.ItemId = entity.ItemId;
            cart.Quantity = entity.Quantity;

            _neuFinesseContext.SaveChanges();
        }

        public void Delete(Cart cart)
        {
            _neuFinesseContext.Cart.Remove(cart);
            _neuFinesseContext.SaveChanges();
        }
    }
}

