using Knila_Service.Domain.Request;
using Knila_Service.InfraStructure.Interface;
using Knila_Service.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using static Knila_Service.InfraStructure.DependencyInjectionInfra;

namespace Knila_Service.Controllers
{
    [Route("api/Booking")]
    public class BookController : ControllerBase
    {
        readonly IBook _book;
        public BookController(IBook book)
        {
            _book = book;
        }

        [HttpPost("Add-Book-Details")]
        public async Task<Result<bool>> AddBookDetails(AddBookDetailsRequest request, CancellationToken cancellationToken)
        {
            return await _book.AddBookDetails(request, cancellationToken);
        }

        [HttpPost("Get-Book-Details")]
        public async Task<Result<List<Book>>> GetBookDetails(CancellationToken cancellationToken)
        {
            return await _book.GetBookDetails(cancellationToken);
        }

        [HttpPost("Get-Book-Details-Sort")]
        public async Task<Result<List<Book>>> GetBookDetailsSort(CancellationToken cancellationToken)
        {
            return await _book.GetBookDetailsSort(cancellationToken);
        }

        [HttpPost("Total-Price-Book")]
        public async Task<Result<int>> TotalBookPrice(CancellationToken cancellationToken)
        {
            return await _book.TotalBookPrice(cancellationToken);
        }

        [HttpPost("Show-Book-Details")]
        public async Task<Result<Book>> ShowBookDetails(BookTotalPriceRequest request, CancellationToken cancellationToken)
        {
            return await _book.ShowBookDetails(request,cancellationToken);
        }
    }
}
