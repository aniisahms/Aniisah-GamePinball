using UnityEngine;

public class VFXController : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1.0f);
        Debug.Log("VFX: " + gameObject.name + " has been destroyed");
    }
}
