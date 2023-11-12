using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.WebSockets;

namespace SOEFR
{
    public class WebSocketClient
    {
        public event Action<string> ConnectionStatusChanged;

        public string ConnectionStatus { get; private set; } = "Disconnected";

        public async Task Connect()
        {
            Uri serverUri = new Uri("wss://soefr.com:2096");

            using (ClientWebSocket clientWebSocket = new ClientWebSocket())
            {
                try
                {
                    var welcomeTime = DateTime.Now;
                    await clientWebSocket.ConnectAsync(serverUri, CancellationToken.None);
                    Debug.WriteLine("Connected to the WebSocket server.");
                    ConnectionStatus = "Connected to the WebSocket server.";
                    ConnectionStatusChanged?.Invoke(ConnectionStatus);

                    ArraySegment<byte> welcomeBuffer = new ArraySegment<byte>(new byte[1024]);

                    WebSocketReceiveResult welcomeResult = await clientWebSocket.ReceiveAsync(welcomeBuffer, CancellationToken.None);
                    if (welcomeResult.MessageType == WebSocketMessageType.Text)
                    {
                        string response = Encoding.UTF8.GetString(welcomeBuffer.Array, 0, welcomeResult.Count);
                        Debug.WriteLine($"Server says: {response}");
                        DisplayLatency(welcomeResult, welcomeTime);
                    }

                    while (clientWebSocket.State == WebSocketState.Open)
                    {
                        string message = "SOEFR";  // Replace with your message or logic to get a message
                        byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                        ArraySegment<byte> buffer = new ArraySegment<byte>(messageBytes);

                        // Sends message to server
                        await clientWebSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                        ArraySegment<byte> receiveBuffer = new ArraySegment<byte>(new byte[1024]);
                        var receiveTime = DateTime.Now;
                        WebSocketReceiveResult result = await clientWebSocket.ReceiveAsync(receiveBuffer, CancellationToken.None);
                        if (result.MessageType == WebSocketMessageType.Text)
                        {
                            string response = Encoding.UTF8.GetString(receiveBuffer.Array, 0, result.Count);
                            Debug.WriteLine($"Server says: {response}");
                            DisplayLatency(result, receiveTime);
                        }

                        await Task.Delay(30000);  // Delay for 30 seconds
                    }

                    await clientWebSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                    Debug.WriteLine("WebSocket connection closed.");
                }
                catch (WebSocketException ex)
                {
                    Debug.WriteLine($"WebSocket error: {ex.Message}");
                    ConnectionStatus = $"WebSocket error: {ex.Message}";
                    ConnectionStatusChanged?.Invoke(ConnectionStatus);
                }
            }
        }

        static void DisplayLatency(WebSocketReceiveResult result, DateTime sendTime)
        {
            var latency = (DateTime.Now - sendTime).TotalMilliseconds;
            Debug.WriteLine($"Latency (message size: {result.Count} bytes): {latency} ms");
        }
    }
}
