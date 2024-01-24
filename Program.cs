using MessagePack;
using System.Net;
using System.Net.WebSockets;
using WebSocketServer.MessagePack;

namespace WebSocketServer
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://*:5000/ws/");
            listener.Start();

            await Console.Out.WriteLineAsync("Listening...");

            while (true)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                if (context.Request.IsWebSocketRequest)
                {
                    HttpListenerWebSocketContext wsContext = await context.AcceptWebSocketAsync(null);
                    WebSocket webSocket = wsContext.WebSocket;

                    //Обробка повідомлення WebSocket
                    await SendWebSocketMessage(webSocket, "Hello World");

                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, String.Empty, CancellationToken.None);
                }
                else
                {
                    context.Response.StatusCode = 400;
                    context.Response.Close();
                }
            }
        }

        static async Task SendWebSocketMessage(WebSocket webSocket, string messageContent)
        {
            var message = new Message { Content = messageContent };
            byte[] messageBytes = MessagePackSerializer.Serialize(message);

            await webSocket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Binary, true, CancellationToken.None);
            Console.WriteLine("Message sent: " +  messageContent); 
        }
    }
}
