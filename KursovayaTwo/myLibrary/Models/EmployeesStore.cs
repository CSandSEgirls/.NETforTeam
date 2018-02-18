using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace myLibrary.Models{
    public class EmployeesStore : IStore<Employees>
    { 
        private List<Employees> _cachedCollection;

        public string Path { get; set; }

        public List<Employees> GetCollection()
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

        public Employees ConvertItem(string item)
        {
            var itemList = item.Split(';');

            return new Employees()
            {
            
                Id            = Convert.ToInt32(itemList[0]),
                Name          = itemList[1],
                Job_position  = itemList[2],
                Email         = itemList[3]

            };
        }
    }
}