using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private int minValue;
    private int maxValue;

    [SerializeField] private TextMeshProUGUI playerScore;
    private float ScoreCount;
    private bool playerScoreAdd;


    [SerializeField] private Image fillImg;

    public void Start()
    {
        playerScore.text = "Score: " + ScoreCount.ToString();
    }


    public void SetValuesToHealthBar(int min, int max)
    {
        minValue = min;
        maxValue = max;

        FillHealthBar();
    }

    private void FillHealthBar()
    {

        float fill = (float)minValue / (float)maxValue;
        fillImg.fillAmount = fill;
    }


    public void SetValueToScore(int value)
    {
        ScoreCount = value;

        AddScore();
    }

    private void AddScore()
    {
        playerScoreAdd = true;

        playerScore.text = "Score: " + ScoreCount.ToString();
        playerScoreAdd = false;
    }
}
