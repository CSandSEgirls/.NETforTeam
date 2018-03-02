using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace myLibrary.Models{
    public class OrderStore : IStore<Order>
    {
        private List<Order> _cachedCollection;

        public string Path { get; set; }

        public List<Order> GetCollection()
        {
            if(_cachedCollection == null)
            {
                var data = File.ReadAllLines(Path);
                _cachedCollection = data
                    .Skip(1)
                    .Select(x => ConvertItem(x))
                    .ToList();
            }
            
            return _cachedCollection;
        }

        public  Order ConvertItem(string item)
        {
            var itemList = item.Split(';');

            return new  Order()
            {
               Id = Convert.ToInt32(itemList[0]),
               FullName = itemList[1],
               Phone = itemList[2],
               Email = itemList[3],
               CategoryId = Convert.ToInt32(itemList[4]),
               RouteId = Convert.ToInt32(itemList[5])
            };
        }
    }
}