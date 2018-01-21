using System.Collections.ObjectModel;

namespace PurplePopManager.Model
{
    public class RegisteredClientList : ObservableCollection<RegisteredClientInfo> { }

    public class RegisteredClientInfo
    {
        private int number;
        private string ip;

        public int Number { get => number; set => number = value; }
        public string Ip { get => ip; set => ip = value; }
    }
}