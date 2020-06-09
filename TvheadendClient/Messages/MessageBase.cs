namespace TvheadendClient.Messages
{
    /// <summary>
    /// Message bese for sending to server
    /// </summary>
    public class MessageBase: DynamicMessageItem
    {

        internal MessageBase(DynamicMessageItem msg)
        {
            this.Data = msg.Data;
        }

        internal MessageBase()
        {

        }

        /// <summary>
        /// Create message with appropriate method
        /// </summary>
        /// <param name="method"></param>
        public MessageBase(string method)
        {
            Method = method;
        }

        internal long? Seq
        {
            get => Get<long?>("seq");
            set => Set("seq",value);
        }

        internal string Method
        {
            get => Get<string>("method");
            set => Set("method", value);
        }

        internal string UserName
        {
            get => Get<string>("username");
            set => Set("username", value);
        }

        internal byte[] Digest
        {
            get => Get<byte[]>("digest");
            set => Set("digest", value);
        }

        internal long? Noaccess
        {
            get => Get<long?>("noaccess");
            set => Set("noaccess", value);
        }
    }
}