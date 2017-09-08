using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Name :");
            string name = Console.ReadLine();
            Console.WriteLine("\nEnter Surname :");
            string surname = Console.ReadLine();
            Console.WriteLine("\nEnter Date-Of-Birth :");
            DateTime dob = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("\nEnter Mobile Number :");
            long number = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("\nEnter Home-Town :");
            string town = Console.ReadLine();

            TcpClient client = new TcpClient();
                Console.WriteLine("\nConnecting");
                client.Connect("172.16.14.107", 8000);
                Console.WriteLine("\nConnected");
                Stream stream = client.GetStream();
                Person person = new Person(name,surname,dob,number,town);
                string output = JsonConvert.SerializeObject(person);
                byte[] bytearray = Encoding.ASCII.GetBytes(output);
                Console.WriteLine("\nSending...");
                stream.Write(bytearray, 0, bytearray.Length);
                client.Close();
                stream.Close();
                Console.ReadKey();
            
        }
    }
}
