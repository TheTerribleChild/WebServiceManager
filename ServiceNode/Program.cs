using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceNode
{
    class Program
    {
        static void Main(string[] args)
        {
            int port;
            if(int.TryParse(args[0], out port))
            {
                UdpClient client = new UdpClient();
                IPEndPoint ip = new IPEndPoint(IPAddress.Broadcast, port);
                byte[] bytes = Encoding.UTF8.GetBytes("THIS IS A REAL MESSAGE");
                client.Send(bytes, bytes.Length, ip);
                client.Close();
            }
            
        }
    }
}
