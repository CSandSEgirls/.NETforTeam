using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using swTwo.Models;
using myLibrary;
using myLibrary.Models;

namespace swTwo.Controllers
{
    public class LibrarysController : Controller
    {
        private Stores store;

        public LibrarysController()
        {
            store = new Stores();

        }
        
        [HttpGet]
        public IActionResult Book(string Flag = null, int page = 0)
        {

            var bookes = store.returnBook();
            LibraryManager lbm = new LibraryManager();
            ViewBag.PageCount = bookes.Count/10;
            
            var model = new BookModel 
            { 
                Books = bookes,
                BookPage =  ViewBag.PageCount
            };

            if (!string.IsNullOrEmpty(Flag)) {
                if(Flag.Equals("SortByName"))
                    model.Books = lbm.sortBookName(bookes);
                else if(Flag.Equals("SortByAuthor"))
                    model.Books = lbm.sortBookAuthor(bookes);
            }
           
            model.Books = model.Books.Skip(page * 10).Take(10).ToList();
            
            ViewBag.Flag = Flag;

            return View(model);
        }
        public IActionResult Record()
        {
            LibraryManager lbm = new LibraryManager();
            var bookList = store.returnBook();
            var recordList = store.returnRecord();
            var employeeList = store.returnEmployees();
            var readerList = store.returnReader();
            var detail = lbm.ReturnDetails(bookList, recordList, employeeList, readerList);
            return View(detail);
        }
         
        [HttpGet]
        public IActionResult OrderBook()
        {

            var res = new List<Input>();
            var val = new Input()
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
            var bookList = store.returnBook();
            var recordList = store.returnRecord();
            var employeeList = store.returnEmployees();
            var readerList = store.returnReader();
            var itms = lbm.oderBook(bookList, recordList, model.BookName, model.PersonId, model.EmployeeId);

            return View(itms);
        }
        [HttpGet]
        public IActionResult History()
        {
            var res = new List<Historys>();
            var val = new Historys()
            {
                BookName = "War and Peace ",
                Name = "Current",
                BorrowDate = DateTime.Now,
                ReturnDate = DateTime.Now
            };
            res.Add(val);

            return View(res);

        }
        [HttpPost]
        public IActionResult History(Historys model)
        {
            LibraryManager lbm = new LibraryManager();
            var bookList = store.returnBook();
            var recordList = store.returnRecord();
            var employeeList = store.returnEmployees();
            var readerList = store.returnReader();
            var value3 = lbm.ReturnHistory(bookList, recordList, employeeList, readerList, model.Name);
            return View(value3);
        }
    }
}