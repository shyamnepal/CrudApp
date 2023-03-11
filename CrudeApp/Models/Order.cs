using System.ComponentModel.DataAnnotations;

namespace CrudeApp.Models
{
    public class Order
    {
        public int? Id { get; set; }

        [Required(ErrorMessage ="Please select the Users")]
        public int UserId { get; set; }
        [Required(ErrorMessage ="Supply Name is required")]
        public string SupplyName { get; set; }
        [Required(ErrorMessage = "Unit Cost is required")]
        public decimal UnitCost { get; set; }
        [Required(ErrorMessage ="Unit Price is required")]
        public decimal UnitPrice { get; set; }
        [Required(ErrorMessage ="Markup is required")]
        public decimal Markup { get; set; }
        [Required(ErrorMessage ="Quantity is required")]
        public int Qty { get; set; }
        [Required(ErrorMessage ="Total Price is required")]
        public decimal TotalPrice { get; set; }
        [Required(ErrorMessage ="Create Time is required")]
        public DateTime CreateTime { get; set; }
       
    }
}
