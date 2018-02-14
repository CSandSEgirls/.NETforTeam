using System;
using swoOne.Models;
using System.Linq;
using System.Collections.Generic;

namespace swoOne
{
    class Program
    { 
         static readonly string readerPath = "App_Data/reader.csv";  
        static readonly string recordPath = "App_Data/records.csv"; 
         static readonly string bookPath = "App_Data/books.csv"; 
        static readonly string empoyeesPath = "App_Data/employees.csv";  
        static void Main(string[] args)
        {
           var readerStore  = new ReaderStore() { Path =  readerPath };
             var readerList   = readerStore.GetCollection();

             var bookStore  = new BookStore() { Path =  bookPath };
             var bookList   = bookStore.GetCollection();

            var recordStore  = new RecordStore() { Path =  recordPath };
            var recordList   = recordStore.GetCollection();

            var employeeStore  = new EmployeesStore() { Path = empoyeesPath };
            var employeeList     = employeeStore.GetCollection();
         
        while(true){
                Console.WriteLine("[1] Show books" + 
                          "\n" + "[2] Show records" + 
                            "\n" + "[3] Order book"+
                                    "\n" + "[4] Show readers history");
                string choice = Console.ReadLine();
                switch(choice){
                    case "1":
                        var printhistory1  = new PrintHistory();
                        printhistory1.printBookList(bookList); 
                        break;
                    case "2":
                        var libraryManager2 = new LibraryManager();
                        var value2 = libraryManager2.ReturnDetails(bookList,recordList,employeeList,readerList);    
                        var printhistory2 = new PrintHistory();
                        printhistory2.printBorrow(value2);
                        break;
                    case "3":
                        Console.WriteLine("Enter willing books' name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Are you sure? (y/n)");
                        string answer = Console.ReadLine();
                        switch(answer){
                            case "y":
                                  var libraryManager4 = new LibraryManager(); 
                                  libraryManager4.oderBook(bookList,recordList,name);
                                break;
                            case "n":
                                break;
                            default:
                                break;
                        }
                        break;
                    case "4":             
                        var libraryManager3 = new LibraryManager(); 
                        var value3 = libraryManager3.ReturnHistory(bookList,recordList,employeeList,readerList);
                        var printhistory3 = new PrintHistory();
                        printhistory3.printHistory(value3);
                        break;
                    default:
                        break;
                }
        }  
    }
 }

  
}
