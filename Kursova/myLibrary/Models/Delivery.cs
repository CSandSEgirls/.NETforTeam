using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System;

namespace myLibrary.Models{
    public class Delivery
    {
        public int Id { get; set; }

        public int  OrderId  {get; set;}

       public string  Status  {get; set;}
    }
}