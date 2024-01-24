using MessagePack;

namespace WebSocketServer.MessagePack
{
    [MessagePackObject]
    public sealed class Message
    {
        [Key(0)]
        public string Content { get; set; }
    }
}
