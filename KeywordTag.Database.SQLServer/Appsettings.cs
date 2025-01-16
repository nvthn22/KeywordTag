using Microsoft.Extensions.Configuration;

namespace KeywordTag.Database.SQLServer
{
    internal class Appsettings
    {
        public static Appsettings Instance { get; private set; } = new Appsettings();
        public IConfigurationRoot configuration { get; private set; }
        private readonly Lock _lock = new Lock();

        public Appsettings()
        {
            _lock.Enter();
            if (configuration == null)
            {
                var builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                configuration = builder.Build();
            }
            _lock.Exit();
        }
    }
}
