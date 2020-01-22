using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud_Com_Banco.Models;
using Crud_Com_Banco.Models.ViewModels;
using Crud_Com_Banco.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Com_Banco.Controllers {
    public class SellersController : Controller {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;
        public SellersController(SellerService sellerservice, DepartmentService departmentservice) {
            _sellerService = sellerservice;
            _departmentService = departmentservice;
        }

        public IActionResult Index() {
            var List = _sellerService.FindAll();
            return View(List);
        }

        public IActionResult Create() {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) {

            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }


    }
}