﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
	public class HomeController : Controller
	{
		// GET: HomeController
		public ActionResult Index()
		{
			return View("Home");
		}
	}
}
