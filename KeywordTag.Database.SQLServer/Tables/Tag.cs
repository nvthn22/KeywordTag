using System.ComponentModel.DataAnnotations;

namespace KeywordTag.Database.SQLServer.Tables
{
    public class Tag
    {
        [Key]
        public Guid code {  get; set; }
        public Guid code_keyword { get; set; }
        public int code_message { get; set; }
        public DateTime tagtime { get; set; }
    }
}
