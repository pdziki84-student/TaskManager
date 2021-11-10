using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private static IList<TaskModel> tasks = new List<TaskModel>()
        {
            new TaskModel() {TaskId = 1, Name = "Wizyta u lekarza", Description = "Godzina 17:00", Done = false},
            new TaskModel() {TaskId = 2, Name = "Zrobic obiad", Description = "Pierogi", Done = false}

        };
        // GET: HomeController
        public ActionResult Index()
        {
            return View(tasks.Where(x => !x.Done));
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskId  == id));
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View(new TaskModel());
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel taskModel)
        {
            taskModel.TaskId = tasks.Count + 1;
            tasks.Add(taskModel);
            return RedirectToAction(nameof(Index));

        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskId == id));
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskModel)
        {
            TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
            task.Name = taskModel.Name;
            task.Description = taskModel.Description;

            return RedirectToAction(nameof(Index));
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskId == id));
        }

        // POST: TAsk/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {
            TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
            tasks.Remove(task);
            return RedirectToAction(nameof(Index));

        }
        //GET: Task/Done
        public ActionResult Done(int id)
        {
            TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
            task.Done = true;

            return RedirectToAction(nameof(Index));
        }
    }
}
