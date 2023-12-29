using Knila_Service.Domain.Request;
using Knila_Service.InfraStructure.Interface;
using Knila_Service.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static Knila_Service.InfraStructure.DependencyInjectionInfra;

namespace Knila_Service.InfraStructure.Implementation
{
    public class BookImplementation : IBook
    {
        readonly MyTestDBContext _dbContext;
        public BookImplementation(MyTestDBContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public async Task<Result<bool>> AddBookDetails(AddBookDetailsRequest request, CancellationToken cancellationToken)
        {
            Result<bool> result = new();
            if (request.BookId > 0)
            {
                var BookValue = await _dbContext.Books.FirstOrDefaultAsync(x => x.BookId == request.BookId);
                if (BookValue != null)
                {
                    BookValue.Publisher = request.Publisher;
                    BookValue.Title = request.Title;
                    BookValue.AuthorFirstName = request.AuthorFirstName;
                    BookValue.AuthorLastName = request.AuthorLastName;
                    BookValue.VolumeNumber = request.VolumeNumber;
                    BookValue.PublicationDate = Convert.ToDateTime(request.PublicationDate);
                    BookValue.PageRange = request.PageRange;
                    BookValue.Price = request.Price;
                    BookValue.Url = request.Url;
                }
            }
            else
            {
                Book BookValue = new();
                BookValue.Publisher = request.Publisher;
                BookValue.Title = request.Title;
                BookValue.AuthorFirstName = request.AuthorFirstName;
                BookValue.AuthorLastName = request.AuthorLastName;
                BookValue.VolumeNumber = request.VolumeNumber;
                BookValue.PublicationDate = Convert.ToDateTime(request.PublicationDate);
                BookValue.PageRange = request.PageRange;
                BookValue.Price = request.Price;
                BookValue.Url = request.Url;
                await _dbContext.Books.AddRangeAsync(BookValue);
            }
            int res = await _dbContext.SaveChangesAsync(cancellationToken);
            result.Message = result.Data ? "Sucess" : "Failed";
            result.StatusCode = result.Data ? StatusCodes.Status200OK : StatusCodes.Status404NotFound;
            return result;
        }

        public async Task<Result<List<Book>>> GetBookDetails(CancellationToken cancellationToken)
        {
            Result<List<Book>> result = new();
            result.Data = await _dbContext.Books.Select(s => s).OrderBy(o => o.Publisher).ThenBy(t=>t.AuthorFirstName).ThenBy(t=>t.AuthorLastName).ThenBy(t=>t.Title).ToListAsync(cancellationToken);

            result.Message = result.Data.Count > 0 ? "Sucess" : "Failed";
            result.StatusCode = result.Data.Count > 0 ? StatusCodes.Status200OK : StatusCodes.Status404NotFound;
            return result;
        }

        public async Task<Result<List<Book>>> GetBookDetailsSort(CancellationToken cancellationToken)
        {
            Result<List<Book>> result = new();

            result.Data = await _dbContext.Books.Select(s => s).OrderBy(o => o.AuthorFirstName).ThenBy(t=>t.AuthorLastName).ThenBy(t=>t.Title).ToListAsync(cancellationToken);
            result.Message = result.Data.Count > 0 ? "Sucess" : "Failed";
            result.StatusCode = result.Data.Count > 0 ? StatusCodes.Status200OK : StatusCodes.Status404NotFound;
            return result;
        }

        public async Task<Result<int>> TotalBookPrice(CancellationToken cancellationToken)
        {
            Result<int> result = new();
            var BookDetails = await _dbContext.Books.Select(s=>s.Price).ToListAsync(cancellationToken);

            result.Data = Convert.ToInt32(BookDetails.Sum(s=>s));
            result.Message = result.Data > 0 ? "Sucess" : "Failed";
            result.StatusCode = result.Data > 0 ? StatusCodes.Status200OK : StatusCodes.Status404NotFound;
            return result;
        }

        public async Task<Result<Book>> ShowBookDetails(BookTotalPriceRequest request, CancellationToken cancellationToken)
        {
            Result<Book> result = new();
            result.Data = await _dbContext.Books.FirstOrDefaultAsync(x=>x.BookId == Convert.ToInt64(request.BookId));

            result.Message = result.Data != null ? "Sucess" : "Failed";
            result.StatusCode = result.Data != null ? StatusCodes.Status200OK : StatusCodes.Status404NotFound;
            return result;
        }
    }
}
