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

        public List<string> Observers;

        private GameController gCtrl = null;

        public GameNetwork(GameController gc) {
            this.gCtrl = gc;
            this.Observers = new List<string>();
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
                this.server.Close();
                this.theadServer.Abort();
            }
        }

        private void SendMessage(string host, string msg, int port) {
            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            this.client.Send(bytes, bytes.Length, host, port);
        }
        public void SendMessageToHost(string msg, int port) {
            if(this.hostIP != string.Empty) {
                this.SendMessage(this.hostIP, msg, port);
            }
        }
        public void SendMessageToHost(string msg) {
            this.SendMessageToHost(msg, DefaultPort);
        }
        public void SendMessageToOpponent(string msg, int port) {
            if(this.opponentIP != string.Empty) {
                this.SendMessage(this.opponentIP, msg, port);
            }
        }
        public void SendMessageToOpponent(string msg) {
            this.SendMessageToOpponent(this.opponentIP, DefaultPort);
        }
        public void SendMessageToObservers(string msg, int port) {
            foreach(string observer in this.Observers) {
                this.SendMessage(observer, msg, port);
            }
        }
        public void SendMessageToObservers(string msg) {
            foreach(string observer in this.Observers) {
                this.SendMessage(observer, msg, DefaultPort);
            }
        }

    }
}
