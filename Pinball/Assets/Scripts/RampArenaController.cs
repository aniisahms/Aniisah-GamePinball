using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampArenaController : MonoBehaviour
{
    [SerializeField] Collider ball;
    public GameObject rampAudioSource;
    [SerializeField] AudioManager audioManager;

    private void OnTriggerEnter(Collider other) {
        rampAudioSource.SetActive(true);
        if (other == ball)
        {
            // play sfx
            audioManager.PlaySFX(other.transform.position, rampAudioSource);
        }
    }

    private void OnTriggerExit(Collider other) {
        rampAudioSource.SetActive(false);
    }
}
