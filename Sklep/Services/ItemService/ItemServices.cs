using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sklep.Entities;
using Sklep.Exceptions;
using Sklep.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sklep.Services.ItemService
{
    public class ItemServices : IItemServices
    {
        private readonly Shop _shopContext;

        public ItemServices(Shop shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task<string> GetCategoryById(int id)
        {
            var result = await _shopContext.Category.Where(x => x.CategoryId == id).FirstOrDefaultAsync();
            return result.CategoryName;
        }

        public async Task<List<Category>> GetAllCategores()
        {
            var result = await _shopContext.Category.ToListAsync();
            return result;
        }

        public async Task<string> GetProposedItems(ProposedItemsRequest dto)
        {
            string result = null;

            return JsonSerializer.Serialize(result);
        }
        public async Task<List<Item>> GetAllItems(ItemsDto dto, string searchPhrasem)
        {
            //var item = new ItemsDto
            //{
            //    NameItem = dto.NameItem,
            //    Price = dto.Price,
            //    CategoryId = dto.CategoryId,
            //    Specification = dto.Specification,
            //};

            var items = await _shopContext.Item
                .Select(x => x)
                .Where(x => x.NameItem.ToLower().Contains(searchPhrasem.ToLower()))
                .ToListAsync();


            return items;
        } 

        public async Task AddItem(AddItemDto dto)
        {
            var item = new Item
            {
                NameItem = dto.NameItem,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
                Specification = dto.Specification
            };

            _shopContext.Item.Add(item);
            _shopContext.SaveChanges();

        }
    }
}
