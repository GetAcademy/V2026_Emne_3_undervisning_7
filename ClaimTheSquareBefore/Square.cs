namespace ClaimTheSquareBefore;

public class Square
{
    private readonly int _index;
    private string? _text;
    private GameColor? _foreColor;
    private GameColor? _backColor;

    public Square(int index)
    {
        _index = index;
    }

    public bool IsEmpty()
    {
        return _text == null;
    }

    public void Claim()
    {
        Console.Write("Tekst: ");
        var text = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Velg forgrunnsfarge:");
        var foreColor = ColorMenu.ReadColor();

        Console.WriteLine();
        Console.WriteLine("Velg bakgrunnsfarge:");
        var backColor = ColorMenu.ReadColor();

        Console.WriteLine();

        if (IsEmpty())
        {
            _text = text;
            _foreColor = foreColor;
            _backColor = backColor;
            Console.WriteLine("Ruten ble tatt.");
            Pause();
            return;
        }

        if (text != _text)
        {
            Console.WriteLine("Ruten er allerede tatt. Du maa skrive samme tekst for aa bytte farger.");
            Pause();
            return;
        }

        if (foreColor.Name != _backColor!.Name || backColor.Name != _foreColor!.Name)
        {
            Console.WriteLine("Fargene maa vaere motsatt av forrige valg.");
            Pause();
            return;
        }

        _foreColor = foreColor;
        _backColor = backColor;
        Console.WriteLine("Fargene ble byttet.");
        Pause();
    }

    public void Show()
    {
        var oldForeColor = Console.ForegroundColor;
        var oldBackColor = Console.BackgroundColor;

        if (IsEmpty())
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($" {_index,2}    ");
        }
        else
        {
            Console.ForegroundColor = _foreColor!.ConsoleColor;
            Console.BackgroundColor = _backColor!.ConsoleColor;
            Console.Write($" {ShortText(_text!),-5} ");
        }

        Console.ForegroundColor = oldForeColor;
        Console.BackgroundColor = oldBackColor;
    }

   private static string ShortText(string text)
    {
        if (text.Length <= 5)
        {
            return text;
        }

        return text.Substring(0, 5);
    }

    private static void Pause()
    {
        Console.WriteLine();
        Console.Write("Trykk Enter for aa fortsette...");
        Console.ReadLine();
    }
}
