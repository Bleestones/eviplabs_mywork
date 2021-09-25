using System;
using System.Collections.Generic;

namespace Storage
{
    public class Store<T> where T : IStorable
    {
        private Dictionary<string, IStorable> storage = new Dictionary<string, IStorable>();

        public int Count()
        {
            return storage.Count;
        }

        public void Insert(IStorable item)
        {
            if(!storage.ContainsKey(item.Id) && item.InStock > 0)
                storage.Add(item.Id, item);
        }

        public void InsertMany(List<IStorable> items)
        {
            foreach (IStorable storable in items)
                Insert(storable);
        }

        public IStorable GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, IStorable> GetAllDictionary()
        {
            throw new NotImplementedException();
        }

        public List<IStorable> GetAllList()
        {
            throw new NotImplementedException();
        }

        public void Sell(string id, int amount)
        {
            throw new NotImplementedException();
        }

        public void Buy(IStorable item)
        {
            throw new NotImplementedException();
        }

        public void Buy(string id, int amount)
        {
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }

        public void Remove(IStorable item)
        {
            throw new NotImplementedException();
        }
    }
}
