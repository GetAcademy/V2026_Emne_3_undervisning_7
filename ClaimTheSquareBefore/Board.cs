namespace ClaimTheSquareBefore;

public class Board
{
    public const int Width = 8;
    public const int Height = 8;
    public const int SquareCount = Width * Height;

    private readonly Square[] _squares;

    public Board()
    {
        _squares = new Square[SquareCount];

        for (var index = 0; index < _squares.Length; index++)
        {
            _squares[index] = new Square(index);
        }
    }

    public void ClaimSquare()
    {
        Console.WriteLine();
        var index = ReadSquareIndex();
        var square = _squares[index];

        square.Claim();
    }

    public void Show()
    {
        for (var row = 0; row < Height; row++)
        {
            for (var col = 0; col < Width; col++)
            {
                var index = row * Width + col;
                _squares[index].Show();
            }

            Console.WriteLine();
        }
    }

    private static int ReadSquareIndex()
    {
        while (true)
        {
            Console.Write("Velg rute fra 0 til 63: ");
            var input = Console.ReadLine();

            var isNumber = int.TryParse(input, out var index);
            if (isNumber && index is >= 0 and < SquareCount)
            {
                return index;
            }

            Console.WriteLine("Ugyldig rute. Skriv et tall fra 0 til 63.");
        }
    }
}
