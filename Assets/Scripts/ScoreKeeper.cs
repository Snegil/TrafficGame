using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    int score;

    public void AddScore(int value)
    {
        Debug.Log(score + " " + value);
        score += value;
        
        UpdateScore();
    }
    public void UpdateScore()
    {
        text.text = "Score: " + score;
    }
}
