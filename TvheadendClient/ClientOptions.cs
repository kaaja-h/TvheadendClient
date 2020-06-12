using System.Globalization;

namespace TvheadendClient
{
    /// <summary>
    /// Oprtions for client - connection setting etc
    /// </summary>
    public class ClientOptions
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ClientOptions()
        {
            Port = 9982;
            Ipv6 = false;
            Culture = CultureInfo.GetCultureInfo("cs-CZ");
            MessageTimeout = 30000;
            ConnectionTimeout = 10000;
        }

        /// <summary>
        /// Host - required
        /// </summary>
        public virtual string Host { get; set; }

        /// <summary>
        /// Port default 9982
        /// </summary>
        public virtual int Port { get; set; }

        /// <summary>
        /// Flag to use ipv6 instead ipv4
        /// </summary>
        public virtual bool Ipv6 { get; set; }

        /// <summary>
        /// UserName - optiona
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// Password - needed when username is provided
        /// </summary>
        public virtual string Password { get; set; }

        /// <summary>
        /// Culture for reading data from server
        /// </summary>
        public virtual CultureInfo Culture { get; set; }


        /// <summary>
        /// Time for waiting for reply in milliseconds default 30000
        /// </summary>
        public int MessageTimeout { get; set; }


        /// <summary>
        /// Connection timeout in in milliseconds default 10000
        /// </summary>
        public int ConnectionTimeout { get; set; }
        
    }
}