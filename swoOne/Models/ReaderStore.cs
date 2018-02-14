using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace swoOne.Models{
    public class ReaderStore : IStore<Reader>
    {
        private List<Reader> _cachedCollection;

        public string Path { get; set; }

        public List<Reader> GetCollection()
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

        public Reader ConvertItem(string item)
        {
            var itemList = item.Split(';');

            return new Reader()
            {
                Id = Convert.ToInt32(itemList[0]),
                Name = itemList[1],
                Course = Convert.ToInt32(itemList[2])
            };
        }
    }
}