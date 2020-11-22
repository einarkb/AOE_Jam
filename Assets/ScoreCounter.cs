using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int currentScore { get; private set; } = 0;

    public TMPro.TextMeshProUGUI scoreCount;
    public TMPro.TextMeshProUGUI label;

    private void OnEnable()
    {
        EventManager.Instance.taskCompleted += (task) => IncreaseAndUpdateCount();
        EventManager.Instance.onGameStart += () => OnGameStart();
        EventManager.Instance.onGameover += () => OnGameOver();
    }

    private void OnDisable()
    {
        EventManager.Instance.taskCompleted -= (task) => IncreaseAndUpdateCount();
        EventManager.Instance.onGameStart -= () => OnGameStart();
        EventManager.Instance.onGameover -= () => OnGameOver();
    }

    private void OnGameStart()
    {
        currentScore = 0;
        scoreCount.text = "0";
        label.gameObject.SetActive(true);
        scoreCount.gameObject.SetActive(true);
    }

    private void OnGameOver()
    {
        label.gameObject.SetActive(false);
        scoreCount.gameObject.SetActive(false);
    }

    private void IncreaseAndUpdateCount()
    {
        currentScore++;
        scoreCount.text = currentScore.ToString();
    }
}
