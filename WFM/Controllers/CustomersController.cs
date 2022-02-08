using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WFM.Data;
using WFM.Models;
using Microsoft.AspNetCore.Authorization;

namespace WFM.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomer()
        {
            var customers = await _context.Customer.ToListAsync();
            var customerModel = new List<CustomerModel>();
            for (int i = 0; i< customers.Count; i++)
            {
                Customer customer = new Customer()
                {
                    Id = customers[i].Id,
                    Name = customers[i].Name,
                    NationalID = customers[i].NationalID,
                    Mobile = customers[i].Mobile,
                    Number = customers[i].Number
                };
                customerModel.Add(new CustomerModel()
                {
                    Customer = customer,
                    Addresses = await _context.Address.Where(x => x.CustomerRefId == customers[i].Id).ToListAsync()
            });
            }
            return customerModel;
        }
        // GET: api/Customers/GetCustomerMeters/5
        [Route("GetCustomerMeters/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Meter>>> GetCustomerMeters(int id)
        {
            var meters = await _context.Meter.Where(x => x.CustomerRefId == id).ToListAsync();
            
            if (meters == null)
            {
                return NotFound();
            }

            return meters;
        }
        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModel>> GetCustomer(int id)
        {
            CustomerModel customerModel = new CustomerModel()
            {
                Customer = await _context.Customer.FindAsync(id),
                Addresses = await _context.Address.Where(x => x.CustomerRefId == id).ToListAsync()
            };
            if (customerModel.Customer == null)
            {
                return NotFound();
            }

            return customerModel;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerModel customer)
        {
            if (id != customer.Customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CustomerModel customer)
        {
            customer.Customer.CreationDate = DateTime.Now;
            _context.Customer.Add(customer.Customer);
            await _context.SaveChangesAsync();
            if (customer.Addresses != null)
            {
                if (customer.Addresses.Count != 0)
                {
                    for (int i = 0; i < customer.Addresses.Count; i++)
                    {
                        customer.Addresses[i].CustomerRefId = customer.Customer.Id;
                        _context.Address.Add(customer.Addresses[i]);
                        await _context.SaveChangesAsync();
                    }
                    await _context.SaveChangesAsync();
                }
            }
            return CreatedAtAction("GetCustomer", new { id = customer.Customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
