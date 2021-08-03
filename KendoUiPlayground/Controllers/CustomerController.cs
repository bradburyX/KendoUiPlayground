using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KendoUiPlayground.Models;
using KendoUiPlayground.Repository;
using KendoUiPlayground.Repository.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace KendoUiPlayground.Controllers
{
    public class CustomerController : Controller
    {
        private Context _context;

        public CustomerController()
        {
            _context = new Context();
        }

        public IActionResult Index()
        {
            return Json(
                _context
                    .GetAll()
                    .Adapt<IEnumerable<CustomerViewModel>>()
            );
        }

        [HttpPost]
        public IActionResult Update([FromBody] List<CustomerViewModel> customerList)
        {
            customerList.ForEach(c => _context.Update(c.Adapt<Customer>()));
            return Json(customerList);
        }
    }
}