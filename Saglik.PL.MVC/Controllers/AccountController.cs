using Microsoft.AspNet.Identity;
using Saglik.BLL.Identity;
using Saglik.BLL.Repository;
using Saglik.DAL.Context;
using Saglik.Entity.Entity;
using Saglik.Entity.Identity;
using Saglik.PL.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saglik.PL.MVC.Controllers
{
    public class AccountController : BaseController
    {
        Repository<Uye> URepo = new Repository<Uye>(new SaglikContext());
        // GET: Account
        public ActionResult Register()
        {
            ApplicationRole role = new ApplicationRole();
            role.Name = "User";
            var rolemanager = IdentityTools.NewRoleManager();
            rolemanager.Create(role);
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVM model)
        {
            var usermanager = IdentityTools.NewUserManager();
            var kullanici = usermanager.FindByEmail(model.Email);
            if (kullanici != null)
            {
                ModelState.AddModelError("", "Bu email sistemde kayıtlı!");
                return View(model);
            }
            ApplicationUser user = new ApplicationUser();
            user.Email = model.Email;
            user.UserName = model.Email;
            user.Tarih = model.Tarih;
            var result = usermanager.Create(user, model.Password);

            if (result.Succeeded)
            {
                usermanager.AddToRole(user.Id, "User");
                Uye yeniuye = new Uye();
                yeniuye.ad = model.ad;
                yeniuye.soyad = model.soyad;
                yeniuye.tckno = model.tckno;
                yeniuye.adres = model.adres;
                yeniuye.UserId = user.Id;
                URepo.Add(yeniuye);
                return Redirect("/Home/Index");
            }
            return View(model);
        }
    }
}