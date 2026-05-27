namespace ClaimTheSquareBefore;

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
            _board.Show();
            Console.WriteLine();
            Console.WriteLine("1. Velg rute");
            Console.WriteLine("2. Avslutt");
            Console.Write("Hva vil du gjøre? ");

            var choice = Console.ReadLine();
            if (choice == "1")
            {
                _board.ClaimSquare();
            }
            else if (choice == "2")
            {
                return;
            }
        }
    }
}
