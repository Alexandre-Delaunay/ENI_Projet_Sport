using BO.Base;
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
    [AllowAnonymous]
    public class HomeController : Controller
    {
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
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        public ActionResult Index()
        {
            var user = UserManager.FindByIdAsync(User.Identity.GetUserId());
            var isDarkMode = false;
            if (user.Result != null)
            {
                isDarkMode = user.Result.displayConfiguration.IsDarkTheme;
            }
            
            BundleConfig.RegisterBundles(BundleTable.Bundles, isDarkMode);
            return View();
        }
    }
}