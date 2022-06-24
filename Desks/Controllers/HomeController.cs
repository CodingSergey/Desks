using Desks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Desks.Controllers
{
    public class HomeController : Controller
    { 
        private readonly DBContext _context;

        public HomeController(DBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult Employee()
        {
            return View();
        }
        public IActionResult Add_Location()
        {
            return View();
        }
        public IActionResult Add_Desk()
        {
            return View();
        }
        public IActionResult Remove_Location()
        {
            return View();
        }
        public IActionResult Remove_Desk()
        {
            return View();
        }
        public IActionResult Make_Unavailable()
        {
            return View();
        }
        public IActionResult Book()
        {
            return View();
        }
        public IActionResult Reserve()
        {
            return View();
        }
        public IActionResult Filter()
        {
            return View();
        }
        public IActionResult Change()
        {
            return View();
        }
        [HttpPost]
        public void Login()
        {
            String uname = Request.Form["Username"];
            String psswrd = Request.Form["Password"];
            try
            {
                Account account = _context.accounts.Where(a => a.Username == uname && a.Password == psswrd).Single();
                HttpContext.Session.SetString("Username", account.Username);
                if(account.Admin == true)
                {
                    HttpContext.Session.SetInt32("Admin", 1);
                    HttpContext.Response.Redirect("Admin");
                } else
                {
                    HttpContext.Session.SetInt32("Admin", 0);
                    HttpContext.Response.Redirect("Employee");
                }
            }
            catch (InvalidOperationException e)
            {
                HttpContext.Session.SetInt32("Wrong", 1);
                HttpContext.Response.Redirect("Index");
            }
            
        }
        [HttpPost]
        public void add_Desk()
        {
            String l_name = Request.Form["location_ID"];
            int l_ID;
            l_ID = _context.locations.Where(a => a.location_name == l_name).Single().ID;
            _context.locations.Where(a => a.location_name == l_name).Single().n_Desks++;
            Desk desk = new Desk();
            desk.booked = false;
            desk.location_ID = l_ID;
            desk.owner_ID = 0;
            _context.desks.Add(desk);
            _context.SaveChanges();
            HttpContext.Response.Redirect("Admin");
        }
        [HttpPost]
        public void add_Location()
        {
            String name = Request.Form["location_name"];
            Location l = new Location();
            l.location_name = name;
            l.n_Desks = 0;
            _context.locations.Add(l);
            _context.SaveChanges();
            HttpContext.Response.Redirect("Admin");
        }
        [HttpPost]
        public void remove_Desk()
        {
            String id = Request.Form["ID"];
            Desk d = _context.desks.Where(a => a.ID.ToString() == id).Single();
            _context.desks.Remove(d);
            _context.SaveChanges();
            HttpContext.Response.Redirect("Admin");
        }
        [HttpPost]
        public void remove_Location()
        {
            String location_name = Request.Form["location_name"];
            Location l = _context.locations.Where(a => a.location_name == location_name).Single();
            _context.locations.Remove(l);
            _context.SaveChanges();
            HttpContext.Response.Redirect("Admin");
        }
        [HttpPost]
        public void make_Unavailable()
        {
            String id = Request.Form["ID"];
            Desk d = _context.desks.Where(a => a.ID.ToString() == id).Single();
            d.booked = true;
            d.bookedUntil = DateTime.Today;
            _context.desks.Update(d);
            _context.SaveChanges();
            HttpContext.Response.Redirect("Admin");

        }
        [HttpPost]
        public void book_Desk()
        {
            String id = Request.Form["ID"];
            Desk d = _context.desks.Where(a => a.ID.ToString() == id).Single();
            d.booked = true;
            d.bookedUntil = DateTime.Today;
            Account acc = _context.accounts.Where(a => a.Username == HttpContext.Session.GetString("Username")).Single();
            acc.desk_Reserved = true;
            acc.desk_ID = d.ID;
            d.owner_ID = acc.ID;
            _context.desks.Update(d);
            _context.accounts.Update(acc);
            _context.SaveChanges();
            HttpContext.Response.Redirect("Employee");

        }
        [HttpPost]
        public void reserve_Desk()
        {
            String days = Request.Form["days"];
            String id = Request.Form["ID"];
            Desk d = _context.desks.Where(a => a.ID.ToString() == id).Single();
            Account acc = _context.accounts.Where(a => a.Username == HttpContext.Session.GetString("Username")).Single();
            d.booked = true;
            d.bookedUntil = DateTime.Today.AddDays(Int32.Parse(days));
            d.owner_ID = acc.ID;
            acc.desk_Reserved = true;
            acc.desk_ID = d.ID;
            _context.desks.Update(d);
            _context.accounts.Update(acc);
            _context.SaveChanges();
            HttpContext.Response.Redirect("Employee");
        }
        [HttpPost]
        public void change_Desk()
        {
            String id = Request.Form["ID"];
            Desk d = _context.desks.Where(a => a.ID.ToString() == id).Single();
            Account user = _context.accounts.Where(a => a.Username == HttpContext.Session.GetString("Username")).Single();
            Desk cur = _context.desks.Where(a => a.ID == user.desk_ID).Single();
            d.booked = true;
            d.bookedUntil = cur.bookedUntil;
            d.owner_ID = cur.owner_ID;
            user.desk_ID = d.ID;
            cur.booked = false;
            cur.bookedUntil = DateTime.MinValue;
            cur.owner_ID = 0;
            _context.desks.Update(cur);
            _context.desks.Update(d);
            _context.accounts.Update(user);
            _context.SaveChanges();
         
            HttpContext.Response.Redirect("Employee");
        }
        [HttpPost]
        public void filter_Desks()
        {
            String id = Request.Form["ID"];
            Location l = _context.locations.Where(a => a.ID.ToString() == id).Single();
            HttpContext.Session.SetString("Location", l.location_name);
            HttpContext.Response.Redirect("Employee");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
