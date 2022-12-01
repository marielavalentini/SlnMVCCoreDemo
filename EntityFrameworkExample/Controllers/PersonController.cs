using EntityFrameworkExample.Data;
using EntityFrameworkExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkExample.Controllers
{
    public class PersonController : Controller
    {
        //inyeccion de dependencia

        private readonly PersonContext _context;

        public PersonController(PersonContext context)
        {
            _context = context;
        }

        //GET: /person o /person/index

        public IActionResult Index()
        {
            return View(_context.People.ToList());
        }

        [HttpGet("/person/ListaPorCiudad/{city}")]
        // GET: /person/ListaPorCiudad/baas
        public IActionResult ListaPorCiudad(string city)
        {
            List<Person> lista = (from p in _context.People
                                  where p.City == city
                                  select p).ToList();
            return View("Index", lista);
        }

        //GET: /person/edit/id

        public IActionResult Edit(int id)
        {
            var person = _context.People.SingleOrDefault(m => m.PersonId == id);
            person.FirstName = "Brandon";
            _context.Update(person);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //GET: /person/create
        public IActionResult Create()
        {
            Person person = new Person();
            return View("Create", person);
        }
        // POST: /Person/Create
        [HttpPost]
        public IActionResult Create(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //GET: person/delete/1

        public IActionResult Delete(int id)
        {
            var person = _context.People.SingleOrDefault(m => m.PersonId == id);
            _context.People.Remove(person);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

