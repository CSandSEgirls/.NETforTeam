using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogisticCompany.Models;
using myLibrary;
using myLibrary.Models;
using System.IO;
using System.Text;


namespace LogisticCompany.Controllers
{
    public class TransportController : Controller
    {
        private Library lb;
        public string Path = "App_Data/orders.csv";  
        public string Path2 = "App_Data/route.csv";
        TransportManager transportManager;
           public TransportController()
        {
            lb = new Library();

        }
        [HttpGet]
        public IActionResult Category()
        {
            var res = new List<newCategory>();
           transportManager = new TransportManager();
           var category = lb.returnCategory();
           var cost     = lb.returnCost();
           var value = transportManager.returnCategoryDetail(category,cost);
           foreach(var item in value){
           var model = new newCategory{
                Id = item.Id,
                Price = item.Price,
                Type = item.Type,
                Weight = item.Weight
            };
            res.Add(model);
           }
            return View(res);
           
        }
        
        [HttpGet]
          public IActionResult Form()
        {
            transportManager = new TransportManager();
            var route = lb.returnRoute();
            var detailRoute  = lb.returnRouteDetails();
            var category = lb.returnCategory();
            var cost     = lb.returnCost();
            var orders   = lb.returnOrder();
            var value =  transportManager.returnRouteOrder(orders,route,detailRoute,category,cost);
            var value1 = transportManager.returnCategoryDetail(category,cost);
            var value2       = transportManager.returnRouteDetail(route,detailRoute );
              var model = new BasicModel 
            { 
                categoryList = value1,
                routeList =  value2,
                FullName = "Naz",
                Email ="naz@mail.ru",
                Phone = "777764532",
                CategoryId = 1,
                RouteId = 3

            };
            return View(model);
           
        }
        [HttpPost]
        public IActionResult Form(BasicModel model){
            transportManager = new TransportManager();
            var route = lb.returnRoute();
            var detailRoute  = lb.returnRouteDetails();
            var category = lb.returnCategory();
            var cost     = lb.returnCost();
            var orders   = lb.returnOrder();
            var value =  transportManager.returnRouteOrder(orders,route,detailRoute,category,cost);
             var value1 = transportManager.returnCategoryDetail(category,cost);
             var value2       = transportManager.returnRouteDetail(route,detailRoute );
              var model1 = new BasicModel 
            { 
                categoryList = value1,
                routeList =  value2,
                PersonId = 2,
                FullName = model.FullName,
                Email =model.Email,
                Phone = model.Phone,
                CategoryId = model.CategoryId,
                RouteId = model.RouteId,
                Status = model.Status

            };
            Console.WriteLine(model.FullName);
            string orderString =model.PersonId+";"+model.FullName+";"+model.Phone+";"+model.Email+";"+model.CategoryId+";"+model.RouteId;
           transportManager.writeToFile(Path,orderString);
            return View(model1);
        }
        public IActionResult Status()
        {
            var status = lb.returnDelivery();
            transportManager = new TransportManager();
            var route = lb.returnRoute();
            var detailRoute  = lb.returnRouteDetails();
            var category = lb.returnCategory();
            var cost     = lb.returnCost();
            var orders   = lb.returnOrder();
            var joinedOrder =  transportManager.returnRouteOrder(orders,route,detailRoute,category,cost);
            var value = transportManager.returnStatus(status,joinedOrder);
           return View(value);
        }
        [HttpGet]
         public IActionResult Route()
        {
            transportManager = new TransportManager();
            var route        = lb.returnRoute();
            var detailRoute  = lb.returnRouteDetails();   
            var value       = transportManager.returnRouteDetail(route,detailRoute );
            return View(value);
        }
        [HttpGet]
           public IActionResult Delete()
        {
            transportManager = new TransportManager();
            var route        = lb.returnRoute();
             var res = new List<Route>();
             foreach(var item in route){
           var model = new Route{
                Id = item.Id,
                FromWhereToWhere = item.FromWhereToWhere
            };
            res.Add(model);
           }
            //var value       = transportManager.returnRouteDetail(route,detailRoute );
            return View(route);
        }
        [HttpPost]
        public IActionResult Delete(Route model)
        {
           transportManager = new TransportManager();
            var route        = lb.returnRoute();
           int indx = model.Id;
           var array = transportManager.deleteElement(Path2,route,indx);
           return View(array);
        }

        public IActionResult Delivery(){
            var res = new List<newOrder>();
            transportManager = new TransportManager();
            var route = lb.returnRoute();
            var detailRoute  = lb.returnRouteDetails();
            var category = lb.returnCategory();
            var cost     = lb.returnCost();
            var orders   = lb.returnOrder();
            var value =  transportManager.returnRouteOrder(orders,route,detailRoute,category,cost);
            foreach(var item in value){
                var model = new newOrder 
            { 
                 Id = item.Id,
                 Price = item.Price,
                FullName = item.FullName,
                Flag = item.Flag,
                Email =item.Email,
                Phone  = item.Phone,
                Type = item.Type,
                Weight  = item.Weight ,
                FromWhereToWhere  = item.FromWhereToWhere,
                Days = item.Days

             };
              res.Add(model);
            }
            
            
          return View(res);
        }
         [HttpPost]
        public IActionResult Delivery(newOrder model){
           
            transportManager = new TransportManager();
            var route = lb.returnRoute();
            var detailRoute  = lb.returnRouteDetails();
            var category = lb.returnCategory();
            var cost     = lb.returnCost();
            var orders   = lb.returnOrder();
            var value =  transportManager.returnRouteOrder(orders,route,detailRoute,category,cost);
             if(model.Flag.Equals("SortByName")){
               ///  Console.WriteLine("sort");
                 string v = "SortByName";
                var newValue = transportManager.SortName(v,value);
                return View(newValue);
            }else if(model.Flag.Equals("SortByEmail")){
                string v2 = "SortByEmail";
              //  Console.WriteLine("EmailSort");
                var newValue = transportManager.SortName(v2,value);
                return View(newValue);
            }else if(model.Flag.Equals("GroupByType")){
               var groups = transportManager.makeGroupping(value);
               return View(groups);
            }
            else{
                return View(value);
           }
           
        }

    }
}