using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud_Com_Banco.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Com_Banco.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerservice) {
            _sellerService = sellerservice;
        }

        public IActionResult Index()
        {
            var List = _sellerService.FindAll();
            return View(List);
        }
    }
}