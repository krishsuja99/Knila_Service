using System.ComponentModel.DataAnnotations;

namespace Knila_Service.Domain.Request
{
    public class AddBookDetailsRequest
    {        
        public long BookId { get; set; }
        [Required(ErrorMessage = "Please enter Publisher")]
        public string Publisher { get; set; }
        [Required(ErrorMessage = "Please enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter AuthorFirstName")]
        public string AuthorFirstName { get; set; }
        [Required(ErrorMessage = "Please enter AuthorLastName")]
        public string AuthorLastName { get; set; }
        [Required(ErrorMessage = "Please enter VolumeNumber")]
        public int VolumeNumber { get; set; }
        [Required(ErrorMessage = "Please select PublicationDate")]
        public string PublicationDate { get; set; }
        [Required(ErrorMessage = "Please enter PageRange")]
        public string PageRange { get; set; }
        [Required(ErrorMessage = "Please enter Url")]
        public string Url { get; set; }
        [Required(ErrorMessage = "Please enter Price")]
        public decimal Price { get; set; }
    }
}
