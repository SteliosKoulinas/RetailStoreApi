using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fromscratch_back.Data;
using fromscratch_back.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fromscratch_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly RetailStoreContext _context;

        public PurchasesController(RetailStoreContext context)
        {
            _context = context;
        }

        // GET: api/Purchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchases()
        {
            return await _context.Purchases
                .Include(p => p.PurchaseItems)
                .ToListAsync();
        }

        // GET: api/Purchases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Purchase>> GetPurchase(int id)
        {
            var purchase = await _context.Purchases
                .Include(p => p.PurchaseItems)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (purchase == null)
            {
                return NotFound();
            }

            return purchase;
        }

        // GET: api/Purchases/Customer/5
        [HttpGet("Customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchasesByCustomerId(int customerId)
        {
            var purchases = await _context.Purchases
                                          .Include(p => p.PurchaseItems)
                                          //.ThenInclude(pi => pi.Product)
                                          .Where(p => p.CustomerId == customerId)
                                          .ToListAsync();

            if (purchases == null || !purchases.Any())
            {
                return NotFound(new { message = "No purchases found for this customer." });
            }

            return purchases;
        }

        // POST: api/Purchases
        [HttpPost]
        public async Task<ActionResult<Purchase>> PostPurchase(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchase", new { id = purchase.Id }, purchase);
        }

        // DELETE: api/Purchases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            var purchase = await _context.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseExists(int id)
        {
            return _context.Purchases.Any(e => e.Id == id);
        }
    }
}
