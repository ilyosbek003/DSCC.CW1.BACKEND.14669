using DSCC.CW1.BACKEND._14669.DBContexts;
using DSCC.CW1.BACKEND._14669.Model;
using Microsoft.EntityFrameworkCore;

namespace DSCC.CW1.BACKEND._14669.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _dbContext;
        public BookRepository(BookContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteBook(int BookId)
        {
            var Book = _dbContext.Books.Find(BookId);
            _dbContext.Books.Remove(Book);
            Save();
        }
        public Book GetBookById(int BookId)
        {
            var prod = _dbContext.Books.Find(BookId);
            _dbContext.Entry(prod).Reference(s => s.Category).Load();
            return prod;
        }
        public IEnumerable<Book> GetBooks()
        {
            return _dbContext.Books.Include(s => s.Category).ToList();
        }
        public void InsertBook(Book Book)
        {
            _dbContext.Add(Book);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void UpdateBook(Book Book)
        {
            _dbContext.Entry(Book).State =
            Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
