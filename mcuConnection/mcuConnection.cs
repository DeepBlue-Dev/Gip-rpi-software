using System;
using System.Net.Sockets;
using System.Net;
using System.Net.Mime;
using System.Text;
using Configurations.McuConnectionConfiguration;
using Configurations;
using System.Collections.Generic;
using System.Linq;

namespace mcuConnection
{
    public class McuConnection
    {
        public bool Connected { get; private set; }
        private TcpClient _client;
        private NetworkStream _connection;
        public readonly (IPAddress ip, int port) _connectionInfo;
        

        public McuConnection((IPAddress ip, int port) connInfo)
        {
            _connectionInfo.ip = connInfo.ip;
            _connectionInfo.port = connInfo.port;
        }

        public McuConnection(McuConnectionConfig connectionConfig)
        {
            _connectionInfo.ip = connectionConfig.McuSocket.ip;
            _connectionInfo.port = connectionConfig.McuSocket.port;
        }

        public McuConnection()
        {
            ConfigurationManager manager = new ConfigurationManager();
            McuConnectionConfig connectionConfig = manager.ReadConfig<McuConnectionConfig>(new McuConnectionConfig());
            if(connectionConfig.McuSocket.ip is null)
            {
                connectionConfig.McuSocket.ip = (IPAddress.Parse("192.168.140.133"));
                connectionConfig.McuSocket.port = 1337;
            }
            _connectionInfo.ip = connectionConfig.McuSocket.ip;
            _connectionInfo.port = connectionConfig.McuSocket.port;
        }
        public McuMessage Connect()
        {
            McuMessage msg = new McuMessage(InstructionCodes.CreateConnection); //  create object for the response
            Byte[] respBuffer = new byte[256];
            
            if (Connected)
            {
                msg.Response = InstructionResponses.CreatedConnection;  //  mcu already connected, just say everything is ok
                return msg;
            }
            
            try
            {
                if(_client is null)
                {
                    _client = new TcpClient(_connectionInfo.ip.ToString(), _connectionInfo.port);
                    _connection = _client.GetStream();
                }
                
                _connection.Write(Encoding.ASCII.GetBytes(new char[]{Convert.ToChar(InstructionCodes.CreateConnection)}));
                var bytes = _connection.Read(respBuffer,0,respBuffer.Length);

                if (bytes > 1)
                {
                    Console.Error.WriteLine(Encoding.Default.GetString(respBuffer));
                    throw new Exception("response is larger than expected");    //  basically jump to the catch block
                    
                } else if (Convert.ToByte(respBuffer[0]) == (byte) InstructionResponses.CreatedConnection)  //  mcu says connection is ok.
                {
                    msg.Response = InstructionResponses.CreatedConnection;  //  Connection was made
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                msg.Response = InstructionResponses.ConnectionError;    //  Warn it went wrong
                msg.ErrorResponse = e.Message;
                return msg;
            }

            Connected = true;
            return msg;
        }

        //  close the connection with the µ-c
        public void Disconnect()
        {
            _connection.Close();
            _client.Close();
            Connected = false;
        }

        //  send string to mcu, this is dangerous since this can have unpredictable behaviour
        public TcpResponseCode SendString(string msg)
        {
            if (_client.Connected)
            {
                try
                {
                    _connection.Write(Encoding.ASCII.GetBytes(msg));
                }
                catch (SocketException e)
                {
                    Console.Error.WriteLine(e.Message);
                    return TcpResponseCode.SocketWriteFailed;
                }

                return TcpResponseCode.Succes;
            }

            return TcpResponseCode.EndpointNotConnected;
        }
        
        //  sends opcode to mcu, and returns object containing mcu's response
        public McuMessage SendInstructionCode(InstructionCodes code)
        {
            McuMessage msg = new McuMessage(code);
            byte[] respBuffer = new byte[256];

            if (_client.Connected)
            {
                try
                {
                    _connection.Write(Encoding.ASCII.GetBytes(msg.OpCodeToCharArray()));
                    //var bytes = _connection.Read(respBuffer, 0, respBuffer.Length);
                    
                    if (code is InstructionCodes.GetCalibrationResult or InstructionCodes.GetTotalCapacity or InstructionCodes.GetRemainingBatteryCharge)
                    {

                        msg.ParsedData = Receive(); //  TODO verify this, and keep up to date with comm with mcu

                    }
                }
                catch (Exception e)
                {
                    
                    msg.ErrorResponse = e.Message;
                    Console.Error.WriteLine(e.Message);
                    throw new Exception(e.ToString());
                }
                
            }
            return msg;
        }

        public string Receive()
        {
           
            byte[] respBuffer = new byte[256];

            if (_client.Connected)
            {
                try
                {
                    int responseByte = 0; //  byte that will store the response
                    int index = 0;
                    
                    do
                    {
                        responseByte = _connection.ReadByte();
                        respBuffer[index] = Convert.ToByte(responseByte);
                        index++;

                    } while (responseByte is not -1 && ((char)responseByte) is not '\0');   //  do not stop reading untill we read a string termination or 'til the end of the stream

                    return Encoding.ASCII.GetString(respBuffer);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.Message);
                    throw new Exception(e.ToString());
                }
            }
            return String.Empty;    
        }
        
        //  deconstructor that closes the connection, if that hasn't yet happened
        ~McuConnection()
        {
            if (_client.Connected || _client.Client.Connected)
            {
                _connection.Close();
                _client.Close();
            }
        }
    }
}