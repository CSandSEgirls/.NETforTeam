using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace swoOne.Models{
    public class BookStore : IStore<Book>
    {
        private List<Book> _cachedCollection;

        public string Path { get; set; }

        public List<Book> GetCollection()
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

        public Book ConvertItem(string item)
        {
            var itemList = item.Split(';');

            return new Book()
            {
                Id = Convert.ToInt32(itemList[0]),
                Name = itemList[1],
                Author = itemList[2],
                Genre = Convert.ToInt32(itemList[3])
              
            };
        }
    }
}