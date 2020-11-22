using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public GameObject startButton;
    public ScoreCounter scoreCounter;
    public TMPro.TextMeshProUGUI Text;

    public TMPro.TextMeshProUGUI gameOverText;
    public TMPro.TextMeshProUGUI tasksCompleted;

    public void StartGame()
    {
        EventManager.Instance.onGameStart?.Invoke();
        startButton.SetActive(false);
        gameOverText.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.Instance.onGameover += () => OnGameOver();
    }

    private void OnDisable()
    {
        EventManager.Instance.onGameover += () => OnGameOver();
    }

    private void OnGameOver()
    {
        Text.text = "PLAY AGAIN";
        tasksCompleted.text = "You completed " + scoreCounter.currentScore.ToString() + " tasks!";
        gameOverText.gameObject.SetActive(true);
        startButton.SetActive(true);
    }
}
