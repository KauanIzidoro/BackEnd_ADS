using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cafeteria.Models;
using CafeteriaAPI.Data;

namespace CafeteriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CafeteriaContext _context;

        public ProductsController(CafeteriaContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDTO productDTO)
        {
            // Verifica se o ID da URL e o ID do DTO correspondem
            if (id != productDTO.Id)
            {
                return BadRequest();
            }

            // Busca o produto no banco de dados
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // Atualiza as propriedades do produto com os dados do DTO
            product.Name = productDTO.Name;
            product.Quantity = productDTO.Quantity;
            product.Category = productDTO.Category;
            product.Price = productDTO.Price;

            // Marca a entidade como modificada
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                // Salva as alterações no banco de dados
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
        public async Task<ActionResult<ProductDTO>> PostProduct(Product productDTO)
        {
            // Implementar a abstração da entidade ProductDTO 
            var product = new Product
            {
                Name = productDTO.Name,
                Quantity = productDTO.Quantity,
                Category = productDTO.Category,
                Price = productDTO.Price

            };

            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, ProductToDTO(product));
        }

        private static ProductDTO ProductToDTO(ProductsController product)
        {
            return new ProductDTO
            {
                Name = product.Name,
                Quantity = product.Quantity,
                Category = product.Category,
                Price = product.Price
            };
        }



        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
