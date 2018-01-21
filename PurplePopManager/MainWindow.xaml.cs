using PurplePopManager.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PurplePopManager
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        protected static List<RegisteredClientInfo> registeredClientInfoList = new List<RegisteredClientInfo>();
        // TCP/IP로 접속된 클라이언트 정보
        protected static List<ConnectedClientInfo> connectedClientInfoList = new List<ConnectedClientInfo>();

        public MainWindow()
        {
            InitializeComponent();

            // 클라이언트 Mock 시작
            Thread clientThread = new Thread(startUdpSend);
            clientThread.Start();

            // 클라이언트 정보 수집하는 쓰레드
            Thread serverThread = new Thread(startUdpRecv);
            serverThread.Start();

        }

        private void startUdpRecv()
        {
            UdpClient cli = new UdpClient(7777);
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 7777);
            while (true)
            {
                byte[] data = cli.Receive(ref ip);
                string s = Encoding.UTF8.GetString(data);
                Console.WriteLine("{0} / IP: {1}", s, ip.Address);

                // RegisteredClientInfo rclInfo = registeredClientInfo.Find(x => x.Ip.Equals(ip.Address));
                if (!connectedClientInfoList.Exists(x => x.Ip.Equals(ip.Address.ToString())))
                {
                    ConnectedClientInfo ci = new ConnectedClientInfo();
                    ci.Ip = ip.Address.ToString();
                    ci.ConnectedTime = DateTime.Now;
                    connectedClientInfoList.Add(ci);
                }

                Console.WriteLine("Connected Client Count: {0}", connectedClientInfoList.Count());

                // 클라이언트를 종료했으면 리스트에서 제거
                // connectedClientInfoList.RemoveAll(client => (DateTime.Now.AddSeconds(-5).CompareTo(client.ConnectedTime) == 1));

                // ConnectedClientList connectedClientResourceList = Resources["connectedClientKey"] as ConnectedClientList;
                // connectedClientResourceList.Add(new ConnectedClientInfo());

                ClientStatusView.Dispatcher.BeginInvoke(new Action(() => {

                    ClientStatusView.Items.Clear();
                    ClientStatusView.Items.Add(connectedClientInfoList);

                }));

            }
        }

        private void startUdpSend()
        {
            Console.WriteLine("Send to boardcast.");

            UdpClient cli = new UdpClient();
            IPEndPoint ip = new IPEndPoint(IPAddress.Broadcast, 7777);
            cli.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            ClientInfo clientInfo = new ClientInfo();
            clientInfo.Ip = ip.Address.ToString();
            clientInfo.Version = "0.1";

            PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("Network Interface");
            string instance = performanceCounterCategory.GetInstanceNames()[0]; //1st NIC
            PerformanceCounter performanceCounterSent = new PerformanceCounter("Network Interface", "Bytes Sent/sec", instance);
            PerformanceCounter performanceCounterRecv = new PerformanceCounter("Network Interface", "Bytes Received/sec", instance);

            clientInfo.TcpRecv = performanceCounterSent.NextValue() / 1024;
            clientInfo.TcpSend = performanceCounterRecv.NextValue() / 1024;

            Process[] processes = Process.GetProcesses();
            foreach(var process in processes)
            {
                Console.WriteLine("Process: {0}", process);
            }

            // JSON 처리

            byte[] data = Encoding.UTF8.GetBytes("asdasd한글잘됨");
            int result = cli.Send(data, data.Length, "", 7777);
            Console.WriteLine("Send Result: {0}", result);

            Thread.Sleep(2000);

            Thread t = new Thread(startUdpSend);
            t.Start();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PmangHyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void NexonHyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;

        }

        private void NetmarbleHyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;

        }

        private void DaumHyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;

        }

        private void NcHyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;

        }

        private void BlizzardHyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;

        }

        private void WargamingHyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;

        }

        private void WebzenHyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;

        }

        private void LolHyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void WemadeHyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void HanGameHyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
