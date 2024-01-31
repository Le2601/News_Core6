using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace News_Core6.Models
{
    [Table("Role")]
    public class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        public int Id { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }


    }
}
