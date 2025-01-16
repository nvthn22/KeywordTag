using System.ComponentModel.DataAnnotations;

namespace KeywordTag.Database.SQLServer.Tables
{
    public class Keyword
    {
        [Key]
        public Guid code { get; set; }
        public string name { get; set; }
        public bool confirm { get; set; }
    }
}
