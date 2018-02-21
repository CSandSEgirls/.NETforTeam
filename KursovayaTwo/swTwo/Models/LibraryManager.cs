using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using myLibrary.Models;

namespace swTwo.Models{
    public class LibraryManager
    {
        public List<Details> ReturnDetails(List<Book> bookList,List<Record> recordList,
               List<Employees> employeeList,List<Reader> readerList){
             var newDetails = readerList
                                          .Join(recordList,
                                            reader =>reader.Id,
                                            record =>record.Reader_id,(reader,record)=>
                                                new {
                                                    reader, record
                                                }
                                            )
                                          .Join(employeeList,
                                            records =>records.record.Employee_id,
                                            employeer =>employeer.Id,(records,employeer)=>
                                                new {
                                                    records,employeer
                                                }
                                            )
                                          .Join(bookList,
                                            employees =>employees.records.record.Book_id,
                                            books => books.Id, (employees,books)=>
                                                new {
                                                    employees,books
                                                }
                                          
                                          ).ToList();
                      
                         
                         var joined = newDetails 
                                       .Select( x => 
                                        new 
                                        {
                                            name         = x.employees.records.reader.Name,
                                            employeeName = x.employees.employeer.Name,
                                            borrowDate   = x.employees.records.record.Borrowed_date,
                                            returnDate   = x.employees.records.record.Returned_date,
                                            bookName     =x.books.Name         
                                     }).Select(item => new Details(){
                                        Name         = item.name,
                                        EmployeeName = item.employeeName,
                                        BorrowDate   = item.borrowDate,
                                        ReturnDate   = item.returnDate,
                                        BookName     =item.bookName 
                            }).ToList();
            return joined;
        }
        public List<Historys> ReturnHistory(List<Book> bookList,List<Record> recordList,
               List<Employees> employeeList,List<Reader> readerList, string readerName){
                  
          
                         var newDetail = readerList
                                          .Join(recordList,
                                            reader =>reader.Id,
                                            record =>record.Reader_id,(reader,record)=>
                                                new {
                                                    reader, record
                                                }
                                            )
                                          .Join(employeeList,
                                            records =>records.record.Employee_id,
                                            employeer =>employeer.Id,(records,employeer)=>
                                                new {
                                                    records,employeer
                                                }
                                            )
                                          .Join(bookList,
                                            employees =>employees.records.record.Book_id,
                                            books => books.Id, (employees,books)=>
                                                new {
                                                    employees,books
                                                }
                                          
                                          ).ToList();
                      
                        var histories = newDetail
                                     .Where(x=> x.employees.records.reader.Name.Equals(readerName))
                                     .Select(k=>
                                        new {
                                            name         = k.employees.records.reader.Name,
                                            borrowDate   = k.employees.records.record.Borrowed_date,
                                            returnDate   = k.employees.records.record.Returned_date,
                                            bookName     = k.books.Name   
                                        }
                                     ).Select(item => new Historys(){
                                        Name         = item.name,
                                        BorrowDate   = item.borrowDate,
                                        ReturnDate   = item.returnDate,
                                        BookName     =item.bookName 
                                        
                            }).ToList();
             return histories;
        }
        public  List<Input> oderBook(List<Book> bookList,List<Record> recordList,string BookName,int readerID,int employeeID){
             

             // Console.WriteLine("Enter your reader_id");
                              //  int readerID = Convert.ToInt32(Console.ReadLine());
                             //   Console.WriteLine("Employees' ID have to be entered");
                               // int employeeID = Convert.ToInt32(Console.ReadLine());
                                var itemList = bookList
                                                .Where(x => x.Name == BookName)
                                                .Select(x=>x.Id)
                                                .ToList();
                                 int bookID=itemList.ElementAt(0);
                                Record newRecord = new Record();
                                newRecord.Borrowed_date = DateTime.Today;
                                newRecord.Returned_date =  DateTime.Today.AddDays(10);
                                newRecord.Reader_id = readerID;
                                newRecord.Employee_id = employeeID;
                                newRecord.Book_id =bookID;
                                recordList.Add(newRecord);
                                Input newInput = new Input();
                                newInput.BookId = bookID;
                                newInput.PersonId = readerID;
                                newInput.BorrowDate =  DateTime.Today;
                                newInput.BookName = BookName;
                                List<Input> items = new List<Input>();
                                items.Add(newInput);
                return items;
                             //   Console.WriteLine("You succesfully ordered the book!");
        }
        
    }
}