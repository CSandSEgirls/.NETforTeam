using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System;

namespace myLibrary.Models{
    public class BasicModel
    {
        public List<newCategory> categoryList{get;set;}
        public List<newRoute> routeList{get;set;}
         public int Id { get; set; }
        public int PersonId{get;set;}
        public string FullName{get;set;}

        public string Phone{get;set;}
         
         public int CategoryId  { get; set; }
        public int RouteId  { get; set; }
        

        public string  Email  {get; set;}
        public object Status { get; internal set; }
    }
}