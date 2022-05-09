using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<Employee> employees = new List<Employee>()
            {
                new Employee(){
                    Id= 1,
                    Name= "Minh",
                     Age= 21,
                     Avatar="https://picsum.photos/200/300",
                     Description="abc"
                },
                 new Employee(){
                    Id= 2,
                    Name= "Minh1",
                     Age= 21,
                     Avatar="https://picsum.photos/200/300",
                     Description="abc"
                },
                  new Employee(){
                    Id= 3,
                    Name= "Minh2",
                     Age= 21,
                     Avatar="https://picsum.photos/200/300",
                     Description="abc"
                }
            };
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
         
            return View(employees);
        }
        public IActionResult SubmitEdit(Employee e)
        {
            foreach(var item in employees)
            {
                if(item.Id == e.Id)
                {
                    item.Name = e.Name;
                    item.Age = e.Age;   
                    item.Avatar = e.Avatar;
                    item.Description = e.Description;   

                }
            }
            return View("~/Views/Home/Index.cshtml",  employees);
        }
        public IActionResult Search(string key)
        {
            var result = new List<Employee>();
            foreach(var item in employees)
            {
                if (item.Name.ToLower().Contains(key.ToLower()))
                {
                    result.Add(item);
                }
            }
            return View("~/Views/Home/Index.cshtml", result);
        }
        public IActionResult Delete(int id)
        {
            var employee = employees.Find(x => x.Id == id);
            employees.Remove(employee);
            return View("~/Views/Home/Index.cshtml", employees);
        }
        public IActionResult Edit(int id)
        {
            var employee = employees.Find(x => x.Id == id);
            return View(employee);
        }
        public IActionResult Create(Employee e)
        {
            employees.Add(e);
            return View("~/Views/Home/Index.cshtml", employees);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
