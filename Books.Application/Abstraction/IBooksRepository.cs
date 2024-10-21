using Books.Domain.Entities;

namespace Books.Application.Abstraction;

public interface IBooksRepository
{
    IEnumerable<Book> GetBooks();

    Book? GetBook(int id);

    Book? CreateBook(Book book);

    Book? UpdateBook(Book book);
}
