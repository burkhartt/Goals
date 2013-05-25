using System;
using System.Web.Mvc;
using Goals.Models;
using Goals.Repositories;

namespace Goals.Controllers {
    public abstract class CrudController<T> : Controller where T : Entity, new() {
        private readonly IRepository<T> repository;

        protected CrudController(IRepository<T> repository) {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Create() {
            return View(new T());
        }

        [HttpPost]
        public ActionResult Create(T @object) {
            repository.Create(@object);
            return RedirectToAction("Create");
        }

        [HttpGet]
        public ActionResult Listing() {
            return View(repository.GetAll());
        }

        [HttpGet]
        public ActionResult Update(Guid id) {
            return View(repository.Get(id));
        }

        [HttpPost]
        public ActionResult Update(T @object) {
            repository.Update(@object);
            return RedirectToAction("Update");
        }

        [HttpGet]
        public ActionResult Delete(Guid id) {
            repository.Delete(id);
            return RedirectToAction("Listing");
        }
    }
}