using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoSamplesController : ControllerBase
    {
        private readonly BookService _bookService;

        public MongoSamplesController(BookService bookService)
        {
            _bookService = bookService;
        }

        //[HttpGet]
        //public ActionResult<List<Books>> Get() =>
        //    _bookService.Get();

        //[HttpGet("{id:length(24)}", Name = "GetBook")]
        //public ActionResult<Books> Get(string id)
        //{
        //    var book = _bookService.Get(id);

        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return book;
        //}

        //[HttpPost]
        //public ActionResult<Books> Create(Books book)
        //{
        //    _bookService.Create(book);

        //    return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
        //}

        [HttpPut]
        public IActionResult Update(Books bookIn)
        {
            var book = _bookService.Get(bookIn.Id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Update(bookIn.Id, bookIn);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(Books bookIn)
        {
            var book = _bookService.Get(bookIn.Id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Remove(book.Id);

            return NoContent();
        }
    }
}
