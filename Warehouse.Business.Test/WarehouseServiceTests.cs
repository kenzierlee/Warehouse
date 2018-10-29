using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using Warehouse.Data;
using Warehouse.Entities;

namespace Warehouse.Business.Test
{
	[TestClass]
	public class WarehouseServiceTests
	{
		[TestMethod]
		public void UnresolvedFillOrdersCanBeRetrieved()
		{
			List<Order> testOrders = new List<Order>()
			{
				new Order
				{
					Id = 12,
					Title = "test order",
					Processed = false,
					ProductId = 1
				}
			};
			var mockWarehouseRepo = Substitute.For<IWarehouseRepo>();
			mockWarehouseRepo.GetUnProcessedOrders().Returns(testOrders);

		}

		[TestMethod]
		public void UnresolvedFillOrderCanBeProcessed()
		{
			Order order = new Order
			{
				Id = 11,
				Title = "Test Order",
				Processed = false,
				ProductId = 1
			};
			var mockWarehouseRepo = Substitute.For<IWarehouseRepo>();
			mockWarehouseRepo.ProcessOrder(order.Id).Returns(new Order
			{
				Id = 11,
				Title = "Test Order",
				Processed = true,
				ProductId = 1
			});
		}

		[TestMethod]
		public void ProcessedFillOrderCannotBeModified()
		{
			Order order = new Order
			{
				Id = 11,
				Title = "Test Order",
				Processed = true,
				ProductId = 1
			};
			
			var mockWarehouseRepo = Substitute.For<IWarehouseRepo>();
			var warehouseService = new WarehouseService(mockWarehouseRepo);
			try
			{
				Order expectedOrder = warehouseService.UpdateOrder(new Order
				{
					Id = 11,
					Title = "Updated Test Order",
					Processed = false,
					ProductId = 1
				});
			}
			catch (Exception ex)
			{
				Assert.AreEqual("Order is already processed and cannot be updated", ex.Message);
				return;
			}
			Assert.Fail("Order shouldn't have been able to update");
		}
	}
}
