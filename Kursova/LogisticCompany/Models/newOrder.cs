using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace myLibrary.Models{
    public class newOrder
    {

         public int Id{get;set;}
          public string Price {get;set;}
         public string FullName{get;set;}
        public string Flag{get;set;}
        public string  Email  {get; set;}
        public string Phone{get;set;}
        
        public string Type { get; set; }

        public string Weight {get;set;}

        
       public string FromWhereToWhere  { get; set; }

     public string  Days  {get; set;}
     public string Status{get;set;}


    }
}