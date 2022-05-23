using System.Threading.Tasks;
using Blazor_FrontEnd.Data.RequestCodes;
using System.Collections.Generic;
using System.Threading;
using System.IO.Pipes;
using System.IO;
using System.Text;
using System;
using NetMQ.Sockets;
using NetMQ;
namespace Blazor_FrontEnd.Data
{
    public class IPCClient
    {
        private string FrontendOutBackendInName = "FrontendOutBackendIn";
        private string FrontendInBackendOutName = "FrontendInBackendOut";
        private NamedPipeClientStream FrontendOutBackendIn;
        private NamedPipeClientStream FrontendInBackendOut;
        private string _pipeName = "pipe";
        private NamedPipeClientStream _pipeClientStream;
        private ASCIIEncoding _ascii = new ASCIIEncoding();

        //  initialize and catch possible exceptions
        public IPCClient()
        {        
            /*
            try
            {
                _pipeClientStream = new NamedPipeClientStream("localhost", _pipeName, PipeDirection.InOut, PipeOptions.Asynchronous); //  initiate bidirectional pipe communication 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  //  send to console
                throw new Exception(ex.Message);    //  rethrow YEEEHAAAWW
            }
            */
        }
        /*
        public void StartSynchronous()
        {
            if (_pipeClientStream.IsConnected) { return; }
            _pipeClientStream.Connect();
        }

        public async Task Start(CancellationToken tokenSource)
        {
            if (_pipeClientStream.IsConnected) { return; } //  return just like we connected
            await _pipeClientStream.ConnectAsync(tokenSource);
            return;  //  return empty task result, no void to avoid deadlocks & weird errors
        }

        public async Task Start()
        {
            if (_pipeClientStream.IsConnected) { return; } //  return just like we connected
            await _pipeClientStream.ConnectAsync();
            return;  //  return empty task result, no void to avoid deadlocks & weird errors
        }
        */
        public async Task<string?> ReadString()
        {
            try
            {
                return await ReadStringAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<string?> ReadString(CancellationToken tokenSource)
        {
            try
            {
                return await ReadStringAsync(tokenSource).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
        }

        private async Task<string?> ReadStringAsync(CancellationToken tokenSource)
        {
            FrontendInBackendOut = new NamedPipeClientStream("localhost", FrontendInBackendOutName, PipeDirection.In);
            StreamReader reader = new StreamReader(FrontendInBackendOut);  //  gives us more read methods and fixes seeking support

            ASCIIEncoding encoding = new ASCIIEncoding();
            List<byte> buff = new List<byte>();
            int readByte = 0;
            Console.WriteLine($"In buffer: {FrontendInBackendOut.InBufferSize}");
            while ((readByte = reader.Read()) != -1)
            {
                if(readByte == 0) { continue; }
                if ((char)readByte == '\0') { break; }
                buff.Add((byte)readByte);    //  append to the string
                
            }
            reader.Close();
            FrontendInBackendOut.Close();

            return encoding.GetString(buff.ToArray()); //  return the string we built
        }

        private async Task<string?> ReadStringAsync()
        {
            FrontendInBackendOut = new NamedPipeClientStream("localhost", FrontendInBackendOutName, PipeDirection.In);
            StreamReader reader = new StreamReader(FrontendInBackendOut);  //  gives us more read methods and fixes seeking support
            StringBuilder sBuilder = new StringBuilder();   //  for building the string from the received characters
            int readByte = 0;

            while ((readByte = reader.Read()) != -1)
            {
                sBuilder.Append((char)readByte);    //  append to the string
                if ((char)readByte == '\0') { break; }
                if (reader.EndOfStream) { break; }

            }
            reader.Close();
            FrontendInBackendOut.Close();
            return sBuilder.ToString(); //  return the string we built
            
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

        public async Task<string?> SendString(string toSend)
        {
            if (!_pipeClientStream.IsConnected || toSend.Length < 1) { return "not connected"; }
            try
            {
                await _pipeClientStream.WriteAsync(Encoding.Convert(Encoding.Default, Encoding.ASCII, Encoding.Default.GetBytes(toSend))); //  convert the encoding and then send, we dont want to mix up unicode and ASCII
                _pipeClientStream.WriteByte(0); //  send nullbyte terminator manually since Convert doesnt generate it

                return null;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);    //  log to console, you know the drill
                return ex.Message;
            }
        }

        public async Task<string?> SendString(string toSend, CancellationToken cancelSrc)
        {
            StreamWriter writer = new StreamWriter(_pipeClientStream);
            if (!_pipeClientStream.IsConnected || toSend.Length < 1) { return "not connected"; }
            try   
            {
                await writer.BaseStream.WriteAsync(Encoding.Convert(Encoding.Default, Encoding.ASCII, Encoding.Default.GetBytes(toSend)), cancelSrc); //  convert the encoding and then send, we dont want to mix up unicode and ASCII
                writer.BaseStream.WriteByte(0); //  send nullbyte terminator manually since Convert doesnt generate it
                return null;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);    //  log to console, you know the drill
                return ex.Message;
            }
        }
        
        public async Task<string?> SendCode(RequestCodes.RequestCodes code)
        {
            if(!_pipeClientStream.IsConnected || !_pipeClientStream.CanRead || !_pipeClientStream.CanWrite) { return "pipe not connected"; }

            try
            {
                await _pipeClientStream.WriteAsync(_ascii.GetBytes(code.ToString())); //  send code as a string, this makes it easier for me but adds a small delay for the string conversions
                _pipeClientStream.WriteByte(0);

                return await ReadString();
            } catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        public async Task<string?> SendCode(RequestCodes.RequestCodes code, CancellationToken cancelSrc)
        {
            using(var client = new RequestSocket())
            {
                client.Connect("tcp://localhost:2100");
                client.SendFrame(new byte[] {Convert.ToByte(code)});
                var response = await client.ReceiveFrameStringAsync(cancelSrc);
                return response.Item1;
            }

            /*
            StreamReader reader;
            StreamWriter writer;
            //_pipeClientStream = new NamedPipeClientStream("localhost", _pipeName, PipeDirection.InOut, PipeOptions.Asynchronous); //  initiate bidirectional pipe communication 
            //_pipeClientStream.Connect();

            FrontendOutBackendIn = new NamedPipeClientStream("localhost", FrontendOutBackendInName, PipeDirection.Out);
            if (!FrontendOutBackendIn.IsConnected) { FrontendOutBackendIn.Connect(500); }
            string? result;
            try
            {

                writer = new StreamWriter(FrontendOutBackendIn, Encoding.ASCII);
                await writer.WriteAsync(new char[] {Convert.ToChar(code),(char)0 },cancelSrc).ConfigureAwait(false); //  send code as a string, this makes it easier for me but adds a small delay for the string conversions
                result = await ReadStringAsync(cancelSrc).ConfigureAwait(false);
                writer.Close();
                FrontendOutBackendIn.Close();
                return result;
                
            }
            catch (Exception ex)
            {
               // _pipeClientStream.Close();
                Console.Error.WriteLine(ex.Message);
                return ex.Message;
            }
            */
        }

        public string SendCodeSynchronous(RequestCodes.RequestCodes code)
        {
            if (!_pipeClientStream.IsConnected || !_pipeClientStream.CanRead || !_pipeClientStream.CanWrite) { return "pipe not connected"; }

            try
            {
                _pipeClientStream.Write(_ascii.GetBytes(code.ToString())); //  send code as a string, this makes it easier for me but adds a small delay for the string conversions
                _pipeClientStream.WriteByte(0);
                return ReadStringSynchronous();
            }catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return ex.Message;
            }
            
        }
    }
}
