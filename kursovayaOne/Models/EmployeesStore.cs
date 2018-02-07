using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kursovayaOne.Models{
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

        public Reader ConvertItem(string item)
        {
            var itemList = item.Split(';');

            return new Employees()
            {
            
                id    = Convert.ToInt32(itemList[0]),
                name = itemList[1],
                job_position  = itemList[2],
                email         = itemList[3]

            };
        }
    }
}