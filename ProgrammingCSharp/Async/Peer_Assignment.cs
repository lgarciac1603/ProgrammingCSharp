using System;

namespace ProgrammingCSharp.Async
{
    public class Peer_Assignment
    {
        static string[] books = new string[5];
        static int borrowedBooksCount = 0;
        const int borrowingLimit = 3;

        public static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                DisplayMenu();
                string option = Console.ReadLine().ToLower();

                switch (option)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        RemoveBook();
                        break;
                    case "3":
                        ShowBooks();
                        break;
                    case "4":
                        SearchBook();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please choose between 1 and 5.");
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
            Console.WriteLine("4. Search book");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");
        }

        static void AddBook()
        {
            if (IsLibraryFull())
            {
                Console.WriteLine("The library is full. No more books can be added.");
                return;
            }

            if (borrowedBooksCount >= borrowingLimit)
            {
                Console.WriteLine($"You have reached the borrowing limit of {borrowingLimit} books.");
                return;
            }

            Console.Write("Enter the title of the book to add: ");
            string newBook = Console.ReadLine();

            if (AddBookToArray(newBook))
            {
                borrowedBooksCount++;
                Console.WriteLine($"Book '{newBook}' added successfully.");
            }
            else
            {
                Console.WriteLine("Error adding the book.");
            }
        }

        static bool IsLibraryFull()
        {
            foreach (var book in books)
            {
                if (string.IsNullOrEmpty(book))
                {
                    return false;
                }
            }
            return true;
        }

        static bool AddBookToArray(string newBook)
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

        static void RemoveBook()
        {
            if (IsLibraryEmpty())
            {
                Console.WriteLine("The library is empty. No books to remove.");
                return;
            }

            Console.Write("Enter the title of the book to remove: ");
            string bookToRemove = Console.ReadLine();

            if (RemoveBookFromArray(bookToRemove))
            {
                borrowedBooksCount--;
                Console.WriteLine($"Book '{bookToRemove}' removed successfully.");
            }
            else
            {
                Console.WriteLine("The book is not in the collection.");
            }
        }

        static bool IsLibraryEmpty()
        {
            foreach (var book in books)
            {
                if (!string.IsNullOrEmpty(book))
                {
                    return false;
                }
            }
            return true;
        }

        static bool RemoveBookFromArray(string bookToRemove)
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

        static void ShowBooks()
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

        static void SearchBook()
        {
            Console.Write("Enter the title of the book to search: ");
            string bookToSearch = Console.ReadLine();
            bool found = false;

            foreach (var book in books)
            {
                if (!string.IsNullOrEmpty(book) && book.Equals(bookToSearch, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Book '{bookToSearch}' is available in the library.");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Book '{bookToSearch}' is not available in the library.");
            }
        }
    }
}
