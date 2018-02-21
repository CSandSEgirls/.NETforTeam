using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace swTwo.Models{
    public class Historys
    {
        public string Name  { get; set; }
        
        public DateTime  BorrowDate { get; set; }

        public DateTime   ReturnDate   { get; set; }
        public string  BookName  { get; set; }
    
    }
}