using System.Text;

namespace RestWithASPNETFive.Hypermedia
{
    public class HyperMediaLink
    {
        public string Rel { get; set; }
        private string href; //Vai ser manipulado somente internamente, portanto nao tem get; set;
        public string Href
        {
            get
            {
                object _lock = new object();
                lock (_lock)
                {
                    StringBuilder sb = new StringBuilder(href);
                    return sb.Replace("%2f", "/").ToString();
                }
            }
            set { href = value; }
        }

        public string Type { get; set; }
        public string Action { get; set; }
    }
}
