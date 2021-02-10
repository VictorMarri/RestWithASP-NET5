using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETFive.Data.VO
{
    public class BookVO
    {
        public long Id { get; set; }
        public string Author { get; set; }
        
        public DateTime LaunchDate { get; set; }
        
        public float Price { get; set; }
        
        public string Title { get; set; }
    }
}
