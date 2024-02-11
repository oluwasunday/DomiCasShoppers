using API.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CoffeeShopService : ICoffeeShopService
    {
        private readonly AppDbContext _appDbContext;

        public CoffeeShopService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<CoffeeShopModel>> List()
        {
            var coffeeShops = await (from shop in _appDbContext.CoffeeShops 
                                     select new CoffeeShopModel()
                                    {
                                        Id = shop.Id,
                                        Name = shop.Name,
                                        OpeningHours = shop.OpeningHours,
                                        Address = shop.Address
                                    }).ToListAsync();

            return coffeeShops;
        }
    }
}
