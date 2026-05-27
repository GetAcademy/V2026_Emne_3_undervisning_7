namespace ClaimTheSquareAfter;

public class App
{
    private readonly Board _board;

    public App()
    {
        _board = new Board();
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Claim the Square");
            Console.WriteLine();
            ShowBoard();
            Console.WriteLine();
            Console.WriteLine("1. Velg rute");
            Console.WriteLine("2. Avslutt");
            Console.Write("Hva vil du gjore? ");

            var choice = Console.ReadLine();
            if (choice == "1")
            {
                ChooseSquare();
            }
            else if (choice == "2")
            {
                return;
            }
        }
    }

    private void ChooseSquare()
    {
        Console.WriteLine();
        var index = ReadSquareIndex();
        var text = ReadText();

        Console.WriteLine();
        Console.WriteLine("Velg forgrunnsfarge:");
        var foreColor = ColorMenu.ReadColor();

        Console.WriteLine();
        Console.WriteLine("Velg bakgrunnsfarge:");
        var backColor = ColorMenu.ReadColor();

        var result = _board.ClaimSquare(index, text, foreColor, backColor);

        Console.WriteLine();
        Console.WriteLine(result.IsSuccess ? result.SuccessMessage : result.ErrorMessage);
        Console.WriteLine();
        Console.Write("Trykk Enter for aa fortsette...");
        Console.ReadLine();
    }

    private void ShowBoard()
    {
        for (var row = 0; row < Board.Height; row++)
        {
            for (var col = 0; col < Board.Width; col++)
            {
                var index = row * Board.Width + col;
                ShowSquare(_board.GetSquare(index));
            }

            Console.WriteLine();
        }
    }

    private static void ShowSquare(Square square)
    {
        var oldForeColor = Console.ForegroundColor;
        var oldBackColor = Console.BackgroundColor;

        if (square.IsEmpty())
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($" {square.Index,2}    ");
        }
        else
        {
            Console.ForegroundColor = square.ForeColor!.ConsoleColor;
            Console.BackgroundColor = square.BackColor!.ConsoleColor;
            Console.Write($" {ShortText(square.Text!),-5} ");
        }

        Console.ForegroundColor = oldForeColor;
        Console.BackgroundColor = oldBackColor;
    }

    private static int ReadSquareIndex()
    {
        while (true)
        {
            Console.Write("Velg rute fra 0 til 63: ");
            var input = Console.ReadLine();

            var isNumber = int.TryParse(input, out var index);
            if (isNumber && index is >= 0 and < Board.SquareCount)
            {
                return index;
            }

            Console.WriteLine("Ugyldig rute. Skriv et tall fra 0 til 63.");
        }
    }

    private static string ReadText()
    {
        while (true)
        {
            Console.Write("Tekst: ");
            var text = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            Console.WriteLine("Teksten kan ikke vaere tom.");
        }
    }

    private static string ShortText(string text)
    {
        if (text.Length <= 5)
        {
            return text;
        }

        return text.Substring(0, 5);
    }
}
