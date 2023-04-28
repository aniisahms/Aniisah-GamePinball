using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public void PlayVFX(Vector3 spawnPosition, Quaternion spawnRotation, GameObject vfx)
    {
        GameObject.Instantiate(vfx, spawnPosition, spawnRotation);
        Debug.Log("VFX: " + vfx.name + " played");
    }
}
