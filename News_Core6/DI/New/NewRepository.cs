using Microsoft.AspNetCore.Diagnostics;
using News_Core6.Models;
using News_Core6.ModelViews;

namespace News_Core6.DI.New
{
    public class NewRepository : INewRepository
    {

        private readonly AppDbContext _appDbContext;

        public NewRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public NewViewModel Create(News_Core6.Areas.Admin.Data.New model)
        {
            throw new NotImplementedException();
        }

        public NewViewModel GetById(int id)
        {
            
            var item = _appDbContext.News.FirstOrDefault(x => x.Id == id)!;

              
            return new NewViewModel
            {
                Id = item.Id,
                Title = item.Title,
                Alias = item.Alias,
            }; 



        }

        public IEnumerable<NewViewModel> ListNews()
        {

            var itemsNews = _appDbContext.News.Select(x => new NewViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Alias = x.Alias,
            });
            

            return itemsNews;
        }
    }
}
