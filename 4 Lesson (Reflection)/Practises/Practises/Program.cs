using System.Reflection;

namespace Practises
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var computer = new Computer();
            Type computerType = computer.GetType();
            Console.WriteLine($"{computerType.FullName}\n");
            TypeInfo computerTypeInfo = computerType.GetTypeInfo();
            var fields = computerTypeInfo.GetFields();

            for (int i = 0; i < fields.Length; i++)
            {
                Console.WriteLine(fields[i]);

            }
            Console.WriteLine();

            var computerMemberInfo = computerType.GetMembers();

            for (int i = 0; i < computerMemberInfo.Length; i++)
            {
                Console.WriteLine(computerMemberInfo[i]);
            }

            Console.WriteLine();

            var computerFieldsInfo = computerType.GetFields();

            for (int i = 0; i < computerFieldsInfo.Length; i++)
            {
                Console.WriteLine($"Type:{computerFieldsInfo[i]}\tAttributes:{computerFieldsInfo[i].Attributes}");
            }

            Console.WriteLine();

            var computerMethodsInfo = computerType.GetMethods();

            for (int i = 0; i < computerMethodsInfo.Length; i++)
            {
                Console.WriteLine($"{computerMethodsInfo[i]}");
            }

            computerMethodsInfo[0].Invoke(computer , null);
        }
    }
}
