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
        public async Task<IActionResult> InvoiceInList()
        {
            var models = new InvoiceInListModel()
            {
                InvoiceIns = _invoiceInDal.GetAll(),
                
            };
            foreach (var invoiceIn in models.InvoiceIns)
            {
                invoiceIn.InvoiceInLines = _invoiceInLineDal.GetAll(i => i.InvoiceInId == invoiceIn.InvoiceInId);
                invoiceIn.Firm = _firmDal.Get(i=>i.FirmId==invoiceIn.FirmId);
                invoiceIn.User = await _userManager.FindByIdAsync(invoiceIn.UserId);
                foreach (var invoiceInLine in invoiceIn.InvoiceInLines)
                {
                    invoiceInLine.Expence = _expenceDal.Get(i=>i.ExpenceId==invoiceInLine.ExpenceId);
                }
            }
            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> InvoiceOutList()
        {
            var models = new InvoiceOutListModel()
            {
                InvoiceOuts = _invoiceOutDal.GetAll(),

            };
            foreach (var invoiceOut in models.InvoiceOuts)
            {
                invoiceOut.InvoiceOutLines = _invoiceOutLineDal.GetAll(i => i.InvoiceOutId == invoiceOut.InvoiceOutId);
                invoiceOut.Firm = _firmDal.Get(i => i.FirmId == invoiceOut.FirmId);
                invoiceOut.User = await _userManager.FindByIdAsync(invoiceOut.UserId);
                foreach (var invoiceOutLine in invoiceOut.InvoiceOutLines)
                {
                    invoiceOutLine.Expence = _expenceDal.Get(i => i.ExpenceId == invoiceOutLine.ExpenceId);
                }
            }
            return View(models);
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
            GetViewBag();
            return View();
        }
        

        [HttpGet]
        public IActionResult InvoiceOutCreate()
        {
            GetViewBag();
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
            if (ModelState.IsValid)
            {
                var invoiceIn = new InvoiceIn()
                {
                    InvoiceInNo = model.InvoiceIn.InvoiceNo,
                    InvoiceInDate = model.InvoiceIn.Date,
                    FirmId = model.InvoiceIn.FirmId,
                    UserId = model.InvoiceIn.UserId,
                    InvoiceInStatus = model.InvoiceIn.Status
                };
                _invoiceInDal.Add(invoiceIn);

                foreach (var invoiceInLine in model.InvoiceInLine)
                {
                    _invoiceInLineDal.Add(new InvoiceInLine()
                    {
                        ExpenceId = invoiceInLine.ExpenceId,
                        InvoiceInLinePrice = invoiceInLine.Price,
                        InvoiceInLineQuantity = invoiceInLine.Quantity,
                        InvoiceInLineTotal = invoiceInLine.Total,
                        InvoiceInLineStatus = invoiceInLine.Status,
                        InvoiceInId = invoiceIn.InvoiceInId
                    });
                }
                return RedirectToAction("invoiceInList");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult InvoiceOutCreate([FromBody] InvoiceOutInvoiceOutLineModel model)
        {
            var invoiceOut = new InvoiceOut()
            {
                InvoiceOutNo = model.InvoiceOut.InvoiceNo,
                InvoiceOutDate = model.InvoiceOut.Date,
                FirmId = model.InvoiceOut.FirmId,
                UserId = model.InvoiceOut.UserId,
                InvoiceOutStatus = model.InvoiceOut.Status
            };
            _invoiceOutDal.Add(invoiceOut);

            foreach (var invoiceOutLine in model.InvoiceOutLines)
            {
                _invoiceOutLineDal.Add(new InvoiceOutLine()
                {
                    ExpenceId = invoiceOutLine.ExpenceId,
                    InvoiceOutLinePrice = invoiceOutLine.Price,
                    InvoiceOutLineQuantity = invoiceOutLine.Quantity,
                    InvoiceOutLineTotal = invoiceOutLine.Total,
                    InvoiceOutLineStatus = invoiceOutLine.Status,
                    InvoiceOutId = invoiceOut.InvoiceOutId
                });
            }
            return RedirectToAction("invoiceOutList");
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
        [HttpPost]
        public async Task<IActionResult> LoadInvoiceInUpdatePage(int invoiceInId, int invoiceInLineId)
        {
            GetViewBag();
            var invoiceInUpdateModel = new InvoiceInUpdateModel() {
                InvoiceIn = _invoiceInDal.Get(i => i.InvoiceInId == invoiceInId),
                InvoiceInLine =_invoiceInLineDal.Get(i => i.InvoiceInLineId == invoiceInLineId && i.InvoiceInId == invoiceInId)
        };
            invoiceInUpdateModel.InvoiceIn.User = await _userManager.FindByIdAsync(invoiceInUpdateModel.InvoiceIn.UserId);
            invoiceInUpdateModel.InvoiceIn.Firm = _firmDal.Get(i => i.FirmId == invoiceInUpdateModel.InvoiceIn.FirmId);

            invoiceInUpdateModel.InvoiceInLine.Expence = _expenceDal.Get(i => i.ExpenceId == invoiceInUpdateModel.InvoiceInLine.ExpenceId);
            return View(invoiceInUpdateModel);
        }
        [HttpPost]
        public async Task<IActionResult> LoadInvoiceOutUpdatePage(int invoiceOutId, int invoiceOutLineId)
        {
            GetViewBag();

            var invoiceOutUpdateModel = new InvoiceOutUpdateModel()
            {
                InvoiceOut = _invoiceOutDal.Get(i => i.InvoiceOutId == invoiceOutId),
                InvoiceOutLine = _invoiceOutLineDal.Get(i => i.InvoiceOutLineId == invoiceOutLineId && i.InvoiceOutId == invoiceOutId)
            };
            invoiceOutUpdateModel.InvoiceOut.User = await _userManager.FindByIdAsync(invoiceOutUpdateModel.InvoiceOut.UserId);
            invoiceOutUpdateModel.InvoiceOut.Firm = _firmDal.Get(i => i.FirmId == invoiceOutUpdateModel.InvoiceOut.FirmId);

            invoiceOutUpdateModel.InvoiceOutLine.Expence = _expenceDal.Get(i => i.ExpenceId == invoiceOutUpdateModel.InvoiceOutLine.ExpenceId);
            return View(invoiceOutUpdateModel);
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



        [HttpPost]
        public IActionResult InvoiceInUpdate(InvoiceInUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var invoiceIn = new InvoiceIn()
                {
                    InvoiceInId = model.InvoiceIn.InvoiceInId,
                    InvoiceInDate = model.InvoiceIn.InvoiceInDate,
                    InvoiceInNo = model.InvoiceIn.InvoiceInNo,
                    FirmId = model.InvoiceIn.FirmId,
                    UserId = model.InvoiceIn.UserId,
                    InvoiceInStatus = model.InvoiceIn.InvoiceInStatus
                };
                var invoiceInLine = new InvoiceInLine()
                {
                    InvoiceInLineId = model.InvoiceInLine.InvoiceInLineId,
                    InvoiceInId = model.InvoiceInLine.InvoiceInId,
                    ExpenceId = model.InvoiceInLine.ExpenceId,
                    InvoiceInLineQuantity = model.InvoiceInLine.InvoiceInLineQuantity,
                    InvoiceInLinePrice = model.InvoiceInLine.InvoiceInLinePrice,
                    InvoiceInLineTotal = model.InvoiceInLine.InvoiceInLineTotal,
                    InvoiceInLineStatus = model.InvoiceInLine.InvoiceInLineStatus
                };
                _invoiceInDal.Update(invoiceIn);
                _invoiceInLineDal.Update(invoiceInLine);
                return RedirectToAction("invoiceInList");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult InvoiceOutUpdate(InvoiceOutUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var invoiceOut = new InvoiceOut()
                {
                    InvoiceOutId = model.InvoiceOut.InvoiceOutId,
                    InvoiceOutDate = model.InvoiceOut.InvoiceOutDate,
                    InvoiceOutNo = model.InvoiceOut.InvoiceOutNo,
                    FirmId = model.InvoiceOut.FirmId,
                    UserId = model.InvoiceOut.UserId,
                    InvoiceOutStatus = model.InvoiceOut.InvoiceOutStatus
                };
                var invoiceOutLine = new InvoiceOutLine()
                {
                    InvoiceOutLineId = model.InvoiceOutLine.InvoiceOutLineId,
                    InvoiceOutId = model.InvoiceOutLine.InvoiceOutId,
                    ExpenceId = model.InvoiceOutLine.ExpenceId,
                    InvoiceOutLineQuantity = model.InvoiceOutLine.InvoiceOutLineQuantity,
                    InvoiceOutLinePrice = model.InvoiceOutLine.InvoiceOutLinePrice,
                    InvoiceOutLineTotal = model.InvoiceOutLine.InvoiceOutLineTotal,
                    InvoiceOutLineStatus = model.InvoiceOutLine.InvoiceOutLineStatus
                };
                _invoiceOutDal.Update(invoiceOut);
                _invoiceOutLineDal.Update(invoiceOutLine);
                return RedirectToAction("invoiceOutList");
            }
            return View(model);
        }
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
        [HttpPost]
        public IActionResult InvoiceInDelete(int id)
        {
            _invoiceInLineDal.Delete(_invoiceInLineDal.Get(i=>i.InvoiceInLineId==id));
            return RedirectToAction("invoiceInList");
        }
        [HttpPost]
        public IActionResult InvoiceOutDelete(int id)
        {
            _invoiceOutLineDal.Delete(_invoiceOutLineDal.Get(i => i.InvoiceOutLineId == id));
            return RedirectToAction("invoiceOutList");
        }
        [HttpPost]
        public IActionResult CashInDelete(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult CashOutDelete(int id)
        {
            return View();
        }
private void GetViewBag()
{
    ViewBag.Firms = JsonConvert.SerializeObject(_firmDal.GetAll());
    ViewBag.Users = JsonConvert.SerializeObject(_userManager.Users);
    ViewBag.Expences = JsonConvert.SerializeObject(_expenceDal.GetAll());
}
    }
}
