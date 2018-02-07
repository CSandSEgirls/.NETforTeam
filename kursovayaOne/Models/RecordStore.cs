using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kursovayaOne.Models{
    public class RecordStore : IStore<Record>
    {
        private List<Record> _cachedCollection;

        public string Path { get; set; }

        public List<Record> GetCollection()
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

        public Record ConvertItem(string item)
        {
            var itemList = item.Split(';');

            return new Record()
            {
                borrowed_date = itemList[0],
                returned_date = itemList[1],
                reader_id = Convert.ToInt32(itemList[2]),
                employee_id = Convert.ToInt32(itemList[3]),
                book_id = Convert.ToInt32(itemList[4])
            };
        }
    }
}