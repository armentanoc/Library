
internal class Statistics
{        
    public static void ShowAll(List<Dictionary<string, string>> allBooks, List<Dictionary<string, string>> availableBooks, List<Dictionary<string, string>> borrowedBooks)
    { 
            Console.WriteLine($"\nEstatísticas:\n");
            Console.WriteLine($"Total de livros: {allBooks.Count}");
            Console.WriteLine($"Livros disponíveis: {availableBooks.Count}");
            Console.WriteLine($"Livros emprestados: {borrowedBooks.Count}");
    }
}