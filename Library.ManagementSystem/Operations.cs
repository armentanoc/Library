using Library.ManagementSystem.Helper;

namespace Library.ManagementSystem
{
    public class Operations
    {
        private List<Dictionary<string, string>> allBooks;
        private List<Dictionary<string, string>> borrowedBooks;
        private List<Dictionary<string, string>> availableBooks;

        public Operations()
        {
            allBooks = BookList.InitializeAllBooks();
            borrowedBooks = BookList.InitializeBorrowedBooks();
            availableBooks = allBooks.ToList();
        }
        public void BorrowBook()
        {
            string bookId = GetInput.NonNullString("\nDigite o ID do livro que deseja pegar emprestado: ");

            Dictionary<string, string> selectedBook = GetBookById.Run(availableBooks, bookId);

            if (selectedBook != null)
            {
                availableBooks.Remove(selectedBook);

                DateTime dueDate = DateTime.Now.AddDays(14);
                selectedBook["dueDate"] = dueDate.ToString("dd/MM/yyyy");
                borrowedBooks.Add(selectedBook);
                borrowedBooks = OrderBooks.Run(borrowedBooks);
                Console.WriteLine($"Livro '{selectedBook["title"]}' emprestado com sucesso.");
            }
            else
            {
                Console.WriteLine("Livro não encontrado ou já emprestado.");
            }
        }
        public void ReturnBook()
        {
            string bookId = GetInput.NonNullString("\nDigite o ID do livro que deseja devolver: "); 

            Dictionary<string, string> selectedBook = GetBookById.Run(borrowedBooks, bookId);

            if (selectedBook != null)
            {
                borrowedBooks.Remove(selectedBook);
                availableBooks.Add(selectedBook);
                availableBooks = OrderBooks.Run(availableBooks);
                Console.WriteLine($"Livro '{selectedBook["title"]}' devolvido com sucesso.");
            }
            else
            {
                Console.WriteLine("Livro não encontrado ou não foi emprestado.");
            }
        }
        public void AddNewBook()
        {
            try
            {
                string title = GetInput.NonNullString("\nDigite o título do novo livro: ");
                string author = GetInput.NonNullString("Digite o autor do novo livro: ");
                string year = GetInput.NonNullString("Digite o ano de publicação do novo livro: ");
                string genre = GetInput.NonNullString("Digite o gênero do novo livro: ");

                var newBook = BookList.CreateBook(title, author, year, genre);

                availableBooks.Add(newBook);
                availableBooks = OrderBooks.Run(availableBooks);

                Console.WriteLine($"Livro '{title}' adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar novo livro: {ex.Message}");
            }
        }
        public void DeleteBook()
        {
            string bookId = GetInput.NonNullString("\nDigite o ID do livro que deseja remover: ");
            var bookToRemove = GetBookById.Run(availableBooks, bookId); //searching in available books

            try
            {
                if (bookToRemove != null)
                {
                    allBooks.Remove(bookToRemove);
                    availableBooks.Remove(bookToRemove);
                    Console.WriteLine($"Livro '{bookToRemove["title"]}' removido com sucesso.");
                }
                else
                {
                    Console.WriteLine("Livro não encontrado. Somente um livro disponível pode ser removido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover livro: {ex.Message}");
            }
        }
        public void ShowStatistics()
        {
            try
            {
                Statistics.ShowAll(allBooks, availableBooks, borrowedBooks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao exibir estatísticas: {ex.Message}");
            }
        }
        public void DisplayBooks(string category)
        {
            try
            {
                switch (category)
                {
                    case "Livros Disponíveis":
                        Display.AvailableBooks(availableBooks, category);
                        break;
                    case "Livros Emprestados":
                        Display.BorrowedBooks(borrowedBooks, category);
                        break;
                    default:
                        Console.WriteLine("Categoria inválida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao exibir livros: {ex.Message}");
            }
        }
        public void SearchByAuthorOrGenre()
        {
            try
            {
                string searchTerm = GetInput.NonNullString("\nDigite o autor ou gênero que deseja buscar: ").ToLower();

                var matchingBooks = allBooks.Where(book =>
                    book["author"].ToLower().Contains(searchTerm) || book["genre"].ToLower().Contains(searchTerm)
                ).ToList();

                if (matchingBooks.Any())
                {
                    Display.AvailableBooks(matchingBooks, "Livros Encontrados");
                    AskToBorrowBook(matchingBooks);
                }
                else
                {
                    Console.WriteLine("Nenhum livro encontrado para o autor ou gênero especificado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao realizar busca: {ex.Message}");
            }
        }
        void AskToBorrowBook(List<Dictionary<string, string>> matchingBooks)
        {
            string response = 
                GetInput.NonNullString("\nDeseja pegar emprestado algum desses livros? (S/N): ")
                    .Trim().ToUpper();

            if (response == "S")
            {
                BorrowBook();
            }
            else if (response != "N")
            {
                Console.WriteLine("Opção inválida. Retornando ao menu.");
            }
        }

    }
}
