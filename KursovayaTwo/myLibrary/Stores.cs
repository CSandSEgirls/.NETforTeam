using System;
using myLibrary.Models;
using System.Collections.Generic;

namespace myLibrary
{
    public class Stores
    {
        static readonly string readerPath = "App_Data/reader.csv";  
        static readonly string recordPath = "App_Data/records.csv"; 
        static readonly string bookPath = "App_Data/books.csv"; 
        static readonly string empoyeesPath = "App_Data/employees.csv"; 
        static void Main(string[] args)
        {
           
        }
         public List<Book> returnBook (){

             var bookStore  = new BookStore() { Path =  bookPath };
             var bookList   = bookStore.GetCollection();
             return  bookList ;
            
         }
        public List<Reader> returnReader (){

             var readerStore  = new ReaderStore() { Path =  readerPath };
             var readerList   = readerStore.GetCollection();
               return  readerList;
        }
         public List<Record> returnRecord (){
           
            var recordStore  = new RecordStore() { Path =  recordPath };
            var recordList   = recordStore.GetCollection();
               return recordList ;
        } 

        public List<Employees> returnEmployees (){
            var employeeStore  = new EmployeesStore() { Path = empoyeesPath };
            var employeeList     = employeeStore.GetCollection();
               return employeeList;
        } 

    }
}
