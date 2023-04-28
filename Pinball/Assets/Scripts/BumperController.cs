using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    [SerializeField] Collider ballCollider;
    [SerializeField] float multiplier;
    private bool bumped;

    private Rigidbody rbBall;
    private Renderer ballRenderer;

    private Animator animator;
    [SerializeField] Material notBumpedMaterial;
    [SerializeField] Material bumpedMaterial;
    private Renderer bumperRenderer;

    [SerializeField] AudioManager audioManager;
    public GameObject bumperAudioSource;
    [SerializeField] VFXManager vfxManager;
    public GameObject vfxBumper;

    public ScoreManager scoreManager;
    public float score;
    
    private void Start() {
        ballRenderer = GetComponent<Renderer>();
        bumperRenderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider == ballCollider && !bumped)
        {
            bumped = true;
            bumperRenderer.material = bumpedMaterial;

            rbBall = ballCollider.GetComponent<Rigidbody>();
            rbBall.velocity *= multiplier;

            // play animation
            animator.SetTrigger("Hit Trigger");
            Debug.Log("Bumper animation played");

            // play sfx
            audioManager.PlaySFX(transform.position, bumperAudioSource);

            // play vfx
            vfxManager.PlayVFX(transform.position, transform.rotation, vfxBumper);

            // add score
            scoreManager.AddScore(score);
        }
    }
    private void OnCollisionExit(Collision collision) {
        if (collision.collider == ballCollider && bumped)
        {
            bumped = false;
            bumperRenderer.material = notBumpedMaterial;
        }
    }
}
