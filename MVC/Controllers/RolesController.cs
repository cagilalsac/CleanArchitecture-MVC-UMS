#nullable disable
using Application.Models;
using Application.Services.Bases;
using Domain.Common.Results.Bases;
using Microsoft.AspNetCore.Mvc;
using MVC.Controllers.Bases;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class RolesController : MvcControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: Roles
        public IActionResult Index()
        {
            List<RoleQueryModel> roleList = _roleService.GetQueryList();
            return View(roleList);
        }

        // GET: Roles/Details/5
        public IActionResult Details(int id)
        {
            RoleQueryModel role = _roleService.GetQueryItem(id);
            if (role == null)
            {
                return View("Error", "Role not found!");
            }
            return View(role);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoleCommandModel roleCommand)
        {
            if (ModelState.IsValid)
            {
                Result result = _roleService.Create(roleCommand);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            return View(roleCommand);
        }

        // GET: Roles/Edit/5
        public IActionResult Edit(int id)
        {
            RoleCommandModel role = _roleService.GetCommandItem(id);
            if (role == null)
            {
                return View("Error", "Role not found!");
            }
            return View(role);
        }

        // POST: Roles/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RoleCommandModel roleCommand)
        {
            if (ModelState.IsValid)
            {
                Result result = _roleService.Update(roleCommand);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            return View(roleCommand);
        }

        // GET: Roles/Delete/5
        public IActionResult Delete(int id)
        {
            RoleQueryModel role = _roleService.GetQueryItem(id);
            if (role == null)
            {
                return View("Error", "Role not found!");
            }
            return View(role);
        }

        // POST: Roles/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Result result = _roleService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
