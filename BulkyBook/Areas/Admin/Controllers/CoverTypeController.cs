using System;using System.Collections.Generic;using System.Linq;using System.Threading.Tasks;using BulkyBook.DataAccess.Repository.IRepository;using BulkyBook.Models;
using BulkyBook.Utility;
using Dapper;
using Microsoft.AspNetCore.Mvc;namespace BulkyBook.Areas.Admin.Controllers{    [Area("Admin")]    public class CoverTypeController : Controller    {        private readonly IUnitOfWork _unitOfWork;        public CoverTypeController(IUnitOfWork unitOfWork)        {            _unitOfWork = unitOfWork;        }        public IActionResult Index()        {            return View();        }        public IActionResult Upsert(int? id)        {            CoverType coverType = new CoverType();            if (id == null)
            {
                // Create
                return View(coverType);
            }
            // Edit

            var parameter = new DynamicParameters();
            parameter.Add("id", id);
            //Console.WriteLine("EDIT ID: {0}", id);
            coverType = _unitOfWork.SP_Call.OneRecord<CoverType>(SD.Proc_CoverType_Get, parameter);

            if (coverType == null)
            {
                return NotFound();
            }            return View(coverType);        }

        #region API CALLS
        [HttpGet]        public IActionResult GetAll()        {            IEnumerable<CoverType> allObj = _unitOfWork.SP_Call.List<CoverType>(SD.Proc_CoverType_GetAll, null);            return Json(new { data = allObj });        }        [HttpPost]        [ValidateAntiForgeryToken]        public IActionResult Upsert(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                var parameter = new DynamicParameters();
                parameter.Add("name", coverType.Name);
                //Console.WriteLine("NAME: {0}", coverType.Name);

                if (coverType.Id == 0)
                {
                    _unitOfWork.SP_Call.Execute(SD.Proc_CoverType_Create, parameter);
                }
                else
                {
                    parameter.Add("id", coverType.Id);
                    //Console.WriteLine("Update ID: {0}", coverType.Id);
                    _unitOfWork.SP_Call.Execute(SD.Proc_CoverType_Update, parameter);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(coverType);
        }        [HttpDelete]        public IActionResult Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("id", id);
            //Console.WriteLine("EDIT ID: {0}", id);
            var objFromDB = _unitOfWork.SP_Call.OneRecord<CoverType>(SD.Proc_CoverType_Get, parameter);
            if(objFromDB == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.SP_Call.Execute(SD.Proc_CoverType_Delete, parameter);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }


        #endregion    }}