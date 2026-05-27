using ClaimTheSquareAfter;

namespace ClaimTheSquareAfter.Tests;

public class BoardTests
{
    [Test]
    public void ClaimSquare_WhenSquareIsEmpty_ClaimsSquare()
    {
        var board = new Board();
        var red = GameColor.Create("red")!;
        var blue = GameColor.Create("blue")!;

        var result = board.ClaimSquare(10, "GET", red, blue);
        var square = board.GetSquare(10);

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(square.Text, Is.EqualTo("GET"));
        Assert.That(square.ForeColor, Is.SameAs(red));
        Assert.That(square.BackColor, Is.SameAs(blue));
    }

    [Test]
    public void ClaimSquare_WhenIndexIsOutsideBoard_ReturnsError()
    {
        var board = new Board();
        var red = GameColor.Create("red")!;
        var blue = GameColor.Create("blue")!;

        var result = board.ClaimSquare(64, "GET", red, blue);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.ErrorMessage, Is.EqualTo("Ugyldig rute."));
    }
}
