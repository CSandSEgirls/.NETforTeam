using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kursovayaOne.Models{
    public class Record
    {
        public DateTime borrowed_date { get; set; }

        public DateTime returned_date  { get; set; }

        public Reader  reader_id  {get; set;}

        public Employee  employee_id  {get; set;}

        public Book  book_id  {get; set;}
    }
}