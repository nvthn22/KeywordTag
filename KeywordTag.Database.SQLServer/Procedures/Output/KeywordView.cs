using System.ComponentModel.DataAnnotations;

namespace KeywordTag.Database.SQLServer.Procedures.Output
{
    public class KeywordView
    {
        public Guid code { get; set; }
        public string name { get; set; }
        public int online { get; set; }
    }
}
