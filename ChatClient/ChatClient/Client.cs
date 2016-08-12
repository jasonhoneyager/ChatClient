using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ChatClient
{
    class Client
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Client()
        {

        }

        
        
        public void Connect(string server, string message)
        {
            try
            {
                Int32 port = 13000;
                TcpClient client = new TcpClient(server, port);

                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

                data = new Byte[256];

                string responseData = string.Empty;

                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                stream.Close();
                client.Close();
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.Read();
        }
    }
}
