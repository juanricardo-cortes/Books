using Books.Application.Abstraction;
using Books.Domain.CommandResponses;
using Books.Domain.Entities;
using MediatR;

namespace Books.Application.Features.Books.Commands;

public record class UpdateBookCommand(Book Book) : IRequest<UpdateBookCommandResponse>;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, UpdateBookCommandResponse>
{
    private readonly IBooksRepository booksRepository;

    public UpdateBookCommandHandler(IBooksRepository booksRepository)
    {
        this.booksRepository = booksRepository;
    }

    public Task<UpdateBookCommandResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        Book? result = this.booksRepository.UpdateBook(request.Book);

        return Task.FromResult(new UpdateBookCommandResponse(result));
    }
}
