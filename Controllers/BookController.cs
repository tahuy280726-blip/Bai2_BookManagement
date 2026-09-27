using Bai2_BookManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bai2_BookManagement.Controllers;

public class BookController : Controller
{
    private static readonly List<Book> Books = new()
    {
        new Book { Id = 1, Name = "Clean Code", Price = 20 },
        new Book { Id = 2, Name = "ASP.NET MVC", Price = 15 },
        new Book { Id = 3, Name = "Design Pattern", Price = 25 }
    };

    public IActionResult Index()
    {
        return View(Books);
    }

    public IActionResult Detail(int id)
    {
        var book = Books.FirstOrDefault(x => x.Id == id);
        if (book == null) return NotFound();

        return View(book);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Book book)
    {
        book.Id = Books.Count == 0 ? 1 : Books.Max(x => x.Id) + 1;
        Books.Add(book);

        TempData["Success"] = "Thêm sách thành công!";
        return RedirectToAction(nameof(Index));
    }
}
