using Azure;
using Domain.Dtos;
using Domain.Models;
using Infrostruckture.Service;
using Microsoft.AspNetCore.Mvc;

namespace MigratorDb.Controllers;
[ApiController]
[Route("[controller]")]
public class LibraryController(ILibraryService service): ControllerBase
{
    [HttpPost("/CreateAuthor")]
    public async Task<Infrostruckture.Response.Response<bool>> CreateAuthor(Author author)
    {
        return await service.CreateAuthor(author);
    }
    [HttpPost("/CreateBook")]
    public async  Task<Infrostruckture.Response.Response<bool>> CreateBook(Book book)
    {
        return await service.CreateBook(book);
    }
    [HttpGet("/GetBookWithAuthor")]
    public async Task<Infrostruckture.Response.Response<List<BookWithAuthor>>> GetBookWithAuthor()
    {
        return await service.GetBookWithAuthor();
    }
    [HttpGet("/GetBooksByAuthorId")]
    public async Task<Infrostruckture.Response.Response<List<Book>>> GetBooksByAuthorId(int authorId)
    {
        return await service.GetBooksByAuthorId(authorId);
    }
   [HttpPut]
    public async Task<Infrostruckture.Response.Response<bool>> UpdateIsAvailable(int id, bool isAvailable)
    {
        return await service.UpdateIsAvailable(id,isAvailable);
    }
    [HttpDelete]
    public async Task<Infrostruckture.Response.Response<bool>> DeleteBook(int id)
    {
        return await service.DeleteBook(id);
    }
}