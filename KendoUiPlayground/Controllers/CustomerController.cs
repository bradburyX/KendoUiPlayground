using KendoUiPlayground.Models;
using KendoUiPlayground.Repository;
using KendoUiPlayground.Repository.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

        [HttpPut]
        public IActionResult Update([FromBody] List<CustomerViewModel> customerList)
        {
            return Json(
                customerList
                    .Select(c =>
                        _context.Update(c.Adapt<Customer>()).Adapt<CustomerViewModel>()
                    )
            );
        }
        [HttpPost]
        public IActionResult Create([FromBody] List<CustomerViewModel> customerList)
        {
            return Json(
                customerList
                    .Select(c =>
                        _context.Insert(c.Adapt<Customer>()).Adapt<CustomerViewModel>()
                    )
                );
        }

        [HttpDelete]
        public IActionResult Destroy([FromBody] List<CustomerViewModel> customerList)
        {
            customerList.ForEach(c=> _context.Delete(c.Id.Value));
            return Json(null);
        }
    }
}