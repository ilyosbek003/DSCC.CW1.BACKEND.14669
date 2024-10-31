using DSCC.CW1.BACKEND._14669.Model;
using DSCC.CW1.BACKEND._14669.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;


namespace DSCC.CW1.BACKEND._14669.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _BookRepository;
        public BookController(IBookRepository BookRepository)
        {
            _BookRepository = BookRepository;
        }


        // GET: api/Book
        [HttpGet]
        public IActionResult Get()
        {
            var Books = _BookRepository.GetBooks();
            return new OkObjectResult(Books);
        }


        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var Book = _BookRepository.GetBookById(id);
            if (Book != null)
            {
                return new OkObjectResult(Book);
            }
            return new NoContentResult();
        }

        // POST: api/Book
        [HttpPost]
        public IActionResult Post([FromBody] Book Book)
        {
            using (var scope = new TransactionScope())
            {
                _BookRepository.InsertBook(Book);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = Book.Id }, Book);
            }
        }
        // PUT: api/Book/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book Book)
        {
            if (Book != null)
            {
                using (var scope = new TransactionScope())
                {
                    _BookRepository.UpdateBook(Book);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _BookRepository.DeleteBook(id);
            return new OkResult();
        }

    }
}
