using DSCC.CW1.BACKEND._14669.Model;

namespace DSCC.CW1.BACKEND._14669.Repository
{
    public interface IBookRepository
    {
        void InsertBook(Book Book);
        void UpdateBook(Book Book);
        void DeleteBook(int BookId);
        Book GetBookById(int Id);
        IEnumerable<Book> GetBooks();
    }
}
