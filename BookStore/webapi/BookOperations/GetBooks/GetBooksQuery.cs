using System;
using System.Collections.Generic;
using System.Linq;
using webapi.Common;
using webapi.DBOperetions;

namespace webapi.BookOperations.GetBooks
{

    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public int BookId { get; set; }

        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public List<BooksViewModel> Handle()
        {

            var booklist = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();

            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach (var book in booklist)
            { 
                vm.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/MM /yyy"),
                    PageCount = book.PageCount

                });
            }
            return vm;

        }

        public class BooksViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }

        }
    }


}
  