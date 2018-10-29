using System;
using System.Collections.Generic;
using System.Data;
using Warehouse.Entities;

namespace Warehouse.Data
{
	public interface IWarehouseRepo
	{
		Order GetOrderById(int orderId);
		Order ProcessOrder(int orderId);
		Order UpdateOrder(Order order);
		Order CreateOrder(Order order);
		List<Order> GetUnProcessedOrders();
		List<Order> GetOrdersByProductId(int productId);
	}

	public class WarehouseRepo : IWarehouseRepo
	{
		private readonly IDbConnection _db;

		public Order GetOrderById(int orderId)
		{
			return FakeDb.Orders.Find(order => order.Id == orderId);
		}

		public Order ProcessOrder(int orderId)
		{
			Order existingOrder = GetOrderById(orderId);
			if (existingOrder == null)
			{
				throw new Exception("Order not found");
			}
			existingOrder.Processed = true;
			return existingOrder;
		}

		public Order UpdateOrder(Order order)
		{
			Order existingOrder = GetOrderById(order.Id);
			if (existingOrder == null)
			{
				throw new Exception("Order not found");
			}
			existingOrder.Title = order.Title;
			existingOrder.Processed = order.Processed;
			return existingOrder;
		}

		public Order CreateOrder(Order order)
		{
			order.Id = FakeDb.NextId;
			FakeDb.NextId += 1;
			FakeDb.Orders.Add(order);
			return order;
		}

		public List<Order> GetUnProcessedOrders()
		{
			return FakeDb.Orders.FindAll(order => order.Processed == false);
		}

		public List<Order> GetOrdersByProductId(int productId)
		{
			return FakeDb.Orders.FindAll(order => order.ProductId == productId);
		}

		public WarehouseRepo(IDbConnection db)
		{
			_db = db;
		}
	}
}
