using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudeApp.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;
        public DateTime CreateTime { get; set; }

        [DefaultValue(typeof(DateTime), "2000-1-1 0:0:0")]
        public DateTime LastActiveTime { get; set; } 
    }
}
