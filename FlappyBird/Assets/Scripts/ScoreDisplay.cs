using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text textMeshPro; // Drag & drop your TextMeshPro UI element in Inspector
    int score = Manager.score;

    void Start()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        textMeshPro.text = "Score: " + score;
    }

    // Example method to update score dynamically
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText(); // Update UI
    }
}
