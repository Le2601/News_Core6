using News_Core6.Models;
using News_Core6.ModelViews;
using News_Core6.Areas.Admin.Data;
namespace News_Core6.DI.New
{
    public interface INewRepository
    {

        IEnumerable<NewViewModel> ListNews();

        NewViewModel GetById(int id);

        NewViewModel Create(Areas.Admin.Data.New model);





    }
}
