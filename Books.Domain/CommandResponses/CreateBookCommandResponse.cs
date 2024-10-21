using Books.Domain.Entities;

namespace Books.Domain.CommandResponses;

public record class CreateBookCommandResponse(Book? Book);
