using System.ComponentModel.DataAnnotations;

namespace KeywordTag.Database.SQLServer.Tables
{
    public class Device
    {
        [Key]
        public string email { get; set; }
        public int email_pin { get; set; }
        public Guid code { get; set; }
        public string list_keyword { get; set; }
        public string list_keyword_tagged { get; set; }
    }
}
