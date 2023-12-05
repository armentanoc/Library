
namespace Library.ManagementSystem.Helper
{
    internal class OrderBooks
    {
        public static List<Dictionary<string, string>> Run(List<Dictionary<string, string>> bookList)
        {
            bookList = bookList.OrderBy(book => int.Parse(book["id"])).ToList();
            return bookList;
        }

    }
}
