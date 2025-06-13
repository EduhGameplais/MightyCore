/*using System;
using System.IO.MemoryMappedFiles;
using MPM.PushAndPush;
using System.Text;
using System.Threading.Tasks;
using Mighty.Communications.Advanced;
using Mighty.Math;

namespace Mighty.Communications
{
    public static class PaPC
    {
        public class Network
        {
            public EventHandler<string> OnReceiveMessage;

            private int MyCode;
            private int OtherCode;

            private PaPServer _server;
            private PaPClient _client;

            /// <summary>
            /// Please Code and OtherProgramCode go be lower than 65535 and not equals one each other.
            /// </summary>
            /// <param name="Code"></param>
            /// <param name="OtherProgramCode"></param>
            public void Start(int Code, int OtherProgramCode)
            {
                if (Code <= 0) throw new ArgumentOutOfRangeException(nameof(Code));
                if (OtherProgramCode <= 0) throw new ArgumentOutOfRangeException(nameof(OtherProgramCode));

                if (Code == OtherProgramCode) throw new ArgumentException("Code and OtherProgramCode are equals to each other");

                MyCode = Mathf.Clamp(Code, 65535);
                OtherCode = Mathf.Clamp(OtherProgramCode, 65535);
                _server = new PaPServer(Code, "127.0.0.1");
                _client = new PaPClient();

                _server.Start();

                _server.ClientConnected += (sender, args) =>
                {
                    InternalOnReceive(_server.ReceivedMessage);
                };
            }

            public void Send(string Data)
            {
                _client.SendMessage(OtherCode, "127.0.0.1", Data);
            }

            private void InternalOnReceive(string Data)
            {
                OnReceiveMessage?.Invoke(this, Data);
            }

        }
    }


}

namespace Mighty.Communications.Advanced
{   
    public delegate void MessageReceivedEventHandler(string message);

    /// <summary>
    /// Not Recommended to use, because in some cases are not working.
    /// </summary>
    public class MemoryMappedFileCommunicator : IDisposable
    {
        private readonly MemoryMappedFile _mmf;
        private readonly MemoryMappedViewAccessor _accessor;

        public event MessageReceivedEventHandler MessageReceived;

        public MemoryMappedFileCommunicator(string name, int capacity)
        {
            _mmf = MemoryMappedFile.CreateOrOpen(name, capacity);
            _accessor = _mmf.CreateViewAccessor(0, capacity, MemoryMappedFileAccess.ReadWrite);
        }

        public void Send(string message)
        {
            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
            _accessor.WriteArray(0, messageBuffer, 0, messageBuffer.Length);
            _accessor.Flush();
        }

        public void Receive()
        {
            byte[] messageBuffer = new byte[_accessor.Capacity];
            _accessor.ReadArray(0, messageBuffer, 0, messageBuffer.Length);
            string message = Encoding.UTF8.GetString(messageBuffer);
            OnMessageReceived(message);
        }

        protected virtual void OnMessageReceived(string message)
        {
            MessageReceived?.Invoke(message);
        }

        public void Dispose()
        {
            _accessor.Dispose();
            _mmf.Dispose();
        }
    }
}
*/