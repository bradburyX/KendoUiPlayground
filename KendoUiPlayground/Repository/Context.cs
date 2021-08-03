using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using KendoUiPlayground.Repository.Model;

namespace KendoUiPlayground.Repository
{
    public class Context
    {
        private static Fixture _fixture = new Fixture();

        private static List<Customer> _customerList
            = Enumerable.Range(1, 19).Select(_ => _fixture.Create<Customer>()).ToList();

        public IEnumerable<Customer> GetAll() => _customerList;
        public Customer GetById(Guid id) => _customerList.FirstOrDefault(c => c.Id == id);

        public void Delete(Guid id)
        {
            _customerList.Remove(GetById(id));
        }
        public Customer Update(Customer customer)
        {
            _customerList[_customerList.FindIndex(c => c.Id == customer.Id)] 
                = customer;
            return customer;
        }
        public Customer Insert(Customer customer)
        {
            customer.Id = Guid.NewGuid();
            _customerList.Add(customer);
            return customer;
        }

    }
}
