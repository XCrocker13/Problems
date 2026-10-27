using System.Collections.Generic;

public class Hand
{
    private readonly List<Card> cards = new List<Card>();

    public IReadOnlyList<Card> Cards => cards.AsReadOnly();

    public void AddCard(Card card)
    {
        if (card != null)
        {
            cards.Add(card);
        }
    }

    public bool RemoveCard(Card card)
    {
        return cards.Remove(card);
    }

    public void ClearHand()
    {
        cards.Clear();
    }

    public int GetValue()
    {
        int totalValue = 0;
        int aceCount = 0;

        foreach (Card card in cards)
        {
            totalValue += card.GetCardValue();

            if (card.Rank == Rank.Ace)
            {
                aceCount++;
            }
        }

        // Count one Ace as 11 (rather than 1) if it does not cause a bust.
        if (aceCount > 0 && totalValue + 10 <= 21)
        {
            totalValue += 10;
        }

        return totalValue;
    }

    public bool IsSoftHand()
    {
        int totalValue = 0;
        int aceCount = 0;

        foreach (Card card in cards)
        {
            totalValue += card.GetCardValue();

            if (card.Rank == Rank.Ace)
            {
                aceCount++;
            }
        }

        return aceCount > 0 && totalValue + 10 <= 21;
    }

    public bool IsBust()
    {
        return GetValue() > 21;
    }

    public bool IsBlackjack()
    {
        return cards.Count == 2 && GetValue() == 21;
    }
}
