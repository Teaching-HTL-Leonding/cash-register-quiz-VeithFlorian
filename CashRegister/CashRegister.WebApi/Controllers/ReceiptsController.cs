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
    public class ReceiptsController : ControllerBase
    {
        private readonly CashRegisterDataContext DataContext;

        public ReceiptsController(CashRegisterDataContext dataContext)
        {
            DataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<ProductsController.ReceiptLineDto> receiptLineDto)
        {
            if (receiptLineDto.Count < 1) return BadRequest();


            // Read product data from DB for incoming product IDs
            var products = new Dictionary<int, Product>();

            // Here you have to add code that reads all products referenced by product IDs
            // in receiptDto.Lines and store them in the `products` dictionary.

            foreach (var receiptLine in receiptLineDto)
            {
                var product = await DataContext.Products.FirstOrDefaultAsync(p => p.ID == receiptLine.ProductID);
                if (product == null) return BadRequest();
                products.Add(product.ID, product);
            }

            // Build receipt from DTO
            var newReceipt = new Receipt
            {
                ReceiptTimestamp = DateTime.UtcNow,
                ReceiptLines = receiptLineDto.Select(rl => new ReceiptLine
                {
                    ID = 0,
                    Product = products[rl.ProductID],
                    Amount = rl.Amount,
                    TotalPrice = rl.Amount * products[rl.ProductID].UnitPrice
                }).ToList()
            };
            newReceipt.TotalPrice = newReceipt.ReceiptLines.Sum(rl => rl.TotalPrice);
            
            await DataContext.Receipts.AddAsync(newReceipt);
            await DataContext.SaveChangesAsync();

            return Created("", newReceipt);
        }
    }
}