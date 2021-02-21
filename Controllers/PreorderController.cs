using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Plugin.Preorder.Models;
using Nop.Plugin.Preorder.Services;
using Nop.Services.Configuration;
using Nop.Services.Customers;
using Nop.Services.Security;
using Nop.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
namespace Nop.Plugin.Preorder.Controllers
{

    public class PreorderController : BasePluginController
    {
        private readonly ICustomerService _customerService;
        private readonly IWorkContext _workContext;
        private readonly IPreorderItemService _preorderItemService;
        private readonly IPreorderService _preorderService;
        private readonly IPermissionService _permissionService;
        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;
        public PreorderController(CustomerService customerService, IWorkContext workContext, IPreorderItemService preorderItemService, IPreorderService preorderService)
        {
            _customerService = customerService;
            _workContext = workContext;
            _preorderItemService = preorderItemService;
            _preorderService = preorderService;
        }
        [HttpPost]
        public  IActionResult Order(OrderItemVM product)
        {
            var customer = _workContext.CurrentCustomer;
            var preOrder = _preorderService.GetActive(customer, "test");
            if (preOrder == null)
            {
                preOrder = _preorderService.Create(new Domain.Preorder
                {

                    CreatedAt = DateTime.Now,
                    CustomerId = customer.Id,
                    Status = "Active",
                    Month = "test"
                });
            }
            _preorderItemService.Add(new Domain.PreorderItem
            {
                DateAdded = DateTime.Now,
                PreorderId = preOrder.Id,
                ProductId=product.ProductId,
                ProductName=product.Name,
                ProductPrice=product.Price,
                Qty=1
            },customer,"test");
            return View("/");
        }
        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var myWidgetSettings = _settingService.LoadSetting<PreorderSettings>(storeScope);

            var model = new ConfigurationModel
            {
                // configuration model settings here
            };

            if (storeScope > 0)
            {
                // override settings here based on store scope
            }

            return View("~/Plugins/Preorder/Views/Configure.cshtml", model);
        }
    }
}
