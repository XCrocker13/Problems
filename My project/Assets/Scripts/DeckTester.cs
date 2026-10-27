using UnityEngine;

public class DeckTester : MonoBehaviour
{
    private void Start()
    {
        TestDeck();
        TestBlackjackHand();
        TestBustHand();
    }

    private void TestDeck()
    {
        Deck deck = new Deck();

        Debug.Log("New deck count (should be 52): " + deck.Count);

        Card firstCard = deck.DrawCard();
        Card secondCard = deck.DrawCard();

        Debug.Log("Drew: " + firstCard);
        Debug.Log("Drew: " + secondCard);
        Debug.Log("Remaining deck count (should be 50): " + deck.Count);
    }

    private void TestBlackjackHand()
    {
        Hand hand = new Hand();
        hand.AddCard(new Card(Suit.Spades, Rank.Ace));
        hand.AddCard(new Card(Suit.Hearts, Rank.King));

        Debug.Log("Ace + King value (should be 21): " + hand.GetValue());
        Debug.Log("Is soft hand (should be true): " + hand.IsSoftHand());
        Debug.Log("Is Blackjack (should be true): " + hand.IsBlackjack());
    }

    private void TestBustHand()
    {
        Hand hand = new Hand();
        hand.AddCard(new Card(Suit.Spades, Rank.King));
        hand.AddCard(new Card(Suit.Hearts, Rank.Queen));
        hand.AddCard(new Card(Suit.Clubs, Rank.Five));

        Debug.Log("King + Queen + Five value (should be 25): " + hand.GetValue());
        Debug.Log("Is bust (should be true): " + hand.IsBust());
    }
}
