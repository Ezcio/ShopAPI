using Sklep.Entities;
using Sklep.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sklep.Services.ItemService
{
    public interface IItemServices
    {
        public Task<string> GetCategoryById(int id);
        //public Task<string> GetAllCategores();
        public Task<List<Category>> GetAllCategores();
        public Task<string> GetProposedItems(ProposedItemsRequest dto);
        public Task AddItem(AddItemDto dto);
        public Task<List<Item>> GetAllItems(ItemsDto dto, string searchPhrasem);
    }
}
