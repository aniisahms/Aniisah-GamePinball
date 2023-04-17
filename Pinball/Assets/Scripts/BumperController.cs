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

            animator.SetTrigger("Hit Trigger");
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
