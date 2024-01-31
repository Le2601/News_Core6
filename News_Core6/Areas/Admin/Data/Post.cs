using News_Core6.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace News_Core6.Areas.Admin.Data
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tieu de")]
        public string? Title { get; set; }

        public string? Summary { get; set; }
        public string? Description { get; set; }


        public string? DefaultImage { get; set; }

        public byte[]? Data { get; set; }

        public string? Alias { get; set; }

        public DateTime? CreatedDate { get; set; }






        [Required]
        public int NewId { get; set; }




        public virtual New? New { get; set; }





    }
}
