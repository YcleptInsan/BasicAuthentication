using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using BasicAuthentication.ViewModels;
using BasicAuthentication.Models;



namespace BasicAuthentication.Controllers
{
    public class Roles : Controller
    {
        private readonly ApplicationDbContext _db;
        

        public Roles(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: /Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                _db.Roles.Add(new Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole()
                {
                    Name = collection["RoleName"]
                });
                _db.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully !";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
