using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace myLibrary.Models{
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
                Borrowed_date = DateTime.Parse(itemList[0]),
                Returned_date = DateTime.Parse(itemList[1]),
                Reader_id = Convert.ToInt32(itemList[2]),
                Employee_id = Convert.ToInt32(itemList[3]),
                Book_id = Convert.ToInt32(itemList[4])
            };
        }
    }
}