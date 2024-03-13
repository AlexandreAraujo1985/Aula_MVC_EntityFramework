using Aula_MVC_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aula_MVC_EntityFramework.Contrllers
{
	public class ProdutoController : Controller
	{
		private List<Produto> ListarProdutos()
		{
			return new List<Produto>
			{
				new Produto { Id = 1, Nome = "Caneta", Preco = 2 },
				new Produto { Id = 2, Nome = "Lápis", Preco = 1 },
				new Produto { Id = 3, Nome = "Caderno", Preco = 10 }
			};
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View(ListarProdutos());
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Details(int id)
		{
			var produto = ListarProdutos().Find(x => x.Id == id);

			return View(produto);
		}

		[HttpPost]
		public IActionResult Create(Produto produto)
		{
			if (ModelState.IsValid)
			{
				var produtos = ListarProdutos();

				produto.Id = 4;
				produtos.Add(produto);

				return View("Index", produtos);
			}
			return View();
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var produto = ListarProdutos().Find(x => x.Id == id);

			return View(produto);
		}


		//[HttpPost]
		//public IActionResult Edit(TruckViewModel truckViewModel)
		//{
		//	try
		//	{
		//		if (ModelState.IsValid)
		//		{
		//			var truck = _mapper.Map<Truck>(truckViewModel);
		//			_truckApplication.Update(truck);
		//			return RedirectToAction("Index");
		//		}

		//		ViewBag.Message = "Invalid edit truck";
		//		return View();
		//	}
		//	catch (System.Exception)
		//	{
		//		ViewBag.Message = "Error edit truck";
		//		return View();
		//	}
		//}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var produto = ListarProdutos().Find(x => x.Id == id);

			return View(produto);
		}

		//[HttpPost]
		//public IActionResult Delete(TruckViewModel truckViewModel)
		//{
		//	try
		//	{
		//		if (ModelState.IsValid)
		//		{
		//			var truck = _mapper.Map<Truck>(truckViewModel);
		//			_truckApplication.Delete(truck);
		//			return RedirectToAction("Index");
		//		}

		//		ViewBag.Message = "Invalid delete truck";
		//		return View();
		//	}
		//	catch (System.Exception)
		//	{
		//		ViewBag.Message = "Error delete truck";
		//		return View();
		//	}
		//}
	}
}
