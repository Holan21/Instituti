using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FiveAPI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Write text:");
            var text = Console.ReadLine();
            Console.WriteLine(await Coding(text));
            Console.ReadKey();
        }
        public static async Task<string> Coding(string text)
        {
            string result = "";
            await Task.Run(() =>
            {
                for (int i = 0; i < text.Length; i++)
                {
                    result += (char) ((int)(text.ElementAt<char>(i)) - 2);
                }
            });
            return result;
        }
    }
}
