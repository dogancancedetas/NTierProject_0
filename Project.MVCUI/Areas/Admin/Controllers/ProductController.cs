﻿using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
using Project.MVCUI.Areas.Admin.AdminVMClasses;
using Project.MVCUI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository _pRep;
        CategoryRepository _cRep;

        public ProductController()
        {
            _pRep = new ProductRepository();
            _cRep = new CategoryRepository();

        }
        // GET: Product
        public ActionResult ProductList(int? id)
        {
            ProductVM pvm = new ProductVM
            {
                Products = id == null ? _pRep.GetActives() : _pRep.Where(x => x.CategoryID == id)
            };

            return View(pvm);
        }

        public ActionResult AddProduct()
        {
            ProductVM pvm = new ProductVM
            {
                Categories = _cRep.GetActives()
            };
            return View(pvm);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product, HttpPostedFileBase resim)
        {
            product.ImagePath = ImageUploader.UploadImage("/Pictures/", resim);
            _pRep.Add(product);
            return RedirectToAction("ProductList");
        }

        public ActionResult UpdateProduct(int id)
        {
            //resim == null
            ProductVM pvm = new ProductVM
            {
                Product = _pRep.Find(id),
                Categories = _cRep.GetActives()
            };
            return View(pvm);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            _pRep.Update(product);
            return RedirectToAction("ProductList");
        }

        public ActionResult DeleteProduct(int id)
        {
            _pRep.Delete(_pRep.Find(id));
            return RedirectToAction("ProductList");
        }
    }
}