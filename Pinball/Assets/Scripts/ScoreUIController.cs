using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUIController : MonoBehaviour
{
    public ScoreManager scoreManager;
    public TMP_Text scoreCountText;

    private void Update() {
        scoreCountText.text = scoreManager.score.ToString();
    }
}
