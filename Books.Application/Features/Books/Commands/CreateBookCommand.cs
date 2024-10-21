using Books.Application.Abstraction;
using Books.Domain.CommandResponses;
using Books.Domain.Entities;
using MediatR;

namespace Books.Application.Features.Books.Commands;

public record class CreateBookCommand(Book Book) : IRequest<CreateBookCommandResponse>;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreateBookCommandResponse>
{
    private readonly IBooksRepository booksRepository;

    public CreateBookCommandHandler(IBooksRepository booksRepository)
    {
        this.booksRepository = booksRepository;
    }

    public Task<CreateBookCommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        Book? result = this.booksRepository.CreateBook(request.Book);

        return Task.FromResult(new CreateBookCommandResponse(result));
    }
}