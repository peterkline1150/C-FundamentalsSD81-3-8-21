using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Greeter
    {
        public void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
        public void SayHello()
        {
            Console.WriteLine("Hello");
        }

        Random _random = new Random();
        public void GetRandomGreeting()
        {
            string[] availableGreetings = new string[] { "Good morning", "What's up", "What's up dawg", "Howdy" };
            int randomNumber = _random.Next(0, availableGreetings.Length);
            string randomGreeting = availableGreetings.ElementAt(randomNumber);
            Console.WriteLine($"{randomGreeting}");
        }
    }
}
