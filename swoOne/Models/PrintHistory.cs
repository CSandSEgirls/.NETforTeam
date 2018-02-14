using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace swoOne.Models{

     public class PrintHistory
    {
      public void printHistory(List<History> listHistory ){
         var prodTemplate1 = "{0} | {1} | {2} | {3}";

                Console.WriteLine(string.Format(prodTemplate1, 
                "Reader_Name", 
                "borrDate", 
                "retDate",
                "book_Name"));

                foreach(var p in listHistory){
                    Console.WriteLine(string.Format(prodTemplate1,
                            p.Name, 
                            p.BorrowDate,
                            p.ReturnDate,
                            p.BookName));
                }
      }

      public void printBorrow(List<Details> listRecord){
         var prodTemplate = "{0} | {1} | {2} | {3} | {4}";

            Console.WriteLine(string.Format(prodTemplate, 
            
            "reader_name", 
            "employee_id", 
            "bookName",
            "borrowed_date", 
            "returned_date" ));

            foreach(var p in listRecord){
                Console.WriteLine(string.Format(prodTemplate,
                        p.Name, 
                        p.EmployeeName,
                        p.BookName,
                        p.BorrowDate,
                        p.ReturnDate));
            }
      }
      public void printBookList(List<Book> listBook){
         var prodTemplate1 = "{0} | {1} | {2} | {3}";

            Console.WriteLine(string.Format(prodTemplate1, 
            "Id", 
            "Name", 
            "author",
            "genre"));

            foreach(var p in listBook){
                Console.WriteLine(string.Format(prodTemplate1,
                        p.Id, 
                        p.Name,
                        p.Author,
                        p.Genre));
            }
      }
    }
}