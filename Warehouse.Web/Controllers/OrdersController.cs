using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Warehouse.Business;
using Warehouse.Entities;
using Warehouse.Web.Models;

namespace Warehouse.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly WarehouseService _service;

        public OrdersController(WarehouseService warehouseService)
        {
            _service = warehouseService;
        }
		
        public IActionResult Index()
        {
            return View(_service.GetUnProcessedOrders());
        }

		public IActionResult ProcessOrder(int orderId)
		{
			Order order = _service.GetOrderByid(orderId);
			if (order == null)
			{
				return NotFound();
			}
			_service.ProcessOrder(orderId);
			return View(order);
		}
		
        public IActionResult Details(int orderId)
        {
			Order order = _service.GetOrderByid(orderId);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
		
        public IActionResult Create()
        {
            return View();
        }
		
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Processed,ProductId")] Order order)
        {
            if (ModelState.IsValid)
            {
				Order newOrder = _service.CreateOrder(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }
		
        public IActionResult Edit(int orderId)
        {
			Order order = _service.GetOrderByid(orderId);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
		
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Processed,ProductId")] Order order)
        {
			_service.UpdateOrder(order);
            return View(order);
        }
    }
}
