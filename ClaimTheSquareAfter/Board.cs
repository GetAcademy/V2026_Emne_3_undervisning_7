namespace ClaimTheSquareAfter;

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

    public ClaimResult ClaimSquare(
        int index,
        string? text,
        GameColor foreColor,
        GameColor backColor)
    {
        if (index < 0 || index >= _squares.Length)
        {
            return ClaimResult.Failure("Ugyldig rute.");
        }

        return _squares[index].Claim(text, foreColor, backColor);
    }

    public Square GetSquare(int index)
    {
        return _squares[index];
    }
}
