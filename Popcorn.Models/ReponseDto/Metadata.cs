using System;

namespace Popcorn.Models.ReponseDto
{
    public class Metadata
    {
        public string id { get; set; }
        public bool @private { get; set; }
        public DateTime createdAt { get; set; }
        public string collectionId { get; set; }
        public string name { get; set; }
    }
}
