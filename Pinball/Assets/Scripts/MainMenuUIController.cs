using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuUIController : MonoBehaviour
{
    public Button playGameButton;
    public Button exitGameButton;
    public Button creditsButton;

    private void Start() {
        playGameButton.onClick.AddListener(PlayGame);
        exitGameButton.onClick.AddListener(ExitGame);
        creditsButton.onClick.AddListener(SeeCredits);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("PinballPlayScene");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void SeeCredits()
    {
        SceneManager.LoadScene("CreditScene");
    }
}
