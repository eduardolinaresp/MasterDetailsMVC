using System.Collections.Generic;
using System.Threading.Tasks;
using DataModels.Stocks;
using System.Linq;
using System.Data.Entity;

namespace DataAccessLayer.Providers
{
    public class ItemsRepo : IItemsRepo
    {
        private readonly DataContext dataContext;

        internal ItemsRepo(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<int> Add(Item item)
        {
            this.dataContext.Items.Add(item);
            return await this.dataContext.SaveChangesAsync();
        }

        public async Task<ICollection<Item>> Get()
        {
            var result = await (from item in dataContext.Items
                                orderby item.Name
                                select item).ToListAsync();
            return result;
        }

        public async Task<Item> Get(int id)
        {
            return await dataContext.Items.FindAsync(id);
        }

        public async Task<int> Update(Item item)
        {
            dataContext.Entry(item).State = EntityState.Modified;
            return await dataContext.SaveChangesAsync();
        }
    }
}
