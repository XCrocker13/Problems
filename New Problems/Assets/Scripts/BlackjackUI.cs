using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BlackjackUI : MonoBehaviour
{
    [Header("Game Manager")]
    [SerializeField] private BlackJackManager gameManager;

    [Header("UI Text")]
    [SerializeField] private TMP_Text playerTotalText;
    [SerializeField] private TMP_Text cpuTotalText;
    [SerializeField] private TMP_Text roundStatusText;

    [Header("Buttons")]
    [SerializeField] private Button startRoundButton;
    [SerializeField] private Button hitButton;
    [SerializeField] private Button standButton;

    [Header("Card UI")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform playerCardContainer;
    [SerializeField] private Transform cpuCardContainer;

    private void Start()
    {
        startRoundButton.onClick.AddListener(StartRound);
        hitButton.onClick.AddListener(Hit);
        standButton.onClick.AddListener(Stand);

        UpdateUI();
    }

    private void StartRound()
    {
        gameManager.StartRound();
        UpdateUI();
    }

    private void Hit()
    {
        gameManager.PlayerHit();
        UpdateUI();
    }

    private void Stand()
    {
        gameManager.PlayerStand();
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (gameManager == null || gameManager.PlayerHand == null ||
            gameManager.CpuHand == null)
        {
            playerTotalText.text = "Player: --";
            cpuTotalText.text = "CPU: --";
            roundStatusText.text = "Press Start Round!";
            return;
        }

        playerTotalText.text = "Player Total: " + gameManager.PlayerHand.GetValue();
        cpuTotalText.text = "CPU Total: " + gameManager.CpuHand.GetValue();
        DisplayHand();
        

        switch (gameManager.CurrentRoundState)
        {
            case BlackJackManager.RoundState.PlayerTurn:
                roundStatusText.text = "Your Turn!";
                break;
            case BlackJackManager.RoundState.CpuTurn:
                roundStatusText.text = "CPU Turn!";
                break;
            case BlackJackManager.RoundState.PlayerWin:
                roundStatusText.text = "You Win!";
                break;
            case BlackJackManager.RoundState.PlayerLose:
                roundStatusText.text = "You Lose!";
                break;
            case BlackJackManager.RoundState.Push:
                roundStatusText.text = "It's a Push!";
                break;
            default:
                roundStatusText.text = "Press Start Round!";
                break;
        }
    }

    private void DisplayHand(Hand hand, Transform container, bool hideSecondCard)
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < hand.Cards.Count; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, container);
            CardUI cardUI = newCard.GetComponent<CardUI>();
            bool faceDown = hideSecondCard && i == 1;
            cardUI.SetCard(hand.Cards[i], faceDown);
        }
    }

    private void DisplayHand()
    {
        DisplayHand(gameManager.PlayerHand, playerCardContainer, false);

        bool hideCpuCard = gameManager.CurrentRoundState == BlackJackManager.RoundState.PlayerTurn;

        DisplayHand(gameManager.CpuHand, cpuCardContainer, hideCpuCard);
    }
}
