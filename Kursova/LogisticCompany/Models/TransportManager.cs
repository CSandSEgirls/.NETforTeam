using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System;

namespace myLibrary.Models{
    public class TransportManager
    {
        public List<newOrder> SortName(string val,List<newOrder> order){
            if(val.Equals("SortByName")){
                 var newValue = order
                        .OrderBy(x=>x.FullName).ToList();
                return newValue;
            }else{
                  var newValue = order
                        .OrderBy(x=>x.Email).ToList();
                return newValue; 
            }
            
        }
        public List<newOrder> makeGroupping(List<newOrder> order){
       
        
            return order ;
        }
         public List<newOrder> returnStatus(List<Delivery> status, List<newOrder> order){
           var statusAndOrder = status 
                            .Join(order,
                            st => st.OrderId,
                            orders => orders.Id,
                            (st, orders ) => new 
                            {
                                st,
                                orders
                            })
                            .ToList();
         var retunValue = statusAndOrder
                          .Select(x=>new newOrder(){
                                  Id = x.orders.Id,//zakaz id
                                  FullName = x.orders.FullName,
                                  Email    = x.orders.Email,
                                  Phone    = x.orders.Phone,
                                  FromWhereToWhere = x.orders.FromWhereToWhere,
                                  Price  = x.orders.Price,
                                  Type   = x.orders.Type,
                                  Weight = x.orders.Weight,
                                  Days   = x.orders.Days,
                                  Status = x.st.Status
                          }).ToList();
          return (retunValue);
            
         }
         public List<Route> deleteElement(string Path,List<Route> route, int indx){

             var newList = route
                           .Where(x=>x.Id != indx).ToList();
        //     File.WriteAllText(Path, String.Empty);
        //    foreach(var item in newList){
        //       using (StreamWriter sw = File.AppendText(Path))
        //      {
        //         sw.WriteLine(item.Id+";"+item.FromWhereToWhere);
        //      }
        //    }
                      
             return newList;
         }

        public List<newCategory> returnCategoryDetail(List<Category> category, List<Cost> cost){
          var categoryAndCost = category  
                            .Join(cost,
                            categorys => categorys.Id,
                            costs => costs.CategoryID,
                            (categorys, costs ) => new 
                            {
                                categorys,
                                costs 
                            })
                            .ToList();
         var retunValue = categoryAndCost
                          .Select(x=>new newCategory(){
                               Id = x.categorys.Id,
                               Type = x.categorys.Type,
                               Price = x.costs.Price,
                               Weight = x.categorys.Weight
                          }).ToList();
          return (retunValue);
        }
        public List<newRoute> returnRouteDetail(List<Route> route, List<RouteDetail> routeDetail){
          var categoryAndCost = routeDetail  
                            .Join(route,
                            routeDetails => routeDetails.RouteId,
                            routes => routes.Id,
                            (RouteDetails, routes ) => new 
                            {
                                RouteDetails,
                                routes 
                            })
                            .ToList();
         var retunValue = categoryAndCost
                          .Select(x=>new newRoute(){
                               Id = x.RouteDetails.Id,
                               Days = x.RouteDetails.Days,
                               FromWhereToWhere = x.routes.FromWhereToWhere   
                          }).ToList();
          return (retunValue);
        }
         public List<newOrder> returnRouteOrder(List<Order> order,List<Route> route, List<RouteDetail> routeDetail,
         List<Category> category, List<Cost> cost){
          var categoryAndCost = category  
                            .Join(cost,
                            categorys => categorys.Id,
                            costs => costs.CategoryID,
                            (categorys, costs ) => new 
                            {
                                categorys,
                                costs 
                            }).ToList();
          var RouteAndDetail = routeDetail  
                            .Join(route,///joined route
                            routeDetails => routeDetails.RouteId,
                            routes => routes.Id,
                            (RouteDetails, routes ) => new 
                            {
                                RouteDetails,
                                routes 
                            })
                            .Join(order,/// join order
                            routsDet => routsDet.RouteDetails.Id,
                            orderRoute => orderRoute.RouteId,
                            (routsDet,orderRoute)=> new {
                                routsDet,
                                orderRoute
                            })
                            .Join(categoryAndCost,//join to order category
                            mixdedCategory => mixdedCategory.orderRoute.CategoryId,
                            categoryID => categoryID.categorys.Id,
                            ( mixdedCategory,categoryID)=> new newOrder {
                                  Id = mixdedCategory.orderRoute.Id,//zakaz id
                                  FullName = mixdedCategory.orderRoute.FullName,
                                  Email    = mixdedCategory.orderRoute.Email,
                                  Phone    = mixdedCategory.orderRoute.Phone,
                                  FromWhereToWhere = mixdedCategory.routsDet.routes.FromWhereToWhere,
                                  Price  = categoryID.costs.Price,
                                  Type   = categoryID.categorys.Type,
                                  Weight = categoryID.categorys.Weight,
                                  Days   = mixdedCategory.routsDet.RouteDetails.Days,
                                  
                                  
                            }).ToList();
         
          return (RouteAndDetail);
        } 
        public void writeToFile(string Path, string str){
            using (StreamWriter sw = File.AppendText(Path))
            {
                sw.WriteLine(str);
            }
        }
      
    }
}