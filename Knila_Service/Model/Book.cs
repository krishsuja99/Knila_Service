using System;
using System.Collections.Generic;

namespace Knila_Service.Model
{
    public partial class Book
    {
        public long BookId { get; set; }
        public string? Publisher { get; set; }
        public string? Title { get; set; }
        public string? AuthorFirstName { get; set; }
        public string? AuthorLastName { get; set; }
        public int? VolumeNumber { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string? PageRange { get; set; }
        public string? Url { get; set; }
        public decimal? Price { get; set; }
    }
}
