using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        //https://localhost:44350/api/books
        [HttpGet]
        public ActionResult<List<Books>> Index() =>
            _bookRepository.Get();

        //https://localhost:44350/api/books/5fd22019084f17aa59eaf2cb
        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Books> Get(string id)
        {
            var book = _bookRepository.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpDelete]
        public IActionResult Delete(Books bookIn)
        {
            var book = _bookRepository.Get(bookIn.Id);

            if (book == null)
            {
                return NotFound();
            }

            _bookRepository.Remove(book.Id);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string bookId)
        {
            var book = _bookRepository.Get(bookId);

            if (book == null)
            {
                return NotFound();
            }

            _bookRepository.Remove(book.Id);

            return NoContent();
        }
    }
}
