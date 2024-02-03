using News_Core6.Models;
using News_Core6.ModelViews;

namespace News_Core6.DI.User.Home
{
    public class HomeRepository : IHomeRepository
    {

        private readonly AppDbContext _appDbContext;

        public HomeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<NewViewModel> ListNewHome()
        {
            var items = _appDbContext.News.Select(x => new NewViewModel { 
            
                Id  = x.Id,
                Title = x.Title,
                Alias = x.Alias   
                    
            });
            return items;
        }

        public IEnumerable<PostViewModel> ListPostHome()
        {
            var items = _appDbContext.Posts.OrderBy(x => x.Id).Select(x => new PostViewModel
            {

                Id = x.Id,
                Title = x.Title,
                Alias = x.Alias,
                Summary = x.Summary,
                CreatedDate = x.CreatedDate,
                DefaultImage = x.DefaultImage
                

            });

            return items;
        }

        public PostViewModel OnlyOnePost()
        {
            var item = _appDbContext.Posts.OrderByDescending(d => d.CreatedDate).FirstOrDefault();

            return new PostViewModel
            {
                Id = item.Id,
                Title = item.Title,
                Alias = item.Alias,
                Summary = item.Summary,
                CreatedDate = item.CreatedDate,
                DefaultImage = item.DefaultImage
            };

        }

        public IEnumerable<PostViewModel> PageListHome()
        {
            var items = _appDbContext.Posts.OrderBy(x => x.Id).Select(x=> new PostViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Alias = x.Alias,
                Summary = x.Summary,
                CreatedDate = x.CreatedDate,
                DefaultImage = x.DefaultImage
            });

            return items;

        }
    }
}
