using FormatOutput;

namespace UserInput
{
    public class Receive
    {
        static void DetermineChoice()
        {
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    DisplayDict.DisplayBooks(availableBooks, "Livros Disponíveis");
                    break;
                case "2":
                    Console.Clear();
                    DisplayDict.DisplayBooks(borrowedBooks, "Livros Emprestados");
                    break;
                case "3":
                    BorrowBook();
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
                case "4":
                    ReturnBook();
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
                case "5":
                    AddNewBook();
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
                case "6":
                    DeleteBook();
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
                case "7":
                    Console.Clear();
                    Statistics.ShowAll(availableBooks, borrowedBooks);
                    break;
                case "8":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
            }
        }
    }
