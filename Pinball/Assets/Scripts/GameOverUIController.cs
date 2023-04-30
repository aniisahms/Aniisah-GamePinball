using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    public Button mainMenuButton;
    public Button replayButton;

    private void Start() {
        gameObject.SetActive(false);
        mainMenuButton.onClick.AddListener(BackToMainMenu);
        replayButton.onClick.AddListener(PlayAgain);
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    private void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
