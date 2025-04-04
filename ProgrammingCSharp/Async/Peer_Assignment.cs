using System;

namespace ProgrammingCSharp.Async
{
    public class Peer_Assignment
    {
        static string[] books = new string[5];
        static bool[] checkedOutStatus = new bool[5];
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
                        CheckoutBook();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please choose between 1 and 6.");
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
            Console.WriteLine("5. Checkout book");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option (1-6): ");
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
                    checkedOutStatus[i] = false; // Por defecto, el libro no está marcado como checkout.
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
                    checkedOutStatus[i] = false;
                    return true;
                }
            }
            return false;
        }

        static void ShowBooks()
        {
            Console.WriteLine("\nBooks available in the library:");
            bool hasBooks = false;

            for (int i = 0; i < books.Length; i++)
            {
                if (!string.IsNullOrEmpty(books[i]))
                {
                    string status = checkedOutStatus[i] ? " (Checked Out)" : "";
                    Console.WriteLine($"- {books[i]}{status}");
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

        static void CheckoutBook()
        {
            Console.Write("Enter the title of the book to checkout: ");
            string bookToCheckout = Console.ReadLine();
            bool found = false;

            for (int i = 0; i < books.Length; i++)
            {
                if (!string.IsNullOrEmpty(books[i]) && books[i].Equals(bookToCheckout, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    if (checkedOutStatus[i])
                    {
                        Console.WriteLine($"Book '{bookToCheckout}' is already checked out.");
                    }
                    else
                    {
                        checkedOutStatus[i] = true;
                        Console.WriteLine($"Book '{bookToCheckout}' has been successfully checked out.");
                    }
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Book '{bookToCheckout}' is not available in the library.");
            }
        }
    }
}
