using System;
using System.Collections.Generic;
using System.Linq;

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
            return storage.GetValueOrDefault(id);
        }

        public Dictionary<string, IStorable> GetAllDictionary()
        {
            throw new NotImplementedException();
        }

        public List<IStorable> GetAllList()
        {
            //Nem volt tilos a LinQ, nem? Igaz, azért használtam, mert így könnyebben áttudtam neki adni listát
            //Máshogyan, hogyan lehetne?
            //Segítség
            //https://www.dotnetperls.com/tolist
            return storage.Values.ToList<IStorable>();
        }

        public void Sell(string id, int amount)
        {
            if (storage.ContainsKey(id))
            {
                if (amount > 0 && storage.GetValueOrDefault(id).InStock - amount >= 0)
                    storage[id].InStock -= amount;
                else throw new ArgumentException();
            }     
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
