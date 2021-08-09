using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Helpers;

namespace WebApp.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    [Area("Admin")]
    public class DashboardController : Controller
    {
        IUnitOfWork _uow;
        public DashboardController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index(int page = 1, int pageSize = 2)
        {
            PagingModel<UserModel> model = _uow.UserRepo.GetUsers(page, pageSize);
            return View(model);
        }
    }
}
