using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text cardText;
    [SerializeField] private Image cardBackground;

    public void SetCard(Card card, bool faceDown = false)
    {
        if (faceDown)
        {
            cardText.text = "?";
            cardText.color = Color.white;
            cardBackground.color = Color.black;
            return;
        }
        cardBackground.color = Color.white;

        string rankText = card.Rank switch
        {
            Rank.Ace => "A",
            Rank.Two => "2",
            Rank.Three => "3",
            Rank.Four => "4",
            Rank.Five => "5",
            Rank.Six => "6",
            Rank.Seven => "7",
            Rank.Eight => "8",
            Rank.Nine => "9",
            Rank.Ten => "10",
            Rank.Jack => "J",
            Rank.Queen => "Q",
            Rank.King => "K",
            _ => ((int)card.Rank).ToString()
        };

        string suitText = card.Suit switch
        {
            Suit.Hearts => "♥",
            Suit.Diamonds => "♦",
            Suit.Clubs => "♣",
            Suit.Spades => "♠",
            _ => ""
        };

        cardText.text = rankText + "\n" + suitText;

        if (card.Suit == Suit.Hearts || card.Suit == Suit.Diamonds)
        {
            cardText.color = Color.red;
        }
        else
        {
            cardText.color = Color.black;
        }
    }
}