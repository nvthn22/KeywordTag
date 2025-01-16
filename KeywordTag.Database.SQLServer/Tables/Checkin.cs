using System.ComponentModel.DataAnnotations;

namespace KeywordTag.Database.SQLServer.Tables
{
    public class Checkin
    {
        [Key]
        public Guid code { get; set; }
        public Guid code_device { get; set; }
        public Guid code_keyword { get; set; }
        public DateTime checkintime { get; set; }
    }
}
