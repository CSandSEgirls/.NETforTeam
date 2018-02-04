using System;
using kursovayaOne.Models;

namespace kursovayaOne
{
    class Program
    { 
        
        static readonly string readerPath = "App_Data/reader.csv";  

        static void Main(string[] args)
        {
             var readerStore  = new ReaderStore() { Path =  readerPath };
             var readerList  = readerStore.GetCollection();

            
             var readerss = readerList;
             
              var prodTemplate = "{0} | {1} | {2} ";

                Console.WriteLine(string.Format(prodTemplate, 
                "Id", 
                "Name", 
                "Course"));

             foreach(var p in readerss){
               Console.WriteLine(string.Format(prodTemplate,
                        p.Id, 
                        p.Name,
                        p.Course));
             }
        }
    }
}
