using System;
using System.Collections.Generic;

public class ConsoleApp
{
    private Library library;

    public ConsoleApp()
    {
        library = new Library();
    }

    static void WriteInputOptions(CommonActions options)
    {
        Console.WriteLine("Input Options:");
        if (options.HasFlag(CommonActions.ReturnLoanedBook))
        {
            Console.WriteLine(" - \"r\" to mark as returned");
        }
        if (options.HasFlag(CommonActions.ExtendLoanedBook))
        {
            Console.WriteLine(" - \"e\" to extend the book loan");
        }
        if (options.HasFlag(CommonActions.RenewPatronMembership))
        {
            Console.WriteLine(" - \"m\" to extend patron's membership");
        }
        if (options.HasFlag(CommonActions.SearchPatrons))
        {
            Console.WriteLine(" - \"s\" for new search");
        }
        if (options.HasFlag(CommonActions.SearchBooks))
        {
            Console.WriteLine(" - \"b\" to check for book availability");
        }
        if (options.HasFlag(CommonActions.Quit))
        {
            Console.WriteLine(" - \"q\" to quit");
        }
        if (options.HasFlag(CommonActions.Select))
        {
            Console.WriteLine("Or type a number to select a list item.");
        }
    }

    static CommonActions ReadInputOptions(CommonActions options, out int optionNumber)
    {
        CommonActions action;
        optionNumber = 0;
        do
        {
            Console.WriteLine();
            WriteInputOptions(options);
            string? userInput = Console.ReadLine();

            action = userInput switch
            {
                "q" when options.HasFlag(CommonActions.Quit) => CommonActions.Quit,
                "s" when options.HasFlag(CommonActions.SearchPatrons) => CommonActions.SearchPatrons,
                "m" when options.HasFlag(CommonActions.RenewPatronMembership) => CommonActions.RenewPatronMembership,
                "e" when options.HasFlag(CommonActions.ExtendLoanedBook) => CommonActions.ExtendLoanedBook,
                "r" when options.HasFlag(CommonActions.ReturnLoanedBook) => CommonActions.ReturnLoanedBook,
                "b" when options.HasFlag(CommonActions.SearchBooks) => CommonActions.SearchBooks,
                _ when int.TryParse(userInput, out optionNumber) => CommonActions.Select,
                _ => CommonActions.Repeat
            };

            if (action == CommonActions.Repeat)
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        } while (action == CommonActions.Repeat);
        return action;
    }

    async Task<ConsoleState> PatronDetails()
{
    Console.WriteLine($"Name: {selectedPatronDetails.Name}");
    Console.WriteLine($"Membership Expiration: {selectedPatronDetails.MembershipEnd}");
    Console.WriteLine();
    Console.WriteLine("Book Loans:");
    int loanNumber = 1;
    foreach (Loan loan in selectedPatronDetails.Loans)
    {
        Console.WriteLine($"{loanNumber}) {loan.BookItem!.Book!.Title} - Due: {loan.DueDate} - Returned: {(loan.ReturnDate != null).ToString()}");
        loanNumber++;
    }

    CommonActions options = CommonActions.SearchPatrons | CommonActions.Quit | CommonActions.Select | CommonActions.RenewPatronMembership | CommonActions.SearchBooks;
    CommonActions action = ReadInputOptions(options, out int selectedLoanNumber);
    if (action == CommonActions.Select)
    {
        if (selectedLoanNumber >= 1 && selectedLoanNumber <= selectedPatronDetails.Loans.Count())
        {
            var selectedLoan = selectedPatronDetails.Loans.ElementAt(selectedLoanNumber - 1);
            selectedLoanDetails = selectedPatronDetails.Loans.Where(l => l.Id == selectedLoan.Id).Single();
            return ConsoleState.LoanDetails;
        }
        else
        {
            Console.WriteLine("Invalid book loan number. Please try again.");
            return ConsoleState.PatronDetails;
        }
    }
    else if (action == CommonActions.Quit)
    {
        return ConsoleState.Quit;
    }
    else if (action == CommonActions.SearchPatrons)
    {
        return ConsoleState.PatronSearch;
    }
    else if (action == CommonActions.RenewPatronMembership)
    {
        var status = await _patronService.RenewMembership(selectedPatronDetails.Id);
        Console.WriteLine(EnumHelper.GetDescription(status));
        // reloading after renewing membership
        selectedPatronDetails = (await _patronRepository.GetPatron(selectedPatronDetails.Id))!;
        return ConsoleState.PatronDetails;
    }
    else if (action == CommonActions.SearchBooks)
    {
        return await SearchBooks();
    }

    throw new InvalidOperationException("An input option is not handled.");
}

    public void SearchBooks() // New method added
    {
        Console.WriteLine("Enter the title of the book:");
        string title = Console.ReadLine();
        Book book = library.GetBookByTitle(title);

        if (book == null)
        {
            Console.WriteLine("Book not found.");
        }
        else if (book.IsAvailable)
        {
            Console.WriteLine($"{book.Title} is available for loan.");
        }
        else
        {
            Loan loan = library.GetLoanByBook(book);
            Console.WriteLine($"{book.Title} is loaned to another patron. The due date is {loan.DueDate}.");
        }
    }async Task<ConsoleState> SearchBooks()
{
    string? bookTitle = null;
    while (String.IsNullOrWhiteSpace(bookTitle))
    {
        Console.Write("Enter a book title to search for: ");
        bookTitle = Console.ReadLine();
    }

    // Perform book search logic here

    return ConsoleState.PatronDetails;
}
public class ConsoleApp
{
    // Existing fields...

    JsonData _jsonData;

    public ConsoleApp(ILoanService loanService, IPatronService patronService, IPatronRepository patronRepository, ILoanRepository loanRepository, JsonData jsonData)
    {
        _patronRepository = patronRepository;
        _loanRepository = loanRepository;
        _loanService = loanService;
        _patronService = patronService;
        _jsonData = jsonData;
    }

    // Existing methods...

    async Task<ConsoleState> SearchBooks()
    {
        string bookTitle = ReadBookTitle();

        Book? book = _jsonData.SearchBookByTitle(bookTitle);

        if (book == null)
        {
            Console.WriteLine($"No book found with title: {bookTitle}");
            return ConsoleState.PatronDetails;
        }

        Loan? loan = _jsonData.Loans?.FirstOrDefault(l => l.BookItemId == book.Id && l.ReturnDate == null);

        if (loan == null)
        {
            Console.WriteLine($"{book.Title} is available for loan.");
        }
        else
        {
            Console.WriteLine($"{book.Title} is on loan to another patron. The return due date is {loan.DueDate}.");
        }

        return ConsoleState.PatronDetails;
    }

    // Existing methods...
}

public Book? SearchBookByTitle(string title)
{
    return Books?.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
}

    // Other methods like ViewBooks, BorrowBook, ReturnBook, etc.
}