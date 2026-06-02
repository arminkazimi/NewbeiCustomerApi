namespace NewbeiCustomerApi.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerRepository
    {
        private static List<Customer> _customers = new List<Customer>();
        private static int _nextId = 1;

        public List<Customer> GetAll()
        {
            return _customers.ToList();
        }

        public Customer GetById(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }

        public Customer Add(Customer customer)
        {
            if (!customer.IsValid())
                throw new System.Exception("invalid customer data");

            customer.Id = _nextId++;
            _customers.Add(customer);
            return customer;
        }

        public bool Update(int id, Customer customer)
        {
            var existing = GetById(id);
            if (existing == null)
                return false;

            if (!customer.IsValid())
                throw new System.Exception("invalid customer data");
            
            existing.FirstName = customer.FirstName;
            existing.LastName = customer.LastName;
            existing.NationalCode = customer.NationalCode;

            return true;
        }

        public bool Delete(int id)
        {
            var customer = GetById(id);
            if (customer == null)
                return false;

            _customers.Remove(customer);
            return true;
        }
    }
}