using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameTimer : MonoBehaviour
{

    public GameObject winPanel;
    public GameObject losePanel;

    public float timeLimit = 120f; // 2 minutes
    private float currentTime;
    public TMP_Text timerText; // Link a UI Text component
    public DeliveryManager deliveryManager; // Reference to your delivery tracking script

    private bool gameEnded = false;

    void Start()
    {
        currentTime = timeLimit;
    }

    void Update()
    {
        if (gameEnded) return;

        currentTime -= Time.deltaTime;
        currentTime = Mathf.Clamp(currentTime, 0f, timeLimit);

        UpdateTimerUI();

        if (currentTime <= 0)
        {
            GameOver(false); // Time's up!
        }

        // Check win condition
        if (deliveryManager.AllPackagesDelivered())
        {
            GameOver(true); // Delivered all packages in time
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver(bool win)
    {
        gameEnded = true;

        if (win)
        {
            Debug.Log("You win!");
            winPanel.SetActive(true);
            // Load win screen or show message
        }
        else
        {
            Debug.Log("Time's up! You lose.");
            losePanel.SetActive(true);
            // Load lose screen or show message
        }
    }
}
