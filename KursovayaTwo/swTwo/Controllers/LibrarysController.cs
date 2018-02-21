using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using swTwo.Models;
using myLibrary;

namespace swTwo.Controllers
{
    public class LibrarysController : Controller
    {
        private Stores store;

         public LibrarysController(){
           store = new Stores ();
           
       }

        public IActionResult Book()
        {
            var bookList = store.returnBook();         
            return View(bookList);
        }

         public IActionResult Record()
        {
            LibraryManager lbm = new LibraryManager(); 
            var bookList     = store.returnBook();   
            var recordList   = store.returnRecord(); 
            var employeeList = store.returnEmployees(); 
            var readerList   = store.returnReader();  
            var detail       = lbm.ReturnDetails(bookList,recordList,employeeList,readerList); 
            return View(detail);
        }
          [HttpGet]
         public IActionResult OrderBook()
        {

            var res = new List<Input>();
             var val = new Input ()
            {
                  BookId = 1,
                  BookName = "War and Peace",
                  PersonId = 0,
                  BorrowDate = DateTime.Now
            };
            res.Add(val);

            return View(res);
            
        }
         [HttpPost]
           public IActionResult OrderBook(Input model)
        {
            LibraryManager lbm = new LibraryManager(); 
              var bookList     = store.returnBook();   
              var recordList   = store.returnRecord(); 
              var employeeList = store.returnEmployees(); 
              var readerList   = store.returnReader();  
              var itms = lbm.oderBook(bookList,recordList,model.BookName,model.PersonId,model.EmployeeId);
            
              return View(itms);
        }
       [HttpGet]
       public IActionResult History()
        {
            var res = new List<Historys>();
             var val = new Historys ()
            {
                  BookName = "War and Peace ",
                  Name = "Current",
                  BorrowDate =  DateTime.Now,
                  ReturnDate =  DateTime.Now
            };
            res.Add(val);

            return View(res);
           
        }
       [HttpPost]
         public IActionResult History(Historys model)
        {
              LibraryManager lbm = new LibraryManager(); 
              var bookList     = store.returnBook();   
              var recordList   = store.returnRecord(); 
              var employeeList = store.returnEmployees(); 
              var readerList   = store.returnReader();  
              var value3 = lbm.ReturnHistory(bookList,recordList,employeeList,readerList,model.Name);
              return View(value3);
        }
    }
}