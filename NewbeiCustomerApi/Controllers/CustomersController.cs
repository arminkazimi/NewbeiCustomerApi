using NewbeiCustomerApi.Models;

namespace NewbeiCustomerApi.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class CustomersController : ApiController
    {
        private readonly CustomerRepository _repository = new CustomerRepository();

        // GET: api/Customers
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var customers = _repository.GetAll();
            return Ok(customers);
        }

        // GET: api/Customers/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var customer = _repository.GetById(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // POST: api/Customers
        [HttpPost]
        public IHttpActionResult Post([FromBody] Customer customer)
        {
            try
            {
                if (customer == null)
                    return BadRequest("no data provided");

                var createdCustomer = _repository.Add(customer);
                return CreatedAtRoute("DefaultApi", new { id = createdCustomer.Id }, createdCustomer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Customers/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Customer customer)
        {
            try
            {
                if (customer == null)
                    return BadRequest("invalid data provided");
                
                customer.Id = id;

                bool result = _repository.Update(id, customer);
                if (!result)
                    return NotFound();

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Customers/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            bool result = _repository.Delete(id);
            if (!result)
                return NotFound();

            return Ok("customer has successfully deleted");
        }
    }
}