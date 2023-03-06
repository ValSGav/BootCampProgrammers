using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Server
{
    class OurServer
    {
        TcpListener listenServer;
        public OurServer()
        {
            listenServer = new TcpListener(IPAddress.Parse("127.0.0.1"), 5555);
            listenServer.Start();

            LoopClients();
        }

        void LoopClients()
        {
            while (true)
            {
                TcpClient client = listenServer.AcceptTcpClient();
                
                Thread thread = new Thread(() => HandleClient(client));
                thread.Start();
            }
        }

        void HandleClient(TcpClient client)
        {
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.UTF8);
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.UTF8);
            while (true)
            {
                string message = sReader.ReadLine();
                Console.WriteLine($"Клент написал - {message}");

                Console.Write("Ответ клиенту: ");
                string answerString = Console.ReadLine();
                sWriter.WriteLine(answerString);
                sWriter.Flush();
            }
        }
    }
}