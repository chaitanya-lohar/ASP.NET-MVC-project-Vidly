using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        // ViewResult :- it only return view
        // ActionResult:- it can return anything
        public ActionResult Random()
        {
            var movie = new Movie() { Id = 101, Name = "Dark Night!" };

            var customers = new List<Customer> {
                new Customer(){Id=101,Name="Sam",City="Bali" },
                new Customer(){Id=102,Name="yen",City="Norway" },
                new Customer(){Id=103,Name="suzen",City="Sidney" },
                new Customer(){Id=104,Name="denil",City="Jorjia" },
            };

            var viewModel = new RandomMovieViewModel() {
                   Movie=movie,
                   Customers=customers
            };

            return View(viewModel); 
            
            // this is helper method
            //return HttpNotFound();
            //ViewData["Movies"] = movie;
            //ViewBag.Movies = movie;
             //return Content("Hello world!");
            // return RedirectToAction("index", "home",new {page=1,sortby="name"});

        }

        public ActionResult Edit(int id) {

            return Content("Id is " + id);
        }

        // optional parameter
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue) {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy)) {
                sortBy = "name";
            }

            return Content($"Page Index {pageIndex} & sortBy {sortBy}");
        }

        //this is called attribute routing
        [Route("movies/released/{year:min(2020):max(2022)}/{month:regex(\\d{2}):range(1,12)}")] //min,max,minlength,maxlength,int ,float,guid
        public ActionResult ByReleasedDate(int? year,int? month) {
           
            return Content($"released year={year}  released month={month}");
        }

        
    }
}