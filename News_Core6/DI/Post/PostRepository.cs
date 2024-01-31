using News_Core6.Models;
using News_Core6.ModelViews;
using News_Core6.Areas.Admin.Data;
namespace News_Core6.DI.Post
{
    public class PostRepository : IPostRepository
    {

        private readonly AppDbContext _appDbContext;

        public PostRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public PostViewModel Create(News_Core6.Areas.Admin.Data.Post model)
        {
            
           if( model.Title == null || model.Description == null || model.Summary == null) {


                throw new InvalidOperationException("Title, Description, and Summary cannot be null.");

            }

            var item = new Models.Post
            {
               
                Title = model.Title,
                Description = model.Description,
                Summary = model.Summary,
                DefaultImage = model.DefaultImage,
                Data = model.Data,
                CreatedDate = model.CreatedDate,
                Alias = model.Alias,
                NewId = model.NewId,
            };

            _appDbContext.Add(item);
            _appDbContext.SaveChanges();






            return new PostViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Summary = model.Summary,
                DefaultImage = model.DefaultImage,
                Data = model.Data,
                CreatedDate = model.CreatedDate,
                Alias = model.Alias,
                NewId = model.NewId,
            };

            
            
        }

        public PostViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostViewModel> ListPosts()
        {
            throw new NotImplementedException();
        }
    }
}
