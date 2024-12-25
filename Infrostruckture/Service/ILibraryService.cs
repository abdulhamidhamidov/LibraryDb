using Domain.Dtos;
using Domain.Models;
using Infrostruckture.Response;

namespace Infrostruckture.Service;

public interface ILibraryService
{
    
    public Task<Response<bool>> CreateAuthor(Author author);
    public Task<Response<bool>> CreateBook(Book book);
    public Task<Response<List<BookWithAuthor>>> GetBookWithAuthor();
    public Task<Response<List<Book>>> GetBooksByAuthorId(int authorId);
    public Task<Response<bool>> UpdateIsAvailable(int id,bool isAvailable);
    public Task<Response<bool>> DeleteBook(int id);
}