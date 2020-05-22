using System;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

        //    {
        //        Product = new Product(),
        //        CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
        //        {
        //            Text = i.Name,
        //            Value = i.Id.ToString(),

        //        }),
        //        CoverTypeList = _unitOfWork.CoverType.GetAll().Select(i => new SelectListItem
        //        {
        //            Text = i.Name,
        //            Value = i.Id.ToString(),

        //        }),
        //    };
        //    {
        //        return View(productVM);
        //    }
        //    {
        //        return NotFound();
        //    }

        #region API CALLS
        [HttpGet]
        {
            if (ModelState.IsValid)
            {
                if (product.Id == 0)
                {
                    _unitOfWork.Product.Add(product);
                }
                else
                {
                    _unitOfWork.Product.Update(product);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        {
            var objFromDB = _unitOfWork.Product.Get(id);
            if(objFromDB == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Product.Remove(objFromDB);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }


        #endregion