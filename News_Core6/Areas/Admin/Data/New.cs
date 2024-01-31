using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace News_Core6.Areas.Admin.Data
{
    [Table("New")]
    public class New
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tieu de")]
        public string? Title { get; set; }

        public string? Alias { get; set; }



        public virtual ICollection<Post>? Posts { get; set; }
    }
}
