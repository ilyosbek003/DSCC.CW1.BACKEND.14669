using DSCC.CW1.BACKEND._14669.Model;
using Microsoft.EntityFrameworkCore;

namespace DSCC.CW1.BACKEND._14669.DBContexts
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
