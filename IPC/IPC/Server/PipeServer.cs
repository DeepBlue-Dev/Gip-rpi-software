using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;
using IPC.StreamString;

namespace IPC.Server
{
    public class PipeServer 
    {
        private string _pipeName = "pipe";
        private StreamString.StreamString _streamString;
        private NamedPipeServerStream _pipeServerStream;

        //  initialize and catch possible exceptions
        public PipeServer()
        {
            try
            {
                _pipeServerStream = new NamedPipeServerStream(_pipeName, PipeDirection.InOut);
                _streamString = new StreamString.StreamString(_pipeServerStream);
                
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
            StreamReader reader = new StreamReader(_pipeServerStream);
            StringBuilder sBuilder = new StringBuilder();
            int readByte = 0;
            if (!_pipeServerStream.CanRead) { return null; }

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
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public bool NewCommandArrived()
        {
            if (!_pipeServerStream.IsConnected) { return false; }
            StreamReader reader = new StreamReader(_pipeServerStream);

            if (reader.EndOfStream) { return false; }
            return true;
        }

        public string WriteString([System.Diagnostics.CodeAnalysis.NotNull] string outString)
        {
            if (!_pipeServerStream.CanWrite || outString is null || outString.Length < 1) { return null; }

            try
            {
                _pipeServerStream.Write(Encoding.Convert(Encoding.Default, Encoding.ASCII, Encoding.Default.GetBytes(outString)));
                _pipeServerStream.WriteByte(0);
                return null;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
