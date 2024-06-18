using System.Collections.Generic;

namespace Popcorn.Models.ReponseDto
{
    public class Response
    {
        public List<Group> groups { get; set; }
        public int total { get; set; }
    }
}
