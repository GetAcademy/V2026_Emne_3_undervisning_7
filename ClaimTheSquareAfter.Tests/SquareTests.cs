using ClaimTheSquareAfter;

namespace ClaimTheSquareAfter.Tests;

public class SquareTests
{
    [Test]
    public void Claim_WhenTextIsEmpty_ReturnsError()
    {
        var square = new Square(0);
        var red = GameColor.Create("red")!;
        var blue = GameColor.Create("blue")!;

        var result = square.Claim("", red, blue);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(square.IsEmpty(), Is.True);
    }

    [Test]
    public void Claim_WhenSquareIsTakenWithDifferentText_ReturnsError()
    {
        var square = new Square(0);
        var red = GameColor.Create("red")!;
        var blue = GameColor.Create("blue")!;
        var green = GameColor.Create("green")!;
        var white = GameColor.Create("white")!;

        square.Claim("GET", red, blue);
        var result = square.Claim("Academy", green, white);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(square.Text, Is.EqualTo("GET"));
        Assert.That(square.ForeColor, Is.SameAs(red));
        Assert.That(square.BackColor, Is.SameAs(blue));
    }

    [Test]
    public void Claim_WhenSquareIsTakenWithSameTextAndSwappedColors_ChangesColors()
    {
        var square = new Square(0);
        var red = GameColor.Create("red")!;
        var blue = GameColor.Create("blue")!;

        square.Claim("GET", red, blue);
        var result = square.Claim("GET", blue, red);

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(square.Text, Is.EqualTo("GET"));
        Assert.That(square.ForeColor, Is.SameAs(blue));
        Assert.That(square.BackColor, Is.SameAs(red));
    }

    [Test]
    public void Claim_WhenSquareIsTakenWithSameTextButColorsAreNotSwapped_ReturnsError()
    {
        var square = new Square(0);
        var red = GameColor.Create("red")!;
        var blue = GameColor.Create("blue")!;
        var green = GameColor.Create("green")!;

        square.Claim("GET", red, blue);
        var result = square.Claim("GET", green, blue);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(square.ForeColor, Is.SameAs(red));
        Assert.That(square.BackColor, Is.SameAs(blue));
    }
}
