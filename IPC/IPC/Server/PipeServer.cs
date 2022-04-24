using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;

namespace IPC.Server
{
    public class PipeServer
    {
        private string _pipeName = "pipe";
        private UnicodeEncoding _streamEncoder;
        private NamedPipeServerStream _pipeServerStream;

        //  initialize and catch possible exceptions
        public PipeServer()
        {  
            try
            {
                _pipeServerStream = new NamedPipeServerStream(_pipeName, PipeDirection.InOut);
                _streamEncoder = new UnicodeEncoding();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Start()
        {
            _pipeServerStream.WaitForConnection();
        }

        public string? ReadString()
        {
            StringBuilder sBuilder = new StringBuilder();
            int readByte = 0;
            if(!_pipeServerStream.IsConnected) { return null; }
            
            try
            {
                while((readByte = _pipeServerStream.ReadByte()) != -1)
                {
                    sBuilder.Append(readByte);
                }
                return sBuilder.ToString();
            }catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
        }

        public bool SendString(string toSend)
        {
            if (!_pipeServerStream.IsConnected ||toSend.Length < 1) { return false; }

            try
            {
                _pipeServerStream.Write(Encoding.ASCII.GetBytes(toSend.ToCharArray()));
                return true;
            }catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
