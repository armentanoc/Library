using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ManagementSystem.Helper
{
    internal class GetBookById
    {
        public static Dictionary<string, string>? Run(IEnumerable<Dictionary<string, string>> books, string bookId)
        {
            return books.FirstOrDefault(book => book["id"] == bookId);
        }
    }
}
