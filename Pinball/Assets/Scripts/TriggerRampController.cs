using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRampController : MonoBehaviour
{
    public Collider ball;
    public ScoreManager scoreManager;
    public float score;

    public GameObject rampPassAudioSource;
    [SerializeField] AudioManager audioManager;

    [SerializeField] ZoomInController zoomInController;
    [SerializeField] ZoomOutController zoomOutController;

    private void OnTriggerEnter(Collider other)
    {
        if (other == ball)
        {
            // zoom in camera
            zoomInController.ZoomIn();

            // add score
            scoreManager.AddScore(score);

            // play sfx
            audioManager.PlaySFX(transform.position, rampPassAudioSource);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other == ball)
        {
            // zoom out camera
            zoomOutController.ZoomOut();
        }
    }
}
