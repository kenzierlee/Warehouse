using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.Entities;

namespace Warehouse.Data
{
	class FakeDb
	{
		public static int NextId = 9;
		public static List<Order> Orders = new List<Order>()
		{
			new Order()
			{
				Id = 1,
				Title = "CodeWorks Shirt",
				Processed = false,
				ProductId = 1
			},
			new Order()
			{
				Id = 2,
				Title = "CodeWorks Sweatshirt",
				Processed = true,
				ProductId = 2
			},
			new Order()
			{
				Id = 3,
				Title = "CodeWorks Water Bottle",
				Processed = false,
				ProductId = 2
			},
			new Order()
			{
				Id = 4,
				Title = "CodeWorks Pen",
				Processed = false,
				ProductId = 1
			},
			new Order()
			{
				Id = 5,
				Title = "CodeWorks Sweatpants",
				Processed = false,
				ProductId = 3
			},
			new Order()
			{
				Id = 6,
				Title = "CodeWorks Windbreaker",
				Processed = false,
				ProductId = 3
			},
			new Order()
			{
				Id = 7,
				Title = "CodeWorks Binder",
				Processed = false,
				ProductId = 4
			},
			new Order()
			{
				Id = 8,
				Title = "CodeWorks Backpack",
				Processed = false,
				ProductId = 4
			}
		};
	}
}
