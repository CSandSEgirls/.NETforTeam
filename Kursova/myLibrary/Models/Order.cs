using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System;

namespace myLibrary.Models{
    public class Order
    {
        public int Id { get; set; }

        public string FullName{get;set;}

        public string Phone{get;set;}
         
         public int CategoryId  { get; set; }
        public int RouteId  { get; set; }
        

        public string  Email  {get; set;}

        

       
    }
}