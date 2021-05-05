using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    private int score;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        score = 0;
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    public void OnScores()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
