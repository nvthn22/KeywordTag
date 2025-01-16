using System.ComponentModel.DataAnnotations;

namespace KeywordTag.Database.SQLServer.Tables
{
    public class Message
    {
        [Key]
        public int code {  get; set; }
        public string name { get; set; }
    }
}
