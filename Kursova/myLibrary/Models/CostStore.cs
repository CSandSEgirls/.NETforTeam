using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace myLibrary.Models{
    public class CostStore : IStore<Cost>
    {
        private List<Cost> _cachedCollection;

        public string Path { get; set; }

        public List<Cost> GetCollection()
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

        public Cost ConvertItem(string item)
        {
            var itemList = item.Split(';');

            return new Cost()
            {
                Id       =  Convert.ToInt32(itemList[0]),
                CategoryID  =  Convert.ToInt32(itemList[1]),
                Price   =  itemList[2],
            };
        }
    }
}