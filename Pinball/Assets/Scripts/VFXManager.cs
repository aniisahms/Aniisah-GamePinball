using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public void PlayVFX(Vector3 spawnPosition, GameObject vfx)
    {
        GameObject.Instantiate(vfx, spawnPosition, Quaternion.identity);
        Debug.Log("VFX: " + vfx.name + " played");
    }
}
