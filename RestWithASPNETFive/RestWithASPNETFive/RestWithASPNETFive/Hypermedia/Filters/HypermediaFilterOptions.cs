using RestWithASPNETFive.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RestWithASPNETFive.Hypermedia.Filters
{
    public class HypermediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
