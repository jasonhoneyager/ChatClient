using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.Connect("192.168.1.88", "Hello");
        }
    }
}
