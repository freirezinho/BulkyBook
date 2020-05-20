using System;
using BulkyBook.Utility;
using Dapper;
using Microsoft.AspNetCore.Mvc;
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
            }

        #region API CALLS
        [HttpGet]
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
        }
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


        #endregion