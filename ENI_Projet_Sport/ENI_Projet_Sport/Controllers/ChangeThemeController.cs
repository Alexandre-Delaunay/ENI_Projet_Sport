using BO.Base;
using BO.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace ENI_Projet_Sport.Controllers
{
    public class ChangeThemeController : Controller
    {
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServicePerson _servicePerson = _serviceLocator.GetService<IServicePerson>();
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: ChangeTheme
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeTheme()
        {
            var user = UserManager.FindByIdAsync(User.Identity.GetUserId());            
            var person = _servicePerson.GetById(user.Result.person.Id);

            person.IsDarkTheme = !person.IsDarkTheme;

            _servicePerson.Update(person);
            _servicePerson.Commit();

            if(person != null)
            {
                if (person.IsDarkTheme)
                    BundleConfig.RegisterBundles(BundleTable.Bundles, true);
                else
                    BundleConfig.RegisterBundles(BundleTable.Bundles, false);
            }

            return RedirectToAction("..");
        }
    }
}