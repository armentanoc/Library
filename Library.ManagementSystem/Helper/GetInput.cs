
namespace Library.ManagementSystem.Helper
{
    internal class GetInput
    {
        public static string NonNullString(string prompt)
        {
            string userInput;
            do
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();
            } while (string.IsNullOrEmpty(userInput));

            return userInput;
        }

    }
}
