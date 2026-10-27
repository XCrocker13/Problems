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
}
