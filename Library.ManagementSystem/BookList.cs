public class BookList
{
    private static int bookCounter = 1;
    public static List<Dictionary<string, string>> InitializeAllBooks()
    {
        var allBooks = new List<Dictionary<string, string>>
        {
            CreateBook("Dom Casmurro", "Machado de Assis", "1899", "Romance"),
            CreateBook("One Hundred Years of Solitude", "Gabriel García Márquez", "1967", "Realismo Mágico"),
            CreateBook("1984", "George Orwell", "1949", "Ficção Distópica"),
            CreateBook("The Great Gatsby", "F. Scott Fitzgerald", "1925", "Clássico"),
            CreateBook("Pride and Prejudice", "Jane Austen", "1813", "Clássico"),
            CreateBook("The Catcher in the Rye", "J.D. Salinger", "1951", "Ficção"),
            CreateBook("The Hobbit", "J.R.R. Tolkien", "1937", "Fantasia"),
            CreateBook("The Lord of the Rings", "J.R.R. Tolkien", "1954-1955", "Fantasia"),
            CreateBook("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", "1997", "Fantasia"),
            CreateBook("The Da Vinci Code", "Dan Brown", "2003", "Suspense")

        };

        return allBooks;
    }
    public static List<Dictionary<string, string>> InitializeBorrowedBooks()
    {
        return new List<Dictionary<string, string>>();
    }
    public static Dictionary<string, string> CreateBook(string title, string author, string year, string genre)
    {
        string id = bookCounter.ToString("D4");
        bookCounter++;
        return new Dictionary<string, string>
        {
            {"id", id},
            {"title", title},
            {"author", author},
            {"year", year},
            {"genre", genre}
        };
    }

}