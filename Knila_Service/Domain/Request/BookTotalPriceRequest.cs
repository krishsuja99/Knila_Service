using System.ComponentModel.DataAnnotations;

namespace Knila_Service.Domain.Request
{
    public class BookTotalPriceRequest
    {
        [Required]
        public string BookId { get; set; }
    }
}
