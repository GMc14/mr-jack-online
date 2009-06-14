using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace MrJack
{
    public class GameNetwork
    {
        private const int DefaultPort = 4220;

        private UdpClient server = null;
        private UdpClient client = null;
        private Thread theadServer = null;

        private GameController gCtrl = null;

        public GameNetwork(GameController gc) {
            this.gCtrl = gc;
            this.client = new UdpClient();
            this.theadServer = new Thread(new ThreadStart(StartServer));
            this.theadServer.IsBackground = true;
        }

        private void StartServer() {
            if(this.server == null) {
                this.server = new UdpClient(DefaultPort);
            }
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, DefaultPort);
            while(true) {
                string text = Encoding.UTF8.GetString(this.server.Receive(ref ep));
                this.gCtrl.CheckMessage(text + "from" + ep.Address.ToString());
            } 
        }

        public void StartHost() {
            if(!this.theadServer.IsAlive) {
                this.theadServer = new Thread(new ThreadStart(StartServer));
                this.theadServer.IsBackground = true;
                this.theadServer.Start();
            }
        }
        public void StopHost() {
            if(this.theadServer != null) {
                this.theadServer.Abort();
            }
        }
        public void SendMessage(string host, string msg) {
            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            this.client.Send(bytes, bytes.Length, host, DefaultPort);
        }

    }
}
