using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurplePopManager.Model
{
    class ClientInfo
    {
        private string ip;
        private string version;
        private float tcpSend;
        private float tcpRecv;
        private float udpSend;
        private float udpRecv;
        private List<GameVO> processList;

        public string Ip { get => ip; set => ip = value; }
        public string Version { get => version; set => version = value; }
        public float TcpSend { get => tcpSend; set => tcpSend = value; }
        public float TcpRecv { get => tcpRecv; set => tcpRecv = value; }
        public float UdpSend { get => udpSend; set => udpSend = value; }
        public float UdpRecv { get => udpRecv; set => udpRecv = value; }
        internal List<GameVO> ProcessList { get => processList; set => processList = value; }
    }
}
