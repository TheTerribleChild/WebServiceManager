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

        private BroadcastListener broadcastListener;


        public NodeManager(string applicationName)
        {
            broadcastListener = new BroadcastListener();
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
