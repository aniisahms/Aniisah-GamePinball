using UnityEngine;

public class SFXAudioController : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1.0f);
        Debug.Log("SFX: " + gameObject.name + " has been destroyed");
    }
}