internal class Program
{
    private static void Main(string[] args)
    {
        string exit;
        do
        {
            Console.Clear();
            Console.Write("\nFunctions...\n" +
                "1: Lorem ipsum text output from file with word limit\n" +
                "2: Summarize two number\n" +
                "Choose function:");

            int choseUser = int.Parse(Console.ReadLine());

            switch (choseUser)
            {
                case 1:
                    Console.Write("\nChoose limit word:");
                    int countWord = int.Parse(Console.ReadLine());
                    Console.WriteLine($"\nResult:{GetText(countWord)}");
                    break;
                case 2:
                    Console.Write("\nWrite first number:");
                    int firstNumber = int.Parse(Console.ReadLine());
                    Console.Write("Write second number:");
                    int secondNumber = int.Parse(Console.ReadLine());
                    Console.Write($"\nResult:{Sum(firstNumber, secondNumber)}");
                    break;
                default:
                    Console.WriteLine("Function not found");
                    break;
            }
            Console.Write("\nIf you want exit write e:");
            exit = Console.ReadLine();
        } while (exit.ToLower().Trim() != "e");
        
    }
    private static string GetText(int countWords)   
    {
        string result = string.Empty;
        var text = File.ReadAllText("Text.txt");

        char[] emptyChars = { ' ', '\n', '\r' };
        string[] words = text.Split(emptyChars);

        for (int i = 0; i < countWords + 1; i++)
        {
            if (words[i] != string.Empty)   
            result += words[i] + " ";
            else
            {
                i++;
                countWords++;
            }
        }

        return result;
    }

    private static int Sum(int a, int b) => a + b;



}