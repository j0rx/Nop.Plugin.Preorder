using Nop.Core.Domain.Customers;
using Nop.Data;
using System;
using System.Collections.Generic;
using System.Text;


namespace Nop.Plugin.Preorder.Services
{
    public interface IPreorderItemService
    {
        /// <summary>
        /// Adds a item to preorder
        /// </summary>
        /// <param name="preorderItem">The preorder item.</param>
        void Add(Domain.PreorderItem preorderItem, Customer customer, string month);
    }
}
namespace Nop.Plugin.Preorder.Services
{
    public class PreorderItemService : IPreorderItemService
    {
        private readonly IRepository<Domain.PreorderItem> _preorderItemRepository;
        private readonly IPreorderService _preorderService;
        public PreorderItemService(IRepository<Domain.PreorderItem> preorderItemRepository, IPreorderService preorderService)
        {
            _preorderItemRepository = preorderItemRepository;
            _preorderService = preorderService;
        }
        public void Add(Domain.PreorderItem preorderItem, Customer customer, string month)
        {

            if (preorderItem == null)
            {
                throw new ArgumentNullException(nameof(preorderItem));
            }
            var preorder = _preorderService.GetActive(customer, month);
            preorderItem.PreorderId = preorder.Id;
            _preorderItemRepository.Insert(preorderItem);
        }
    }
}
