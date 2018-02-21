using System;
using System.IO;
using System.Linq;

namespace swTwo.Models{
    public class Input
    {
        public string BookName { get; set; }
        public int  EmployeeId  { get; set; }
        public int  PersonId  { get; set; }
        public int  BookId  { get; set; }
        public DateTime  BorrowDate { get; set; }

        public DateTime   ReturnDate   { get; set; }
       
       

    }
}