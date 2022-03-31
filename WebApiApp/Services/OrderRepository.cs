
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiApp.Model;

namespace WebApiApp.Services
{
    public class OrderRepository:IOrderRepository
    {
      
        private RepositoryContext _context;
        private OrderFilterModel _filterModel = new OrderFilterModel();
        public static int PAGE_SIZE { get; set; } = 5;
        public OrderRepository(RepositoryContext context)
        {

            _context = context;
            
            
        }



     
        public  List<OrderStatus> StatusList()
        {
            var statusesToShow = OrderStatus.Created| OrderStatus.InProgress | OrderStatus.Completed| OrderStatus.Failed| OrderStatus.Canceled| OrderStatus.Returned;

            return Enum
                .GetValues(typeof(OrderStatus))
                .Cast<OrderStatus>()
                .Where(x => (x & statusesToShow) == x)
                .ToList();
        }
        /*public PagedList<Order> GetOrdersPage(OrderFilterModel orderFilterModel)
        {
            List<OrderStatus> values = StatusList();
            // Filtering logic
            /*var orders = FindByCondition(o=>o.BrandId >= 10 &&
                                  o.BrandId <= 50);*/
                              

            /*foreach (var data in Enum.GetNames(typeof(OrderStatus)))
            {
                Console.WriteLine(data + " - " + (int)Enum.Parse(typeof(OrderStatus), data));
                deger.Add(data);
                
            }*/


            /*var orders = FindByCondition((int)Enum.Parse(typeof(OrderStatus),o=>o.Status) >= orderFilterModel.MinOrderStatus &&
                                           o=>o.Status<= orderFilterModel.MaxOrderStatus);*/


            /*earchByStoreName(ref orders, orderFilterModel.SearchText);
            SearchByCustumerName(ref orders, orderFilterModel.SearchText);
            var sortedOrders = _sortHelper.ApplySort(orders, orderFilterModel.SortBy);
            return PagedList<Order>.ToPagedList(sortedOrders,
                orderFilterModel.PageNumber,
                orderFilterModel.PageSize);
        }*/

   

      
        private void SearchByCustumerName(ref IQueryable<Order> orders, string custumerName)
        {
            if (!orders.Any() || string.IsNullOrWhiteSpace(custumerName))
                return;
            orders = orders.Where(o => o.CustomerName.ToLower().Contains(custumerName.Trim().ToLower()));
        }


     
        public List<Order> GetAll(string search, OrderStatus? from, OrderStatus? to, string sortBy, int page = 1)
        {
            var query = (from products
                    in _context.Orders
                         select products);

            if (!string.IsNullOrEmpty(search))
            {

                
                query = query.Where(p => p.StoreName.ToLower().Contains(search.Trim().ToLower()) || p.CustomerName.ToLower().Contains(search.Trim().ToLower()));
            }
            if (from.HasValue)
            {
                query = query.Where(hh => hh.Status >= from);
            }
            if (to.HasValue)
            {
                query = query.Where(hh => hh.Status <= to);
            }




            query = query.OrderBy(p => p.Id);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "StoreName": query = query.OrderBy(p => p.StoreName); break;
                    case "CustumerName": query = query.OrderBy(p => p.CustomerName); break;
                    case "BrandId": query = query.OrderBy(p => p.BrandId); break;
                    case "Price": query = query.OrderBy(p => p.Price); break;
                    case "CreatedOn": query = query.OrderBy(p => p.CreatedOn); break;
                    case "status": query = query.OrderBy(p => p.Status); break;
                }
            }
            /*if (sort == "asc")
            {
                query = query.OrderBy(p => p.Price);
            }
            else if (sort == "desc")
            {
                query = query.OrderByDescending(p => p.Price);
            }*/

            var result = PaginatedList<Order>.Create(query, page, _filterModel.PageSize);

            return result.Select(hh => new Order
            {
                Id = hh.Id,
                BrandId = hh.BrandId,
                StoreName = hh.StoreName,
                CustomerName = hh.CustomerName,
                Price = hh.Price,
                CreatedOn = hh.CreatedOn,
                Status = hh.Status

            }).ToList();
        }

        public List<Order> getOrders()
        {
            return _context.Orders.ToList();
            
        }

        public Order getById(int orderId)
        {
            return _context.Orders.SingleOrDefault(x => x.Id == orderId);

        }

        public void Save(Order order)
        {
           _context.Orders.Add(order);
           _context.SaveChanges();
            
           
        }
      

        public void Update(Order order)
        {
            
            
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public string Delete(int OrderId)
        {
            var orders = _context.Orders.FirstOrDefault(x => x.Id == OrderId);
            if (orders != null)
            {
                _context.Orders.Remove(orders);
                _context.SaveChanges();
            }
            return "Deleted";
        }

        public void Update(Order dbOrder, Order order)
        {
            
            dbOrder.BrandId = order.BrandId;
            dbOrder.Price = order.Price;
            dbOrder.StoreName = order.StoreName;
            dbOrder.CustomerName=order.CustomerName;
            dbOrder.CreatedOn = order.CreatedOn;
            dbOrder.Status =  order.Status;
            _context.SaveChanges();
        }
    }
}
