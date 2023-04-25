using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    [SerializeField] Collider ballCollider;
    [SerializeField] KeyCode input;
    private float force;
    private float timeHold;
    [SerializeField] float maxForce;
    [SerializeField] float maxTimeHold;
    private bool isHold = false;

    [SerializeField] Material baseMaterial;
    [SerializeField] Material holdMaterial;
    private Renderer launcherRenderer;

    public GameObject launcherAudioSource;
    [SerializeField] AudioManager audioManager;

    private void Start() {
        launcherRenderer = GetComponent<Renderer>();
    }

    private void OnCollisionStay(Collision collision) {
        if (collision.collider == ballCollider)
        {
            ReadInput(ballCollider);
        }
    }

    private void ReadInput(Collider collider) {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(collider));

            // play sfx
            audioManager.PlaySFX(collider.transform.position, launcherAudioSource);
        }
    }

    private IEnumerator StartHold(Collider collider) {
        isHold = true;
        force = 0.0f;
        timeHold = 0.0f;
        launcherRenderer.material = holdMaterial;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold/maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;   
        }

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
        launcherRenderer.material = baseMaterial;
        Debug.Log("Launched");
    }
}
