using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource bgmAudioSource;

    private void Start()
    {
        PlayBGM();
    }

    private void PlayBGM()
    {
        bgmAudioSource.Play();
    }

    public void PlaySFX(Vector3 spawnPosition, GameObject audioSource)
    {
        GameObject.Instantiate(audioSource, spawnPosition, Quaternion.identity);
        Debug.Log("SFX: " + audioSource.name + " played");
    }
}
