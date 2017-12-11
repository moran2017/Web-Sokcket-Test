using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WebSokcket.Test
{
    class Program
    {
        static Queue<String> Cola;
        static void Main(string[] args)
        {
            Cola = new Queue<String>();
            Thread hiloPrincipal = new Thread(Procesar);
            hiloPrincipal.Start();
            Thread hiloProcesar = new Thread(ProcesarInformacion);
            hiloProcesar.Start();
        }

        static Byte[] ConverAsciiToEbcdic(Byte[] asciiData)
        {
            Encoding ascii = Encoding.ASCII;
            Encoding ebcdic = Encoding.GetEncoding("IBM037");
            return Encoding.Convert(ascii, ebcdic, asciiData);
        }

        static void ProcesarInformacion()
        {
            while (Cola.Count != 0)
            {
                String strTrama = Cola.Dequeue();
                Byte[] arrByteRequest = Encoding.ASCII.GetBytes(strTrama);
                Byte[] arrByteEbcdic = ConverAsciiToEbcdic(arrByteRequest);
                Console.WriteLine(BitConverter.ToString(arrByteEbcdic));
            }

        }

        static void Procesar()
        {

            while (true)
            {
                try
                {
                    String strRequest = "1804";
                    Cola.Enqueue(strRequest);
                    Thread.Sleep(500);

                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
