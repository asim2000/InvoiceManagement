using Data.Abstract;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    [Authorize(Roles ="admin")]
    
    public class AdminController:Controller
    {
        private IInvoiceInDal _invoiceInDal;
        private IInvoiceInLineDal _invoiceInLineDal;
        private IFirmDal _firmDal;
        private IExpenceDal _expenceDal;
        private UserManager<IdentityUser> _userManager;
        private IInvoiceOutDal _invoiceOutDal;
        private IInvoiceOutLineDal _invoiceOutLineDal;

        public AdminController(IInvoiceInDal invoiceInDal, IInvoiceOutLineDal invoiceOutLineDal, IInvoiceOutDal invoiceOutDal, IFirmDal firmDal, IInvoiceInLineDal invoiceInLineDal, IExpenceDal expenceDal, UserManager<IdentityUser> userManager)
        {
            _invoiceInDal = invoiceInDal;
            _invoiceInLineDal = invoiceInLineDal;
            _invoiceOutLineDal = invoiceOutLineDal;
            _firmDal = firmDal;
            _expenceDal = expenceDal;
            _userManager = userManager;
            _invoiceOutDal = invoiceOutDal;
        }


        //////// List ///////////

        [HttpGet]
        public IActionResult InvoiceInList()
        {
            var model = new List<InvoiceInListModel>()
            {
             
            };
            return View();
        }
        [HttpGet]
        public IActionResult InvoiceOutList()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CashInList()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CashOutList()
        {
            return View();
        }

        //////// Create ///////////
        [HttpGet]
        public IActionResult InvoiceInCreate()
        {
            ViewBag.Firms = JsonConvert.SerializeObject(_firmDal.GetAll());
            ViewBag.Users= JsonConvert.SerializeObject(_userManager.Users);
            ViewBag.Expences = JsonConvert.SerializeObject(_expenceDal.GetAll());
            return View();
        }
        [HttpGet]
        public IActionResult InvoiceOutCreate()
        {
            ViewBag.Firms = JsonConvert.SerializeObject(_firmDal.GetAll());
            ViewBag.Users = JsonConvert.SerializeObject(_userManager.Users);
            ViewBag.Expences = JsonConvert.SerializeObject(_expenceDal.GetAll());
            return View();
        }
        [HttpGet]
        public IActionResult CashInCreate()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CashOutCreate()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult InvoiceInCreate([FromBody]InvoiceInInvoiceInLineModel model)
        {
            var invoiceIn = new InvoiceIn()
            {
                InvoiceInNo = model.InvoiceIn.InvoiceNo,
                InvoiceInDate = model.InvoiceIn.Date,
                FirmId = _firmDal.Get(f => f.FirmName == model.InvoiceIn.FirmName).FirmId,
                UserId = _userManager.Users.FirstOrDefault(u => u.UserName == model.InvoiceIn.UserName).Id,
                InvoiceInStatus = model.InvoiceIn.Status
            };
            _invoiceInDal.Add(invoiceIn);

            foreach (var invoiceInLine in model.InvoiceInLine)
            {
                _invoiceInLineDal.Add(new InvoiceInLine()
                {
                    ExpenceId = _expenceDal.Get(e => e.ExpenceName == invoiceInLine.Expence).ExpenceId,
                    InvoiceInLinePrice = invoiceInLine.Price,
                    InvoiceInLineQuantity = invoiceInLine.Quantity,
                    InvoiceInLineTotal = invoiceInLine.Total,
                    InvoiceInLineStatus = invoiceInLine.Status,
                    InvoiceInId=invoiceIn.InvoiceInId
                });
            }
            return Redirect("/admin/invoiceInList");

        }
        [HttpPost]
        public IActionResult InvoiceOutCreate([FromBody] InvoiceOutInvoiceOutLineModel model)
        {
            var invoiceOut = new InvoiceOut()
            {
                InvoiceOutNo = model.InvoiceOut.InvoiceNo,
                InvoiceOutDate = model.InvoiceOut.Date,
                FirmId = _firmDal.Get(f => f.FirmName == model.InvoiceOut.FirmName).FirmId,
                UserId = _userManager.Users.FirstOrDefault(u => u.UserName == model.InvoiceOut.UserName).Id,
                InvoiceOutStatus = model.InvoiceOut.Status
            };
            _invoiceOutDal.Add(invoiceOut);

            foreach (var invoiceOutLine in model.InvoiceOutLines)
            {
                _invoiceOutLineDal.Add(new InvoiceOutLine()
                {
                    ExpenceId = _expenceDal.Get(e => e.ExpenceName == invoiceOutLine.Expence).ExpenceId,
                    InvoiceOutLinePrice = invoiceOutLine.Price,
                    InvoiceOutLineQuantity = invoiceOutLine.Quantity,
                    InvoiceOutLineTotal = invoiceOutLine.Total,
                    InvoiceOutLineStatus = invoiceOutLine.Status,
                    InvoiceOutId = invoiceOut.InvoiceOutId
                });
            }
            return Redirect("/admin/invoiceOutList");
        }
        //[HttpPost]
        //public IActionResult CashInCreate()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult CashOutCreate()
        //{
        //    return View();
        //}

        //////// Update ///////////
        [HttpGet]
        public IActionResult InvoiceInUpdate()
        {
            return View();
        }
        [HttpGet]
        public IActionResult InvoiceOutUpdate()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CashInUpdate()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CashOutUpdate()
        {
            return View();
        }



        //[HttpPost]
        //public IActionResult InvoiceInUpdate()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult InvoiceOutUpdate()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult CashInUpdate()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult CashOutUpdate()
        //{
        //    return View();
        //}

        //////// Delete ///////////
        [HttpGet]
        public IActionResult InvoiceInDelete(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult InvoiceOutDelete(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult CashInDelete(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult CashOutDelete(int id)
        {
            return View();
        }


        //[HttpPost]
        //public IActionResult InvoiceInDelete(int id)
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult InvoiceOutDelete(int id)
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult CashInDelete(int id)
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult CashOutDelete(int id)
        //{
        //    return View();
        //}
        [HttpPost]
        public IActionResult Index(InvoiceInModel model)
        {
            Console.WriteLine(model);
            return Ok(model);
        }
    }
}
