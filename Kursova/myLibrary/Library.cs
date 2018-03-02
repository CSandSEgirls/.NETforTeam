using System;
using myLibrary.Models;
using System.Collections.Generic;

namespace myLibrary
{
    public class Library
    {
        static readonly string routePath = "App_Data/route.csv";  
        static readonly string deliveryPath = "App_Data/delivery.csv"; 
        static readonly string orderPath = "App_Data/orders.csv"; 
        static readonly string costPath = "App_Data/cost.csv"; 
        static readonly string routeDetailPath = "App_Data/routeDetail.csv"; 
        static readonly string categoryPath = "App_Data/category.csv"; 
        static void Main(string[] args)
        { 
              
              var categoryStore  = new CategoryStore() { Path = categoryPath};
             var categorytList   = categoryStore.GetCollection();
            
               
             foreach(var item in categorytList ){
                 Console.WriteLine(item.Id+" "+item.Weight);
             }
            
        }
         public List<Route> returnRoute (){

             var routesStore  = new RouteStore() { Path =  routePath };
             var routeList   = routesStore.GetCollection();
             return  routeList ;
            
         }
        public List<Delivery> returnDelivery (){

             var deliveryStore  = new DeliveryStore() { Path =  deliveryPath };
             var deliveryList   = deliveryStore .GetCollection();
             return  deliveryList;
        }
        public List<Order> returnOrder (){

             var orderStore  = new OrderStore() { Path =  orderPath };
             var orderList   = orderStore .GetCollection();
             return  orderList;
        }
          public List<RouteDetail> returnRouteDetails (){

             var routeDetailStore  = new RouteDetailStore() { Path =  routeDetailPath };
             var routeDetailList   = routeDetailStore.GetCollection();
             return  routeDetailList;
        }
        
          public List<Cost> returnCost (){

             var costStore  = new CostStore() { Path =  costPath };
             var costList   = costStore.GetCollection();
             return  costList;
        }
          public List<Category> returnCategory (){

             var categoryStore  = new CategoryStore() { Path = categoryPath};
             var categorytList   = categoryStore.GetCollection();
             return categorytList;
        }
      

    }
}
