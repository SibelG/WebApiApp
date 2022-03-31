using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApiApp.Model
{
    [Table(name:"Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "StoreName is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string StoreName { get; set; }

        [Required(ErrorMessage = "CustumerName is required")]
        [StringLength(60, ErrorMessage = "custumerName can't be longer than 60 characters")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
       
        public DateTime CreatedOn { get; set; }
        [Required]
        [EnumDataType(typeof(OrderStatus), ErrorMessage = "OrderStatus type value doesn't exist within enum")]
      
        public OrderStatus Status { get; set; }
        


    }
}
