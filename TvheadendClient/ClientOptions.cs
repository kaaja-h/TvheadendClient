using System.Globalization;

namespace TvheadendClient
{
    public class ClientOptions
    {
        public ClientOptions()
        {
            Port = 9982;
            Ipv6 = false;
            Culture = CultureInfo.GetCultureInfo("cs-CZ");
        }

        public virtual string Host { get; set; }
        public virtual int Port { get; set; }

        public virtual bool Ipv6 { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }

        public virtual CultureInfo Culture { get; set; }

        
    }
}