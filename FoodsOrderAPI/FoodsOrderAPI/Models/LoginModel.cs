using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodsOrderAPI.Models
{

    [Table("LoginModel")]
    public class LoginModel
    {
        public int id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }
        [Required]
        [MaxLength(24)]
        public string Password { get; set; }
    }
}
