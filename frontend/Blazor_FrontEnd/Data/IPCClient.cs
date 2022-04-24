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
                _pipeClientStream = new NamedPipeClientStream(".", _pipeName, PipeDirection.InOut); //  initiate bidirectional pipe communication 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  //  send to console
                throw new Exception(ex.Message);    //  rethrow YEEEHAAAWW
            }
        }

        public void StartSynchronous()
        {
            if (_pipeClientStream.IsConnected) { return; }
            _pipeClientStream.Connect();
        }

        public Task Start()
        {
            if (_pipeClientStream.IsConnected) { return Task.CompletedTask; } //  return just like we connected
            _pipeClientStream.Connect();
            return Task.CompletedTask;  //  return empty task result, no void to avoid deadlocks & weird errors
        }

        public Task<string?> ReadString()
        {
            StreamReader reader = new StreamReader(_pipeClientStream);  //  gives us more read methods and fixes seeking support
            StringBuilder sBuilder = new StringBuilder();   //  for building the string from the received characters
            int readByte = 0;
            if (!_pipeClientStream.CanRead) { return Task.FromResult<string?>(null); }

            try
            {
                while ((readByte = reader.Read()) != -1)
                {
                    sBuilder.Append((char)readByte);    //  append to the string
                    if ((char)readByte == '\0') { break; }
                    if (reader.EndOfStream) { break; }

                }
                return Task.FromResult<string?>(sBuilder.ToString()); //  return the string we built
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return Task.FromResult<string?>(null);
            }
        }

        public string? ReadStringSynchronous()
        {
            StreamReader reader = new StreamReader(_pipeClientStream);  //  gives us more read methods and fixes seeking support
            StringBuilder sBuilder = new StringBuilder();   //  for building the string from the received characters
            int readByte = 0;
            if (!_pipeClientStream.CanRead) { return "Can't read from backend process"; }

            try
            {
                while ((readByte = reader.Read()) != -1)
                {
                    sBuilder.Append((char)readByte);    //  append to the string
                    if ((char)readByte == '\0') { break; }
                    if (reader.EndOfStream) { break; }

                }
                return sBuilder.ToString(); //  return the string we built
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        public Task<string?> SendString(string toSend)
        {
            if (!_pipeClientStream.IsConnected || toSend.Length < 1) { return Task.FromResult<string?>("Not Connected"); }
            try
            {
                _pipeClientStream.Write(Encoding.Convert(Encoding.Default, Encoding.ASCII, Encoding.Default.GetBytes(toSend))); //  convert the encoding and then send, we dont want to mix up unicode and ASCII
                _pipeClientStream.WriteByte(0); //  send nullbyte terminator manually since Convert doesnt generate it

                return Task.FromResult<string?>(null);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);    //  log to console, you know the drill
                return Task.FromResult(ex.Message);
            }
        }

        public Task<string?> SendCode(RequestCodes code)
        {
            if(!_pipeClientStream.IsConnected) { return Task.FromResult<string?>("pipe not connected"); }

            try
            {
                _pipeClientStream.Write(_ascii.GetBytes( code.ToString())); //  send code as a string, this makes it easier for me but adds a small delay for the string conversions
                _pipeClientStream.WriteByte(0);

                return Task.FromResult<string?>(ReadStringSynchronous());
            } catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return Task.FromResult<string?>(ex.Message);
            }
        }
    }
}
