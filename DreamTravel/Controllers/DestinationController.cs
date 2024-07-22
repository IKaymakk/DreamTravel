﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager manager = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = manager.GetListAll();
            return View(values);
        }
        public IActionResult DestinationDetails(int id)
        {
            ViewBag.i = id;
            var did = manager.GetById(id);
            return View(did);
        }
    }
}
