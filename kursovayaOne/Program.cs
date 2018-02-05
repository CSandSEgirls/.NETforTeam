using System;
using kursovayaOne.Models;

namespace kursovayaOne
{
    class Program
    { 
        
        static readonly string readerPath = "App_Data/reader.csv";  
        static readonly string recordPath = "App_Data/records.csv";  

        static void Main(string[] args)
        {
             var readerStore  = new ReaderStore() { Path =  readerPath };
             var readerList  = readerStore.GetCollection();

            var recordStore  = new RecordStore() { Path =  recordPath };
            var recordList  = recordStore.GetCollection();


             var readerss = readerList;
             
            var prodTemplate = "{0} | {1} | {2} ";

            Console.WriteLine(string.Format(prodTemplate, 
            "Id", 
            "Name", 
            "Course"));

            foreach(var p in readerss){
                Console.WriteLine(string.Format(prodTemplate,
                        p.Id, 
                        p.Name,
                        p.Course));
            }

            var records = recordList;
            var prodTemplate = "{0} | {1} | {2} ";

            Console.WriteLine(string.Format(prodTemplate, 
            "borrowed_date", 
            "returned_date", 
            "reader_id", 
            "employee_id", 
            "book_id"));

            foreach(var record in records){
                Console.WriteLine(string.Format(prodTemplate,
                        p.borrowed_date, 
                        p.returned_date,
                        p.reader_id, 
                        p.employee_id,
                        p.book_id));
            }
        }
    }
}
