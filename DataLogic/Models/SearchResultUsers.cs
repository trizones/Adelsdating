using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.Models
{
    public class SearchResultUsers
    {
        public string Nickname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }

    public class ListOfSearchResults 
    {
        public List<SearchResultUsers> SearchResult { get; set; }

       
    }
}
