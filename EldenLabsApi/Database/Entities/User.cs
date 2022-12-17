using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EldenLabsApi.Database.Entities
{
    public class User
    {
        [Key]
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
