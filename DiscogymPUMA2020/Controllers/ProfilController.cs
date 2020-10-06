﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscogymPUMA2020.Controllers
{
    public class ProfilController : Controller
    {
        // GET: ProfilController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProfilController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfilController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfilController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfilController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfilController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfilController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfilController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
