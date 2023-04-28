using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerGameOver : MonoBehaviour
{
    public Collider ball;
    public GameObject gameOverCanvas;

    private void OnTriggerEnter(Collider other) {
        if (other == ball)
        {
            gameOverCanvas.SetActive(true);
        }
    }
}
