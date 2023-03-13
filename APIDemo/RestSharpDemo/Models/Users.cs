using System.Collections.Generic;

namespace RestSharpDemo.Models
{
    public class Users
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<UserData> data { get; set; }
    } 
}
