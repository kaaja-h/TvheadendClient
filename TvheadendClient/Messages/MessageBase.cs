namespace TvheadendClient.Messages
{
    public class MessageBase: DynamicMessage
    {

        internal MessageBase(DynamicMessage msg)
        {
            this.Data = msg.Data;
        }

        internal MessageBase()
        {

        }

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