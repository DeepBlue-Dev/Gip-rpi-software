using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace IPC.StreamString
{
    public class StreamString
    {
        private Stream ioStream;

        public StreamString(Stream ioStream)
        {
            this.ioStream = ioStream;
        }

        public string ReadString()
        {
            StreamReader reader = new StreamReader(ioStream);
            StringBuilder sBuilder = new StringBuilder();
            int readByte = 0;
            if (!ioStream.CanRead) { return null; }

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

        public string WriteString([System.Diagnostics.CodeAnalysis.NotNull] string outString)
        {
            if (!ioStream.CanWrite || outString is null || outString.Length < 1) { return null; }

            try
            {
                ioStream.Write(Encoding.Convert(Encoding.Default, Encoding.ASCII, Encoding.Default.GetBytes(outString)));
                ioStream.WriteByte(0);
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
