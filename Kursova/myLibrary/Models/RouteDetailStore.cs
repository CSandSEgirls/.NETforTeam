using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace myLibrary.Models{
    public class RouteDetailStore : IStore<RouteDetail>
    {
        private List<RouteDetail> _cachedCollection;

        public string Path { get; set; }

        public List<RouteDetail> GetCollection()
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

        public  RouteDetail ConvertItem(string item)
        {
            var itemList = item.Split(';');

            return new RouteDetail()
            {
                Id = Convert.ToInt32(itemList[0]),
                RouteId = Convert.ToInt32(itemList[1]),
                Days = itemList[2]
            };
        }
    }
}