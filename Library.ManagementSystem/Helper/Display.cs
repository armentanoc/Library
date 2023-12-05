
namespace Library.ManagementSystem

{
    internal class Display
    {
        public static void Menu()
        {
            Console.WriteLine("\nLIBRARY MANAGEMENT SYSTEM\n");
            Console.WriteLine("1. Consultar livros disponíveis");
            Console.WriteLine("2. Consultar livros emprestados");
            Console.WriteLine("3. Pegar livro emprestado");
            Console.WriteLine("4. Devolver livro");
            Console.WriteLine("5. Adicionar novo livro");
            Console.WriteLine("6. Excluir livro");
            Console.WriteLine("7. Pesquisar por autor ou gênero");
            Console.WriteLine("8. Estatísticas");
            Console.WriteLine("9. Sair");

            Console.Write("\nEscolha uma opção: ");
        }

        public static void AvailableBooks(IEnumerable<Dictionary<string, string>> availableBooks, string title = "Livros")
        {
            Console.WriteLine($"\n{title}:\n");
            foreach (var book in availableBooks)
            {
                Console.WriteLine($"ID {book["id"]} => Título: {book["title"]}, Autor: {book["author"]}, Gênero: {book["genre"]}.");
            }
        }

        public static void BorrowedBooks(IEnumerable<Dictionary<string, string>> borrowedBooks, string title = "Livros")
        {
            Console.WriteLine($"\n{title}:\n");
            foreach (var book in borrowedBooks)
            {
                Console.WriteLine($"ID {book["id"]} => Título: {book["title"]}, Autor: {book["author"]}, Gênero: {book["genre"]}, " +
                    $"Data de Entrega: {book["dueDate"]}.");
            }
        }
    }
}