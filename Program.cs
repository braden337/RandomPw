using System;
using System.IO;
using System.Net;
using System.Text;


namespace RandomPw
{
    class Program
    {
        static void Main(string[] args)
        {
            string randomORG = "https://www.random.org/passwords/?num=100&len=24&format=plain&rnd=new";
            string[] passwords = new string[100];

            Random rand = new Random();

            int chosen = rand.Next(passwords.Length);

            WebRequest req = WebRequest.Create(randomORG);
            WebResponse res = req.GetResponse();

            Stream stream = res.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);

            char[] line = new char[25];

            // Read 25 characters at a time (passwords are 24 characters plus a new line)
            int current = 0;

            while (current < passwords.Length)
            {
                reader.Read(line, 0, 25);
                passwords[current++] = new String(line, 0, 24);
            }

            Console.WriteLine("Password #{0} is {1}", chosen + 1, passwords[chosen]);
        }
    }
}