using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PurplePopManager.Model
{
    public class ConnectedClientInfo
    {
        private string number;
        private string ip;
        private string version;
        private string tcpSend;
        private string tcpRecv;
        private string udpSend;
        private string udpRecv;
        private bool isRegisteredIp;
        private List<string> runningPackageGameList;
        private List<string> runningWebGameList;
        private List<string> processApp;
        private DateTime connectedTime;

        public string Number { get => number; set => number = value; }
        public string Ip { get => ip; set => ip = value; }
        public string Version { get => version; set => version = value; }
        public string TcpSend { get => tcpSend; set => tcpSend = value; }
        public string TcpRecv { get => tcpRecv; set => tcpRecv = value; }
        public string UdpSend { get => udpSend; set => udpSend = value; }
        public string UdpRecv { get => udpRecv; set => udpRecv = value; }
        public List<string> RunningPackageGameList { get => runningPackageGameList; set => runningPackageGameList = value; }
        public List<string> RunningWebGameList { get => runningWebGameList; set => runningWebGameList = value; }
        public List<string> ProcessApp { get => processApp; set => processApp = value; }
        public bool IsRegisteredIp { get => isRegisteredIp; set => isRegisteredIp = value; }
        public DateTime ConnectedTime { get => connectedTime; set => connectedTime = value; }
    }

    public class ConnectedClientList : ObservableCollection<ConnectedClientInfo> { }
}