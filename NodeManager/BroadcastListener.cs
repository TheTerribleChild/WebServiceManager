using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NodeManager
{
    public class BroadcastListener
    {
        private UdpClient broadcastClient;
        
        private IPEndPoint broadcastListenerGroupEP;
        private Thread broadcastListenThread;

        public int BroadcastListenPort { get; private set; }

        private bool run = true;

        public BroadcastListener()
        {
            broadcastListenThread = new Thread(ListenToBroadcast);
        }

        public void Start()
        {
            if(broadcastListenThread != null && broadcastListenThread.ThreadState == ThreadState.Running)
            {
                Stop();
            }
            broadcastListenThread = new Thread(ListenToBroadcast);
            broadcastListenThread.Start();
        }

        public void Stop()
        {
            if (broadcastListenThread.ThreadState == ThreadState.Running)
            {
                broadcastListenThread.Abort();
                broadcastClient.Close();
                broadcastListenThread.Join();
            }
        }

        private void ListenToBroadcast()
        {
            Console.WriteLine("Starting listening to broadcast ");
            try
            {
                broadcastClient = new UdpClient();
                BroadcastListenPort = Utility.WebUtility.GetNextAvailablePortNumber();
                broadcastListenerGroupEP = new IPEndPoint(IPAddress.Any, BroadcastListenPort);

                broadcastClient.Client.Bind(broadcastListenerGroupEP);
                Console.WriteLine("Binded to port: " + BroadcastListenPort);
                while (run)
                {
                    byte[] data = broadcastClient.Receive(ref broadcastListenerGroupEP);
                    new Thread(ReceiveMessage).Start(data);
                }

            }catch (ThreadAbortException)
            {
                Console.WriteLine("Broadcast Listener thread stopped");
                BroadcastListenPort = 0;
                broadcastClient.Close();
                broadcastListenerGroupEP = null;
            }catch(Exception e)
            {
                Console.Error.WriteLine(e);
            }
            Console.WriteLine("broadcast listener thread exited");
        }

        private void ReceiveMessage(object input)
        {
            byte[] data = (byte[])input;
            if (data == null || data.Length == 0)
                return;
            string message = Encoding.UTF8.GetString(data, 0, data.Length);

        }
    }
}
