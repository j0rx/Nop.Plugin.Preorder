using Nop.Core.Domain.Customers;
using Nop.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Nop.Plugin.Preorder.Services
{
    public interface IPreorderService
    {
        /// <summary>
        /// Creates a preorder
        /// </summary>
        /// <param name="preorder">The preorder.</param>
        Domain.Preorder Create(Domain.Preorder preorder);
        public Domain.Preorder GetActive(Customer customer, string month);
    }
}
namespace Nop.Plugin.Preorder.Services
{
    class PreorderService : IPreorderService
    {
        private readonly IRepository<Domain.Preorder> _preorderRepository;
        private readonly IRepository<Customer> _customerRepository;
        public PreorderService(IRepository<Domain.Preorder> preorderRepository, IRepository<Customer> customerRepository)
        {
            _preorderRepository = preorderRepository;
            _customerRepository = customerRepository;
        }
        public Domain.Preorder Create(Domain.Preorder preorder)
        {
           
            if (preorder == null)
            {
                throw new ArgumentNullException(nameof(preorder));
            }
            _preorderRepository.Insert(preorder);
            return preorder;
        }

        public Domain.Preorder GetActive(Customer customer, string month)
        {
            var query = _preorderRepository.Table;
            return query.Where(p => p.CustomerId == customer.Id && p.Status=="Active" && p.Month==month).FirstOrDefault();
        }
    }
}
