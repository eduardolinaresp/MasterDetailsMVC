using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer;
using DataModels.Stocks;

namespace Services.Providers
{
    public class ItemsService : IItemsService
    {
        private readonly IItemsRepo itemsRepo;

        public ItemsService(IItemsRepo itemsRepo)
        {
            this.itemsRepo = itemsRepo;
        }

        public async Task<int> Add(Item item)
        {
            return await this.itemsRepo.Add(item);
        }

        public async Task<ICollection<Item>> Get()
        {
            return await this.itemsRepo.Get();
        }

        public async Task<Item> Get(int id)
        {
            return await this.itemsRepo.Get(id);
        }

        public async Task<int> Update(Item item)
        {
            return await this.itemsRepo.Update(item);
        }
    }
}
