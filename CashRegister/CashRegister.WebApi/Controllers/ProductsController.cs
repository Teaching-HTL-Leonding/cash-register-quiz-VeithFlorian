using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashRegister.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CashRegister.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly CashRegisterDataContext DataContext;

        public record ReceiptLineDto(int ProductID, int Amount);

        public ProductsController(CashRegisterDataContext dataContext)
        {
            DataContext = dataContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get([FromQuery]string? nameFilter = null)
        {
            IQueryable<Product> products = DataContext.Products;

            // Apply filter if one is given
            if (!string.IsNullOrEmpty(nameFilter))
            {
                products = products.Where(p => p.ProductName.Contains(nameFilter));
            }

            return await products.ToListAsync();
        }
    }
}