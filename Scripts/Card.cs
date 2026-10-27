public class Card
{
    public Suit Suit { get; }
    public Rank Rank { get; }

    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public int GetCardValue()
    {
        if (Rank == Rank.Jack || Rank == Rank.Queen || Rank == Rank.King)
        {
            return 10;
        }

        return (int)Rank;
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}
