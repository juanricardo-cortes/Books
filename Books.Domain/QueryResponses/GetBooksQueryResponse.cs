using Books.Domain.Entities;

namespace Books.Domain.QueryResponses;

public record class GetBooksQueryResponse(IEnumerable<Book> Books);
