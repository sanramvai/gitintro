using System;
using System.Net;


namespace UseHttpClent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a valid web address: ");
            string url = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(url))
            {
            }
            url = "https://world.episerver.com/cms/?q=pagetype";

            var uri = new Uri(url);
            Console.WriteLine($"URL: {url}");
            Console.WriteLine($"Scheme: {uri.Scheme}");
            Console.WriteLine($"Port: {uri.Port}");
            Console.WriteLine($"Host: {uri.Host}");
            Console.WriteLine($"Path: {uri.AbsolutePath}");
            Console.WriteLine($"Query: {uri.Query}");
            IPHostEntry entry = Dns.GetHostEntry(uri.Host);
            Console.WriteLine($"{entry.HostName} has following address");
            foreach(IPAddress iPAddress in entry.AddressList)
            {

                Console.WriteLine($"{iPAddress}");
            }
            byte[] binaryObject = new byte[128];
            (new Random()).NextBytes(binaryObject);
            for(int index=0;index<binaryObject.Length;index++)
            {
                Console.Write(binaryObject[index]);
            }
           
            // convert to Base64 string and output as text
            string encoded = Convert.ToBase64String(binaryObject);
            Console.WriteLine($"Binary Object as Base64: {encoded}");
            int age = int.Parse("28");
            DateTime birthday = DateTime.Parse("1 March 2009");
            WriteLine($"I was born {age} years ago.");
            WriteLine($"My birthday is {birthday}.");
            WriteLine($"My birthday is {birthday:D}.");
        }
    }
}
