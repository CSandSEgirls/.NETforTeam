using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace myLibrary.Models{
    public class DeliveryStore : IStore<Delivery>
    {
        private List<Delivery> _cachedCollection;

        public string Path { get; set; }

        public List<Delivery> GetCollection()
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

        public Delivery ConvertItem(string item)
        {
            var itemList = item.Split(';');

            return new Delivery()
            {
                Id       =  Convert.ToInt32(itemList[0]),
                OrderId  =  Convert.ToInt32(itemList[1]),
                Status   = itemList[2],
            };
        }
    }
}