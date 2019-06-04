using SuperheroCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperheroCreator.Controllers
{
    public class Superherocontroller : Controller
    {
        ApplicationDbContext context;
       

        public Superherocontroller() 
        {
            context = new ApplicationDbContext(); 
        }
        // GET: Superherocontroller
        public ActionResult Index()
        {
            //grab all superheroes in database and pass to view
            var allHeros = context.Superheroes.ToList();  
            return View(allHeros);
    }

        // GET: Superherocontroller/Details/5
        public ActionResult Details(int id)
        {
            var SuperheroView = context.Superheroes.Where(c => c.Id == id).Single();
            return View(SuperheroView); 
        }

        // GET: Superherocontroller/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero(); 
            return View(superhero);
        }

        // POST: Superherocontroller/Create
        [HttpPost]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                // TODO: Add insert logic here
                context.Superheroes.Add(superhero);
                context.SaveChanges();
                return RedirectToAction("Index"); 
            }
            catch
            {
                return View();
            }
        }

        // GET:
        public ActionResult Edit(int id)
        {
            Superhero superheroToUpdate = context.Superheroes.Where(s => s.Id == id).Single(); 
            return View(); 
        }

        // POST: 
        [HttpPost]
        public ActionResult Edit(int id, Superhero superhero) 
        {
            try
            {
                // TODO: Add update logic here
                Superhero superheroToUpdate = context.Superheroes.Where(s => s.Id == id).Single();
                superheroToUpdate.superheroName = superhero.superheroName;
                superheroToUpdate.alteregofirstName = superhero.alteregofirstName;
                superheroToUpdate.alteregolastName = superhero.alteregolastName;
                superheroToUpdate.primaryAbility = superhero.primaryAbility;
                superheroToUpdate.primaryAbility = superhero.secondaryAbility;
                superheroToUpdate.catchPhrase = superhero.catchPhrase;
                context.SaveChanges(); 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superherocontroller/Delete/5
        public ActionResult Delete(int id)
        {
            Superhero superheroToRemove = context.Superheroes.Where(s => s.Id == id).Single();
            return View(); 
        }

        // POST: Superherocontroller/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                // TODO: Add delete logic here
                Superhero superheroToRemove = context.Superheroes.Where(s => s.Id == id).Single();
                context.Superheroes.Remove(superheroToRemove); 
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
