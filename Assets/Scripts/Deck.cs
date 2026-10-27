using System;
using System.Collections.Generic;

public class Deck
{
    private readonly List<Card> cards = new List<Card>();
    private readonly Random random = new Random();

    public int Count => cards.Count;

    public Deck()
    {
        CreateDeck();
        Shuffle();
    }

    public void CreateDeck()
    {
        cards.Clear();

        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                cards.Add(new Card(suit, rank));
            }
        }
    }

    public void Shuffle()
    {
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);

            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    public Card DrawCard()
    {
        if (cards.Count == 0)
        {
            throw new InvalidOperationException("The deck is empty.");
        }

        Card drawnCard = cards[0];
        cards.RemoveAt(0);
        return drawnCard;
    }
}
