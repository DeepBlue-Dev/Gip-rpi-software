using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.IO;

namespace IPC.Client
{
    public class PipeClient
    {
        private string _pipeName = "pipe";
        private UnicodeEncoding _streamEncoder;
        private NamedPipeClientStream _pipeClientStream;

        //  initialize and catch possible exceptions
        public PipeClient()
        {
            try
            {
                _pipeClientStream = new NamedPipeClientStream(".",_pipeName, PipeDirection.InOut);
                _streamEncoder = new UnicodeEncoding();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Start()
        {
            _pipeClientStream.Connect();
        }

        public string? ReadString()
        {
            StringBuilder sBuilder = new StringBuilder();
            int readByte = 0;
            if (!_pipeClientStream.IsConnected) { return null; }

            try
            {
                while ((readByte = _pipeClientStream.ReadByte()) != -1)
                {
                    sBuilder.Append(readByte);
                }
                return sBuilder.ToString();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
        }

        public bool SendString(string toSend)
        {
            if (!_pipeClientStream.IsConnected || toSend.Length < 1) { return false; }

            try
            {
                _pipeClientStream.Write(Encoding.ASCII.GetBytes(toSend.ToCharArray()));
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
