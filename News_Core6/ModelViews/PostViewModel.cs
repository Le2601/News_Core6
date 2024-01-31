using System.ComponentModel.DataAnnotations;

namespace News_Core6.ModelViews
{
    public class PostViewModel
    {

        public int Id { get; set; }

    
        public string? Title { get; set; }

        public string? Summary { get; set; }
        public string? Description { get; set; }


        public string? DefaultImage { get; set; }

        public byte[]? Data { get; set; }

        public string? Alias { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int NewId { get; set; }

    }
}
