using System;
using kursovayaOne.Models;

namespace kursovayaOne
{
    class Program
    { 
        
        static readonly string readerPath = "App_Data/reader.csv";  
        static readonly string recordPath = "App_Data/records.csv"; 
        static readonly string empoyeesPath = "App_Data/employees.csv";   

        static void Main(string[] args)
        {
             var readerStore  = new ReaderStore() { Path =  readerPath };
             var readerList   = readerStore.GetCollection();

            var recordStore  = new RecordStore() { Path =  recordPath };
            var recordList   = recordStore.GetCollection();

            var employeeStore  = new EmployeesStore() { Path = empoyeesPath };
            var employeeList     = employeeStore.GetCollection();

            var readerss = readerList;
            var empllist = employeeList;  
            
             
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
              var prodTemplate = "{0} | {1} | {2} | {3}";

            // Console.WriteLine(string.Format(prodTemplate, 
            // "Id", 
            // "Name", 
            // "job_position",
            // "email"));

            // foreach(var p in empllist ){
            //     Console.WriteLine(string.Format(prodTemplate,
            //             p.employee_id, 
            //             p.name,
            //             p.job_position,
            //             p.email));
            // }
            // var records = recordList;
            // var prodTemplate = "{0} | {1} | {2} ";

            // Console.WriteLine(string.Format(prodTemplate, 
            // "borrowed_date", 
            // "returned_date", 
            // "reader_id", 
            // "employee_id", 
            // "book_id"));

            // foreach(var record in records){
            //     Console.WriteLine(string.Format(prodTemplate,
            //             p.borrowed_date, 
            //             p.returned_date,
            //             p.reader_id, 
            //             p.employee_id,
            //             p.book_id));
            // }
        }
    }
}
