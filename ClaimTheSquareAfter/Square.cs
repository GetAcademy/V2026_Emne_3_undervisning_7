namespace ClaimTheSquareAfter;

public class Square
{
    public Square(int index)
    {
        Index = index;
    }

    public int Index { get; }
    public string? Text { get; private set; }
    public GameColor? ForeColor { get; private set; }
    public GameColor? BackColor { get; private set; }

    public bool IsEmpty()
    {
        return Text == null;
    }

    public ClaimResult Claim(string? text, GameColor foreColor, GameColor backColor)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return ClaimResult.Failure("Teksten kan ikke vaere tom.");
        }

        if (IsEmpty())
        {
            Text = text;
            ForeColor = foreColor;
            BackColor = backColor;
            return ClaimResult.Success("Ruten ble tatt.");
        }

        if (text != Text)
        {
            return ClaimResult.Failure("Ruten er allerede tatt. Du maa skrive samme tekst for aa bytte farger.");
        }

        if (foreColor.Name != BackColor!.Name || backColor.Name != ForeColor!.Name)
        {
            return ClaimResult.Failure("Fargene maa vaere motsatt av forrige valg.");
        }

        ForeColor = foreColor;
        BackColor = backColor;
        return ClaimResult.Success("Fargene ble byttet.");
    }
}
