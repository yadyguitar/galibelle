using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace galibelle.Controllers
{
    public class TodoListController : Controller
    {
        // GET: TodoList
        public ActionResult TodoList()
        {
            return View();
        }

    }
}
