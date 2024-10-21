using Books.Application.Features.Books.Commands;
using Books.Application.Features.Books.Queries;
using Books.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IMediator mediator;

    public BookController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Book>>> Get()
    {
        GetBooksQuery query = new();
        var result = await mediator.Send(query);
        return Ok(result.Books);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Book>> Get(int id)
    {
        GetBookByIdQuery query = new(id);
        var result = await this.mediator.Send(query);

        if (result.Book is null)
        {
            return NotFound(result.Book);
        }

        return Ok(result.Book);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<Book>> Post([FromBody] Book book)
    {
        CreateBookCommand command = new(book);
        var result = await mediator.Send(command);

        if (result.Book is null)
        {
            return Conflict(result.Book);
        }

        return CreatedAtAction(nameof(Get), new { id = book.Id }, result.Book);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Book>> Put(int id, [FromBody] Book book)
    {
        if ((book is not null && book.Id != id) || book is null)
        {
            return BadRequest("Invalid request");
        }

        UpdateBookCommand command = new(book);
        var result = await this.mediator.Send(command);

        if (result.Book is null)
        {
            return NotFound(result.Book);
        }

        return Ok(result.Book);
    }
}
