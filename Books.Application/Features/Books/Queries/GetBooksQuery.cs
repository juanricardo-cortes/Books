using Books.Application.Abstraction;
using Books.Domain.QueryResponses;
using MediatR;

namespace Books.Application.Features.Books.Queries;

public record class GetBooksQuery() : IRequest<GetBooksQueryResponse>;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, GetBooksQueryResponse>
{
    private readonly IBooksRepository booksRepository; 

    public GetBooksQueryHandler(IBooksRepository booksRepository)
    {
        this.booksRepository = booksRepository;
    }

    public Task<GetBooksQueryResponse> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var result = this.booksRepository.GetBooks();
        return Task.FromResult(new GetBooksQueryResponse(result));
    }
}
