using System.Collections.Generic;

namespace RestWithASPNETFive.Hypermedia.Abstract
{
    public interface ISupportsHypermedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
