using System.Threading.Tasks;
using System.IO.Pipes;
using System.IO;
using System.Text;
using System;

namespace Blazor_FrontEnd.Data
{
    public class IPCClient
    {
        private string _pipeName = "pipe";
        private NamedPipeClientStream _pipeClientStream;
        private ASCIIEncoding _ascii = new ASCIIEncoding();

        //  initialize and catch possible exceptions
        public IPCClient()
        {          
            try
            {
                _pipeClientStream = new NamedPipeClientStream(".", _pipeName, PipeDirection.InOut);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public Task Start()
        {
            if (_pipeClientStream.IsConnected) { return Task.CompletedTask; } //  return just like we connected
            _pipeClientStream.Connect();
            return Task.CompletedTask;
        }

        public string? ReadString()
        {
            StreamReader reader = new StreamReader(_pipeClientStream);
            StringBuilder sBuilder = new StringBuilder();
            int readByte = 0;
            if (!_pipeClientStream.CanRead) { return null; }

            try
            {
                while ((readByte = reader.Read()) != -1)
                {

                    sBuilder.Append((char)readByte);
                    if ((char)readByte == '\0') { break; }
                    if (reader.EndOfStream) { break; }

                }
                Console.WriteLine(sBuilder.ToString());
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
                _pipeClientStream.Write(Encoding.Convert(Encoding.Default, Encoding.ASCII, Encoding.Default.GetBytes(toSend)));
                _pipeClientStream.WriteByte(0);
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
