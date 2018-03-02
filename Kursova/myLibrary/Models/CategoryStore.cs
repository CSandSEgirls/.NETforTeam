using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace myLibrary.Models{
    public class CategoryStore : IStore<Category>
    {
        private List<Category> _cachedCollection;

        public string Path { get; set; }

        public List<Category> GetCollection()
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

        public Category ConvertItem(string item)
        {
            var itemList = item.Split(';');

            return new Category()
            {
                Id       =  Convert.ToInt32(itemList[0]),
                Type  =  itemList[1],
                Weight   =  itemList[2],
            };
        }
    }
}