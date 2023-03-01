using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CrudeApp.Models
{
    public class User
    {

        public int? Id { get; set; } = null!;
        [Required(ErrorMessage="User Name is required")]
        public string UserName { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Create Time is required")]
        public DateTime CreateTime { get; set; } 

        [Required(ErrorMessage ="Last Active Time is required")]
        [DataType(DataType.DateTime)]
        [DefaultValue(typeof(DateTime), "2000-1-1 0:0:0")]
        public DateTime LastActiveTime { get; set; }
    }
}
