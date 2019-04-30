using NeuFinesse.Data.Model;
using NeuFinesse.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuFinesse.Data.DataManager
{
    public class ItemDataManager : IDataRepository<Item>
    {
        readonly NeuFinesseContext _neuFinesseContext;

        public ItemDataManager(NeuFinesseContext context)
        {
            _neuFinesseContext = context;
        }

        public IEnumerable<Item> GetAll()
        {
            var items = _neuFinesseContext.Item.OrderBy(item => item.ItemName).ToList();
            return items;
        }

        public Item Get(long id)
        {
            return _neuFinesseContext.Item
                  .FirstOrDefault(item => item.ItemId == id);
        }

        public void Add(Item entity)
        {
            _neuFinesseContext.Item.Add(entity);
            _neuFinesseContext.SaveChanges();
        }

        public void Update(Item item, Item entity)
        {
            item.ItemId = entity.ItemId;
            item.ItemName = entity.ItemName;
            item.ItemImage = entity.ItemImage;
            item.InterestId = entity.InterestId;
            item.Details = entity.Details;
            item.Quantity = entity.Quantity;
            item.Weight = entity.Weight;
            item.Type = entity.Type;

            _neuFinesseContext.SaveChanges();
        }

        public void Delete(Item item)
        {
            _neuFinesseContext.Item.Remove(item);
            _neuFinesseContext.SaveChanges();
        }
    }
}

