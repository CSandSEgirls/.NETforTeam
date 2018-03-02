using System;
using System.IO;
using System.Linq;

namespace swTwo.Models{
    public class Details
    {
        public string EmployeeName  { get; set; }
        public string PersonName{get; set;}
        public string  Name  { get; set; }
    
        public DateTime  BorrowDate { get; set; }

        public DateTime   ReturnDate   { get; set; }
        public string  BookName  { get; set; }
        public string Flag {get; set;}
       

    }
}