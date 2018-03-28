//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using TrashCollector.Models;

//namespace TrashCollector.Controllers
//{
//    public class UsersController : Controller
//    {
//        // GET: Users
//        public ActionResult Index()
//        {

//            return View();
//        }

//        public bool userChoice(string role)
//        {
//            if (User.Identity.IsAuthenticated)
//            {
//                var user = User.Identity;
//                ApplicationDbContext dbContext = new ApplicationDbContext();
//                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));
//                var userRole = userManager.GetRoles(user.GetUserId());
//                if(userRole[0].ToString() == role)
//                {
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//            }
//            return false;
//        }
//    }
//}