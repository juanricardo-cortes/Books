using Books.Application.Abstraction;
using Books.Domain.Entities;

namespace Books.Infrastructure.Repositories;

public class BooksRepository : IBooksRepository
{
    private static List<Book> Books = new List<Book>
    {
        new Book { Id = 1, Title = "C# in Depth", Author = "Jon Skeet", Isbn = "9781617294532", PublishedDate = new DateTime(2019, 4, 1) },
        new Book { Id = 2, Title = "Clean Code", Author = "Robert C. Martin", Isbn = "9780132350884", PublishedDate = new DateTime(2008, 8, 1) }
    };

    public Book? CreateBook(Book book)
    {
        if(Books.Any(b => b.Id == book.Id))
        {
            return null;
        }

        Books.Add(book);
        return book;
    }

    public Book? GetBook(int id)
    {
        Book? book = Books.Find(b => b.Id == id);
        return book;
    }

    public IEnumerable<Book> GetBooks()
    {
        return Books;
    }

    public Book? UpdateBook(Book book)
    {
        Book? existingBook = Books.Find(b => b.Id == book.Id);

        if (existingBook is null)
        {
            return null;
        }

        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        existingBook.Isbn = book.Isbn;
        existingBook.PublishedDate = book.PublishedDate;

        return existingBook;
    }
}
