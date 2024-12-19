using System.Diagnostics;
using System.Xml.Linq;

public class Library
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }
        public override string ToString()
        {
            return $"{Id,-5} | {Title,-20} | {Author,-15} | {ISBN,-10:C} | {IsAvailable,-6}";
        }

        public Book()
        {
            
        }

        public Book(int id, string title, string author, string isbn, bool isAvailable)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = isbn;
            IsAvailable = true;
        }
    }
    private List<Book> Books;

    public Library()
    {
        Books = new List<Book>()
        {
            new Book(){Author = "abolfazl",ISBN = "123456",IsAvailable = false,Title = "book1",Id = 1},
            new Book(){Author = "shadi",ISBN = "34442",IsAvailable = false,Title = "book2",Id =2},
            new Book(){Author = "reza",ISBN = "345456",IsAvailable = true,Title = "book3",Id =3},
            new Book(){Author = "ali",ISBN = "34553543",IsAvailable = true,Title = "book1",Id =4}
        };
    }

    public List<Book> GetBooks()
    {
        return Books;

    }

    public void AddBook(Book book)
    {
        if (book != null &&
            !string.IsNullOrEmpty(book.Title) &&
            !string.IsNullOrEmpty(book.Author) &&
            !string.IsNullOrEmpty(book.ISBN))
        {
            Books.Add(book);
            Console.WriteLine("Your Book added successfully");

        }
        else
            Console.WriteLine("Your Book field");
    }

    public void BorrowBook(string title)
    {
        bool statusFindBook = false;
        ReturnBook(title, ref statusFindBook,true);

        if (!statusFindBook)
        {
            Console.WriteLine("not found book");
        }
    }

    public Book ReturnBook(string title, ref bool statusFindBook, bool changeStatus = false)
    {
        foreach (var item in Books)
        {
            if (item.Title.Equals(title))
            {
                item.IsAvailable = changeStatus ? !item.IsAvailable : item.IsAvailable;
                statusFindBook = true;
                if (changeStatus)
                {
                    Console.WriteLine(" book has  chage status");
                }
                return item;
            }
        }

        return null;
    }

}