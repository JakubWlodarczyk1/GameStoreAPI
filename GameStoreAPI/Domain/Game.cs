namespace GameStore.API.Domain;

public class Game
{
    public Game() { }

    public Game(
        string? title,
        decimal price,
        int quantity
    )
    {
        Title = title;
        Price = price;
        Quantity = quantity;
    }

    public int Id { get; set; }
    public string? Title { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}