using System.ComponentModel.DataAnnotations;

namespace News_Core6.ModelViews
{
    public class NewViewModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Alias { get; set; }

    }
}
