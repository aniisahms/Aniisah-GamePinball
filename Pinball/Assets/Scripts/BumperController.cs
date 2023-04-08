using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    [SerializeField] Collider ball;
    [SerializeField] float multiplier;
    [SerializeField] Color bumpedColor;
    [SerializeField] Color notBumpedColor;
    private bool bumped;

    private Rigidbody rbBall;
    private Renderer renderer;
    private Animator animator;
    
    private void Start() {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        notBumpedColor = renderer.material.color;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider == ball && !bumped)
        {
            bumped = true;
            renderer.material.color = bumpedColor;

            rbBall = ball.GetComponent<Rigidbody>();
            rbBall.velocity *= multiplier;

            animator.SetTrigger("Hit Trigger");
        }
    }
    private void OnCollisionExit(Collision collision) {
        if (collision.collider == ball && bumped)
        {
            bumped = false;
            renderer.material.color = notBumpedColor;
        }
    }
}
