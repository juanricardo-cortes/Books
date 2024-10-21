using Books.Application.Abstraction;
using Books.Domain.Entities;
using Books.Domain.QueryResponses;
using MediatR;

namespace Books.Application.Features.Books.Queries;

public record class GetBookByIdQuery(int Id) : IRequest<GetBookByIdQueryResponse>;

public class GetBooksByIdQueryHandler : IRequestHandler<GetBookByIdQuery, GetBookByIdQueryResponse>
{
    private readonly IBooksRepository booksRepository;

    public GetBooksByIdQueryHandler(IBooksRepository booksRepository)
    {
        this.booksRepository = booksRepository;
    }

    public Task<GetBookByIdQueryResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        Book? book = this.booksRepository.GetBook(request.Id);

        return Task.FromResult(new GetBookByIdQueryResponse(book));
    }
}