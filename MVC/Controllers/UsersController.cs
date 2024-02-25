#nullable disable
using Application.Models;
using Application.Services.Bases;
using Domain.Common.Results.Bases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Controllers.Bases;

//Generated from Custom Template.
namespace MVC.Controllers
{
	public class UsersController : MvcControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UsersController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        // GET: Users
        public IActionResult Index()
        {
            List<UserQueryModel> userList = _userService.GetQuery().ToList();
            return View(userList);
        }

        
        // GET: Users/Details/5
        public IActionResult Details(int id)
        {
            UserQueryModel user = _userService.GetQuery().SingleOrDefault(u => u.Id == id);
            if (user == null)
            {
                return View("Error", "User not found!");
            }
            return View(user);
        }

        
        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_roleService.GetQueryList(), "Id", "Name");
            return View(new UserCommandModel() { IsActive = true });
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserCommandModel userCommand)
        {
            if (ModelState.IsValid)
            {
                Result result = _userService.Create(userCommand);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
					return RedirectToAction(nameof(Details), new { id = userCommand.Id });
				}
                ModelState.AddModelError("", result.Message);
            }
			ViewData["RoleId"] = new SelectList(_roleService.GetQueryList(), "Id", "Name");
			return View(userCommand);
        }

        
        // GET: Users/Edit/5
        public IActionResult Edit(int id)
        {
            UserCommandModel user = _userService.GetCommand().SingleOrDefault(u => u.Id == id);
			if (user == null)
			{
				return View("Error", "User not found!");
			}
			ViewData["RoleId"] = new SelectList(_roleService.GetQueryList(), "Id", "Name");
			return View(user);
        }

        // POST: Users/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserCommandModel userCommand)
        {
			if (ModelState.IsValid)
			{
				Result result = _userService.Update(userCommand);
				if (result.IsSuccessful)
				{
					TempData["Message"] = result.Message;
					return RedirectToAction(nameof(Details), new { id = userCommand.Id });
				}
				ModelState.AddModelError("", result.Message);
			}
			ViewData["RoleId"] = new SelectList(_roleService.GetQueryList(), "Id", "Name");
			return View(userCommand);
		}


        // GET: Users/Delete/5
        public IActionResult Delete(int id)
        {
            UserQueryModel user = _userService.GetQuery().SingleOrDefault(u => u.Id == id);
            if (user == null)
            {
				return View("Error", "User not found!");
			}
            return View(user);
        }

        // POST: Users/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Result result = _userService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
    }
}
