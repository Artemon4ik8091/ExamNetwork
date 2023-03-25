using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data = "";
            Console.WriteLine("OK, now an attempt will be made to connect to the server. Please wait...");
            IPEndPoint serverPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            clientSocket.Connect(serverPoint);
            if (clientSocket.Connected)
            {
                Console.WriteLine("Connect!");
                while(true)
                {
                    data = Console.ReadLine();
                    clientSocket.Send(Encoding.UTF8.GetBytes(data));
                    data = null;
                }
            }

            else
            {
                Console.WriteLine("The program could not establish a connection.");
                clientSocket.Close();
            }
        }
    }
}
