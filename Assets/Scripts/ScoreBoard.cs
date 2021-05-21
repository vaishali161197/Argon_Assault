using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreBoard : MonoBehaviour
{
    int score;
    TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString();
    }
    public void IncreaseScore(int AmountToIncrease)
    {
        score += AmountToIncrease;
        scoreText.text = score.ToString();
    }

    
}
