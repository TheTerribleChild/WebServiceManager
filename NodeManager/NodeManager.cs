using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace NodeManager
{
    public class NodeManager
    {

        private Utility.WebUtility.BroadcastListener broadcastListener;


        public NodeManager(string applicationName)
        {
            broadcastListener = new Utility.WebUtility.BroadcastListener();
            broadcastListener.BroadcastReceived += BroadcastReceived;


        }

        public void Init()
        {
            while (true)
            {
                try
                {


                    break;
                }
                catch (Exception) { }
            }


        }

        private void BroadcastReceived(object sender, Utility.WebUtility.BroadcastReceivedEventArgs args)
        {
            Console.WriteLine(args.message + " " + args.endpoint.Address + " " + args.endpoint.Port);
        }

        public void Start()
        {
            broadcastListener.Start();
        }

        public void Stop()
        {
            broadcastListener.Stop();
        }

        

    }
}
