using System.Net;
using Dapper;
using Domain.Dtos;
using Domain.Models;
using Infrostruckture.Datacontext;
using Infrostruckture.Response;

namespace Infrostruckture.Service;

public class LibraryService(IDapperContext dapperContext): ILibraryService
{
    public async Task<Response<bool>> CreateAuthor(Author author)
    {
        using var connection = dapperContext.Connection();
        var sql = "insert into Authors(Name,Country)values (@Name,@Country)";
        var res = await connection.ExecuteAsync(sql,author);
        if (res != 0) return new Response<bool>(true);
        return new Response<bool>(HttpStatusCode.NotFound,"Not found");
    }
    public async Task<Response<bool>> CreateBook(Book book)
    {
        using var connection = dapperContext.Connection();
        var sql = "insert into Books(Title,AuthorId,PublishedYear,Genre,IsAvailable)values (@Title,@AuthorId,@PublishedYear,@Genre,@IsAvailable)";
        var res = await connection.ExecuteAsync(sql,book);
        if (res != 0) return new Response<bool>(true);
        return new Response<bool>(HttpStatusCode.NotFound,"Not found");
    }

    public async Task<Response<List<BookWithAuthor>>> GetBookWithAuthor()
    {
        using var connection = dapperContext.Connection();
        var sql = "select * from books as b join authors as a on b.AuthorId = a.id";
        var res = await connection.QueryAsync<BookWithAuthor>(sql);
        return new Response<List<BookWithAuthor>>(res.ToList());
    }

    public async Task<Response<List<Book>>> GetBooksByAuthorId(int authorId)
    {
        using var connection = dapperContext.Connection();
        var sql = "select * from Books where AuthorId=@AuthorId";
        var res = await connection.QueryAsync<Book>(sql,new {AuthorId=authorId});
        return new Response<List<Book>>(res.ToList());
    }

    public async Task<Response<bool>> UpdateIsAvailable(int id, bool isAvailable)
    {
        using var connection = dapperContext.Connection();
        var sql = "update Books set IsAvailable=@IsAvailable where Id=@Id";
        var res = await connection.ExecuteAsync(sql,new {Id=id});
        if (res != 0) return new Response<bool>(true);
        return new Response<bool>(HttpStatusCode.NotFound,"Not found");
    }

    public async Task<Response<bool>> DeleteBook(int id)
    {
        using var connection = dapperContext.Connection();
        var sql = "delete from Book where Id=@Id";
        var res = await connection.ExecuteAsync(sql,new {Id=id});
        if (res != 0) return new Response<bool>(true);
        return new Response<bool>(HttpStatusCode.NotFound,"Not found");
    }
}