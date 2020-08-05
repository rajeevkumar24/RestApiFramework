using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiDemo
{
    public partial class UserDTOResponse
    {
            public long page { get; set; }
            public long perPage { get; set; }
            public long total { get; set; }
            public long total_Pages { get; set; }
            public List<Data> data { get; set; }
           
        }
    
        public partial class Data
        {
            public long id { get; set; }
            public string email { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public Uri avatar { get; set; }
        }
    
}

