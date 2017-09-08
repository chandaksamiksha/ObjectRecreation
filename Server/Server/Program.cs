using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPAddress ipAdress = IPAddress.Parse("172.16.14.107");
                TcpListener listener = new TcpListener(ipAdress, 8000);
                listener.Start();
                Console.WriteLine("Server running - Port: 8000");
                Console.WriteLine("Local end point:" + listener.LocalEndpoint);
                Console.WriteLine("Waiting for connections...");

                TcpClient client = listener.AcceptTcpClient();
                byte[] b = new byte[client.ReceiveBufferSize];
                NetworkStream stream = client.GetStream();
                int bytes = stream.Read(b, 0, client.ReceiveBufferSize);
                string outputString = Encoding.ASCII.GetString(b, 0, bytes);
                Console.WriteLine("Recieved...");
                var person = JsonConvert.DeserializeObject<Person>(outputString);
                Console.WriteLine("Output:\n"+"Name:"+ person.Name +"\tSurname :"+person.Surname+"\tDate-Of-Birth :"+person.DateOfBirth+"\tMobile Number:"+person.MobileNumber+"\tTown:"+person.Town);
                client.Close();
                listener.Stop();
                Console.ReadKey();
            }
            catch
            {
            }
    }
    }
}