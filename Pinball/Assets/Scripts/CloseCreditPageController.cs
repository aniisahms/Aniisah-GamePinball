using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CloseCreditPageController : MonoBehaviour
{
    public Button closePageButton;

    private void Start() {

        closePageButton.onClick.AddListener(CloseCreditPage);
    }

    private void CloseCreditPage()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
