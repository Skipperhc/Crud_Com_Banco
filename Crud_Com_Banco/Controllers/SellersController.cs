using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Crud_Com_Banco.Models;
using Crud_Com_Banco.Models.ViewModels;
using Crud_Com_Banco.Services;
using Crud_Com_Banco.Services.Exceptions;
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

        public IActionResult Delete(int? id) {
            if (id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id) {
            if (id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id) {
            if (id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Department> Department = _departmentService.FindAll();
            SellerFormViewModel viewmodel = new SellerFormViewModel { Seller = obj, Departments = Department };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller) {
            if (id != seller.Id) {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            } catch (ApplicationException e) {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message) {
            var viewModel = new ErrorViewModel {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }


    }
}