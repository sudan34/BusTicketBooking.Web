using BusTicketBooking.DataAccess.Infrastructure;
using BusTicketBooking.DataAccess.Repositories;
using BusTicketBooking.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketBooking.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BusController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public BusController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region APICALL
        public IActionResult GetAllBus()
        {
            //var bus = _unitOfWork.BusRepository.GetAll(includeProperties: "BusNumber,SeatCapacity");
            var bus = _unitOfWork.BusRepository.GetAll();
            return Json(new { data = bus });
        }

        #endregion

        #region CreateUpdateAPICALL
        public IActionResult CreateUpdate(int? id)
        {
            BusVm vm = new BusVm();
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Bus = _unitOfWork.BusRepository.GetFirstOrDefault(x => x.Id == id);
                if (vm == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(BusVm vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Bus.Id == 0)
                {
                    _unitOfWork.BusRepository.Insert(vm.Bus);
                    TempData["Success"] = "Bus Created Done!";
                }
                else
                {
                    _unitOfWork.BusRepository.Update(vm.Bus);
                    TempData["Success"] = "Bus Update Done!";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        #endregion


        #region DeleteAPICALL
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var bus = _unitOfWork.BusRepository.GetFirstOrDefault(x => x.Id == id);
            if (bus == null)
            {
                return Json(new { success = false, message = "Error in Featching Data" });
            }
            else
            {
                _unitOfWork.BusRepository.Delete(bus);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Bus Delated" });
            }
        }

        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }

}
