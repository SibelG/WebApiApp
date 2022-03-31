using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApiApp.Model
{

    public class OrderFilterModel
    {
        const int maxPageSize = 50;
     
        private int _pageSize = 5;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        //Bir istekte kaç sonuç döndüğü
    
        //Kaçıncı sayfanın döndüğü (Örneğin PageNumber=2, PageSize=25 iken 26-50 arasındaki sonuçları dönmeli)
        public int PageNumber { get; set; } = 1;
            //Arama metni, StoreName ve CustomerName değerleri üzerinde arama yapılabiliyor olmalı
        public string SearchText { get; set; }
            //Order CreatedOn değerinin minimum olması gereken değer
        public DateTime? StartDate { get; set; }
            //Order CreatedOn değerinin maximum olması gereken değer
        public DateTime? EndDate { get; set; }
            //Filtrelemek için alınan liste, örneğin [10,20] aldığı zaman sadece Created ve InProgress olan Order'lar dönmeli
        public List<OrderStatus> OrderStatuses { get; set; }
        //Gelen sonuçlar hangi Order alanına göre sıralanacak (ascending olarak sıralanmalı)
        //"Id", "BrandId", "Price", "StoreName", "CustomerName", "CreatedOn", "Status" değerlerini alabilir
     
        public string SortBy { get; set; }


        public OrderStatus MinStatus { get; set; }
        public OrderStatus MaxStatus { get; set; } = (OrderStatus)50;
        public bool ValidStatusRange => MinStatus > MaxStatus;



    }
}
