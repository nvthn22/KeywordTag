using KeywordTag.Database.SQLServer.Tables;

namespace KeywordTag.Database.SQLServer.SeedDatabase
{
    internal class SeedMessage
    {
        public readonly Message[] messages =
        {
            new Message { code = 1, name = "Message 1" },
            new Message { code = 2, name = "Message 2" },
            new Message { code = 3, name = "Message 3" }
        };
    }
}
