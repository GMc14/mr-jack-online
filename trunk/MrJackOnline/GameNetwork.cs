using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MrJack
{
    public class GameNetwork
    {
        private const int DefaultPort = 4220;

        private UdpClient server = null;
        private UdpClient client = null;
        private Thread theadServer = null;

        private string hostIP = string.Empty;
        public string HostIP {
            get { return this.hostIP; }
            set { this.hostIP = value; }
        }

        private string opponentIP = string.Empty;
        public string OpponentIP {
            get { return this.opponentIP; }
            set { this.opponentIP = value; }
        }

        public List<string> ObserverIPs;

        private GameController gCtrl = null;

        public GameNetwork(GameController gc) {
            this.gCtrl = gc;
            this.ObserverIPs = new List<string>();
            this.client = new UdpClient();
        }

        private void StartServer() {
            this.server = new UdpClient(DefaultPort);
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, DefaultPort);
            while(true) {
                string text = Encoding.UTF8.GetString(this.server.Receive(ref ep));
                this.gCtrl.CheckMessage(text + "from" + ep.Address.ToString());
            }
        }

        public void StartHost() {
            if(this.theadServer == null || !this.theadServer.IsAlive) {
                this.theadServer = new Thread(new ThreadStart(StartServer));
                this.theadServer.IsBackground = true;
                this.theadServer.Start();
            }
        }

        public void StopHost() {
            if(this.theadServer != null && this.theadServer.IsAlive) {
                this.theadServer.Abort();
                this.server.Close();
            }
        }

        private void SendMessage(string host, GameMessage msg, int port) {
            string msgg = "dd";
            byte[] bytes = Encoding.UTF8.GetBytes(msgg);
            this.client.Send(bytes, bytes.Length, host, port);
        }
        public void SendMessageToHost(GameMessage msg, int port) {
            if(this.hostIP != string.Empty) {
                this.SendMessage(this.hostIP, msg, port);
            }
        }
        public void SendMessageToHost(GameMessage msg) {
            this.SendMessageToHost(msg, DefaultPort);
        }
        public void SendMessageToOpponent(GameMessage msg, int port) {
            if(this.opponentIP != string.Empty) {
                this.SendMessage(this.opponentIP, msg, port);
            }
        }
        public void SendMessageToOpponent(GameMessage msg) {
            this.SendMessageToOpponent(msg, DefaultPort);
        }
        public void SendMessageToObservers(GameMessage msg, int port) {
            foreach(string observer in this.ObserverIPs) {
                this.SendMessage(observer, msg, port);
            }
        }
        public void SendMessageToObservers(GameMessage msg) {
            foreach(string observer in this.ObserverIPs) {
                this.SendMessage(observer, msg, DefaultPort);
            }
        }

    }
}
