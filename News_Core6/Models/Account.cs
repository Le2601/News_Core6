using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace News_Core6.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public bool Active { get; set; }
        public string?  FullName { get; set; }
        public int? RoleId { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Role? Role { get; set; }

    }

}
