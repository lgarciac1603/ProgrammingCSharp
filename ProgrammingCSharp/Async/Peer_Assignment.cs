namespace ProgrammingCSharp.Async
{
    public class Peer_Assignment
    {
        public static void Main(string[] args)
        {
            string[] books = new string[5];
            bool running = true;

            while (running)
            {
                Console.Clear();
                DisplayMenu();
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddBook(books);
                        break;
                    case "2":
                        RemoveBook(books);
                        break;
                    case "3":
                        ShowBooks(books);
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please choose between 1 and 4.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Program terminated.");
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Library Management System:");
            Console.WriteLine("1. Add book");
            Console.WriteLine("2. Remove book");
            Console.WriteLine("3. Show books");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option (1-4): ");
        }

        static void AddBook(string[] books)
        {
            Console.Write("Enter the title of the book to add: ");
            string newBook = Console.ReadLine();

            if (AddBookToArray(books, newBook))
            {
                Console.WriteLine($"Book '{newBook}' added successfully.");
            }
            else
            {
                Console.WriteLine("The library is full. No more books can be added.");
            }
        }

        static bool AddBookToArray(string[] books, string newBook)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (string.IsNullOrEmpty(books[i]))
                {
                    books[i] = newBook;
                    return true;
                }
            }
            return false;
        }

        static void RemoveBook(string[] books)
        {
            Console.Write("Enter the title of the book to remove: ");
            string bookToRemove = Console.ReadLine();

            if (RemoveBookFromArray(books, bookToRemove))
            {
                Console.WriteLine($"Book '{bookToRemove}' removed successfully.");
            }
            else
            {
                Console.WriteLine("The book is not in the collection.");
            }
        }

        static bool RemoveBookFromArray(string[] books, string bookToRemove)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null && books[i].Equals(bookToRemove, StringComparison.OrdinalIgnoreCase))
                {
                    books[i] = null;
                    return true;
                }
            }
            return false;
        }

        static void ShowBooks(string[] books)
        {
            Console.WriteLine("\nBooks available in the library:");
            bool hasBooks = false;
            foreach (var book in books)
            {
                if (!string.IsNullOrEmpty(book))
                {
                    Console.WriteLine($"- {book}");
                    hasBooks = true;
                }
            }

            if (!hasBooks)
            {
                Console.WriteLine("There are no books in the library.");
            }
        }
    }
}
