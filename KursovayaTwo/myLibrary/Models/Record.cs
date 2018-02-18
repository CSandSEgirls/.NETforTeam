using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System;

namespace myLibrary.Models{
    public class Record
    {
        public DateTime Borrowed_date { get; set; }

        public DateTime Returned_date  { get; set; }

        public int  Reader_id  {get; set;}

        public int  Employee_id  {get; set;}

        public int  Book_id  {get; set;}
    }
}