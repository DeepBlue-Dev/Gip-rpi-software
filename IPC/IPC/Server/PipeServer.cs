using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;
using IPC.StreamString;
using Blazor_FrontEnd.Data.RequestCodes;

namespace IPC.Server
{
    public class PipeServer 
    {
        private string _pipeName = "pipe";
        private string FrontendOutBackendInName = "FrontendOutBackendIn";
        private string FrontendInBackendOutName = "FrontendInBackendOut";
        public NamedPipeServerStream FrontendOutBackendIn;
        public NamedPipeServerStream FrontendInBackendOut;
        private StreamString.StreamString _streamString;
        public NamedPipeServerStream _pipeServerStream;

        //  initialize and catch possible exceptions
        public PipeServer()
        {
            try
            {
                FrontendInBackendOut = new NamedPipeServerStream(FrontendInBackendOutName, PipeDirection.Out);
                FrontendOutBackendIn = new NamedPipeServerStream(FrontendOutBackendInName, PipeDirection.In);
                _pipeServerStream = new NamedPipeServerStream(_pipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Byte);
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

        public RequestCodes? GetCommandFromPipe()
        {
            int readbyte = 0;
            StreamReader reader = new StreamReader(FrontendOutBackendIn,Encoding.ASCII);  //  initiate reader 
            if(FrontendOutBackendIn.InBufferSize > 0)  //  check if anything is in the stream
            {
                while((readbyte = reader.Read()) != -1)
                {
                    if(readbyte != 0) { continue; }
                }
                return (RequestCodes?)Enum.ToObject(typeof(RequestCodes?), readbyte);
            }
            return null;    //  no command present in pipe
        }
        /*
        public string? ReadString()
        {
            StreamReader reader = new StreamReader(FrontendOutBackendIn,Encoding.ASCII);
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
        */

        public bool NewCommandArrived()
        {
            if(FrontendOutBackendIn.InBufferSize > 0) { return true; }
            return false;
        }

        public string WriteString([System.Diagnostics.CodeAnalysis.NotNull] string outString)
        {
            if (!_pipeServerStream.CanWrite || outString is null || outString.Length < 1) { return null; }
            if (!FrontendInBackendOut.IsConnected)
            {
                FrontendInBackendOut.WaitForConnection();
            }
            StreamWriter writer = new StreamWriter(FrontendInBackendOut,Encoding.ASCII);
            try
            {
                foreach(char character in outString){
                    writer.Write(Convert.ToInt32(character));
                }
                writer.Write(0);
                writer.Flush();
                return null;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
        }

        ~PipeServer()
        {
            FrontendOutBackendIn.Close();
            FrontendInBackendOut.Close();
            _pipeServerStream.Close();
            _pipeServerStream.Dispose();
        }
    }
}
