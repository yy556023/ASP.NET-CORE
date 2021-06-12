using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab_LINQ.Models;

namespace Lab_LINQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly LabDbContext _context;

        public ProductsController(LabDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        // public async Task<ActionResult<IEnumerable<Product>>> GetProducts() {
        public async Task<ActionResult<IEnumerable<dynamic>>> GetProducts() { 
            //var query = from o in _context.Products
            //            orderby o.CategoryId ascending, o.Price descending
            //            select o;
            var query = from o in _context.Products
                        join c in _context.Categories on o.CategoryId equals c.CategoryId
                        orderby o.CategoryId ascending, o.Price descending
                        select new {
                            CateoryId = o.CategoryId,
                            CategoryName = c.CategoryName,
                            ProductId = o.ProductId,
                            ProductName = o.ProductName,
                            Pirce = o.Price,
                            UnitsInStock = o.UnitsInStock
                        };
            return await query.ToListAsync();
            // return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // /api/Products/prie/100/100000
        [HttpGet("price/{minPrice}/{maxPrice}")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetProductByPrice(int minPrice, int maxPrice) {
            var query = from o in _context.Products
                        where o.Price >= minPrice && o.Price <= maxPrice
                        select new {
                            CategoryId = o.CategoryId,
                            ProductId = o.ProductId,
                            ProductName = o.ProductName,
                            Pirce = o.Price,
                            UnitsInStock = o.UnitsInStock
                        };

            return await query.ToListAsync();
        }


        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
