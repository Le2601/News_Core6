using News_Core6.ModelViews;

namespace News_Core6.DI.Post
{
    public interface IPostRepository
    {

        IEnumerable<PostViewModel> ListPosts();

        PostViewModel Create(News_Core6.Areas.Admin.Data.Post model);

        PostViewModel GetById(int id);


        

      
       

        

    }
}
