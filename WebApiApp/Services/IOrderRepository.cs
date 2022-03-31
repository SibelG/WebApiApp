using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiApp.Model;

namespace WebApiApp.Services
{
    public interface IOrderRepository
    {
        List<Order> getOrders();
        Order getById(int orderId);
        void Save(Order order);
        void Update(Order dbOrder,Order order);
        string Delete(int OrderId);

        List<Order> GetAll(string search, OrderStatus? from, OrderStatus? to, string sortBy, int page = 1);
       

    }
}
