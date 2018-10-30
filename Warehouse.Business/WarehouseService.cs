using System;
using System.Collections.Generic;
using Warehouse.Data;
using Warehouse.Entities;

namespace Warehouse.Business
{
	public class WarehouseService
	{
		private readonly IWarehouseRepo _repo;

		public WarehouseService(IWarehouseRepo repo)
		{
			_repo = repo;
		}

		public Order GetOrderByid(int orderId)
		{
			return _repo.GetOrderById(orderId);
		}

		public Order ProcessOrder(int orderId)
		{
			Order existingOrder = _repo.GetOrderById(orderId);
			if (existingOrder.Processed == true)
			{
				throw new Exception("Order is already processed.");
			}
			return _repo.ProcessOrder(orderId);
		}

		public Order UpdateOrder(Order order)
		{
			Order existingOrder = _repo.GetOrderById(order.Id);
			if (existingOrder == null)
			{
				throw new Exception("Action not available");
			}
			if (existingOrder.Processed == true)
			{
				throw new Exception("Action not available");
			}
			return _repo.UpdateOrder(order);
		}

		public Order CreateOrder(Order order)
		{
			return _repo.CreateOrder(order);
		}

		public List<Order> GetUnProcessedOrders()
		{
			return _repo.GetUnProcessedOrders();
		}

		public List<Order> GetOrdersByProductId(int productId)
		{
			return _repo.GetOrdersByProductId(productId);
		}
	}
}
