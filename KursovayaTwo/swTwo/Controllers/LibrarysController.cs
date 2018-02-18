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

         public IActionResult OrderBook()
        {
            return View();
        }

       [HttpGet]
       public IActionResult History()
        {
             var calc = new Input()
            {
                  BookName = " ",
                  PersonName = "p",
                  EmployeeId = 0,
                  PersonId = 0
            };
            return View(calc);
           
        }
       [HttpPost]
         public IActionResult History(Details model)
        {
              LibraryManager lbm = new LibraryManager(); 
              var bookList     = store.returnBook();   
              var recordList   = store.returnRecord(); 
              var employeeList = store.returnEmployees(); 
              var readerList   = store.returnReader();  
              var value3 = lbm.ReturnHistory(bookList,recordList,employeeList,readerList,model.PersonName);
              return View(value3);
        }
    }
}