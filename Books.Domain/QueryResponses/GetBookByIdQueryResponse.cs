using Books.Domain.Entities;

namespace Books.Domain.QueryResponses;

public record class GetBookByIdQueryResponse(Book? Book);
