using UnityEngine;

public class BlackJackManager : MonoBehaviour
{
    private Deck deck;
    private Hand playerHand;
    private Hand cpuHand;

    public Hand PlayerHand => playerHand;
    public Hand CpuHand => cpuHand;

    public enum RoundState
    {
        NotStarted,
        PlayerTurn,
        CpuTurn,
        PlayerWin,
        PlayerLose,
        Push
    }

    public RoundState CurrentRoundState { get; private set; } = RoundState.NotStarted;

    public void StartRound()
    {
        deck = new Deck();
        playerHand = new Hand();
        cpuHand = new Hand();

        // Deal two cards to each hand, one at a time.
        playerHand.AddCard(deck.DrawCard());
        cpuHand.AddCard(deck.DrawCard());
        playerHand.AddCard(deck.DrawCard());
        cpuHand.AddCard(deck.DrawCard());

        CurrentRoundState = RoundState.PlayerTurn;

        Debug.Log("Player total: " + playerHand.GetValue());
        Debug.Log("CPU total: " + cpuHand.GetValue());

        // Check for a natural Blackjack before the player's turn continues.
        if (playerHand.IsBlackjack() || cpuHand.IsBlackjack())
        {
            DetermineWinner();
        }
    }

    public void PlayerHit()
    {
        if (CurrentRoundState != RoundState.PlayerTurn)
        {
            return;
        }

        playerHand.AddCard(deck.DrawCard());
        Debug.Log("Player total: " + playerHand.GetValue());

        if (playerHand.IsBust())
        {
            CurrentRoundState = RoundState.PlayerLose;
            Debug.Log("Player busts. CPU wins.");
        }
    }

    public void PlayerStand()
    {
        if (CurrentRoundState != RoundState.PlayerTurn)
        {
            return;
        }

        CurrentRoundState = RoundState.CpuTurn;
        CpuTurn();
    }

    private void CpuTurn()
    {
        while (cpuHand.GetValue() < 17)
        {
            cpuHand.AddCard(deck.DrawCard());
        }

        Debug.Log("CPU total: " + cpuHand.GetValue());
        DetermineWinner();
    }

    private void DetermineWinner()
    {
        int playerTotal = playerHand.GetValue();
        int cpuTotal = cpuHand.GetValue();

        bool playerBlackjack = playerHand.IsBlackjack();
        bool cpuBlackjack = cpuHand.IsBlackjack();

        if (playerBlackjack && cpuBlackjack)
        {
            CurrentRoundState = RoundState.Push;
        }
        else if (playerBlackjack)
        {
            CurrentRoundState = RoundState.PlayerWin;
        }
        else if (cpuBlackjack)
        {
            CurrentRoundState = RoundState.PlayerLose;
        }
        else if (playerTotal > 21)
        {
            CurrentRoundState = RoundState.PlayerLose;
        }
        else if (cpuTotal > 21)
        {
            CurrentRoundState = RoundState.PlayerWin;
        }
        else if (playerTotal > cpuTotal)
        {
            CurrentRoundState = RoundState.PlayerWin;
        }
        else if (cpuTotal > playerTotal)
        {
            CurrentRoundState = RoundState.PlayerLose;
        }
        else
        {
            CurrentRoundState = RoundState.Push;
        }

        Debug.Log("Round result: " + CurrentRoundState);
    }
}
