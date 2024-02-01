using News_Core6.ModelViews;

namespace News_Core6.DI.User.Home
{
    public interface IHomeRepository
    {
        IEnumerable<PostViewModel> ListPostHome();

        IEnumerable<NewViewModel> ListNewHome();

        //1 bai viet moi nhat
        PostViewModel OnlyOnePost();

    }
}
