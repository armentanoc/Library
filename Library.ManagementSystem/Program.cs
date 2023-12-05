
namespace Library.ManagementSystem;

class Program
{
    static Operations librarySystem = new Operations();

    static void Main()
    {

        while (true)
        {
            Display.Menu();
            string? choice = Console.ReadLine();
            Console.Clear();
            DetermineChoice(choice);
        }
    }

    static void DetermineChoice(string? choice)
    {
        switch (choice)
        {
            case "1":
                librarySystem.DisplayBooks("Livros Disponíveis");
                break;
            case "2":
                librarySystem.DisplayBooks("Livros Emprestados");
                break;
            case "3":
                librarySystem.DisplayBooks("Livros Disponíveis");
                librarySystem.BorrowBook();
                break;
            case "4":
                librarySystem.DisplayBooks("Livros Emprestados");
                librarySystem.ReturnBook();
                break;
            case "5":
                librarySystem.AddNewBook();
                break;
            case "6":
                librarySystem.DisplayBooks("Livros Disponíveis");
                librarySystem.DeleteBook();
                break;
            case "7":
                librarySystem.SearchByAuthorOrGenre();
                break;
            case "8":
                librarySystem.ShowStatistics();
                break;
            case "9":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }
}