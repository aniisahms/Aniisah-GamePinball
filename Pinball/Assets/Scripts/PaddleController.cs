using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] KeyCode input;
    private float targetPressed;
    private float targetReleased;

    private HingeJoint hJoint;
    private JointSpring jointSpring;

    [SerializeField] Collider ball;
    public GameObject paddleAudioSource;
    [SerializeField] AudioManager audioManager;
    private bool isHit = false;

    private void Start() {
        hJoint = GetComponent<HingeJoint>();

        targetPressed = hJoint.limits.max;
        targetReleased = hJoint.limits.min;
    }

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        jointSpring = hJoint.spring;

        if (Input.GetKey(input))
        {
            jointSpring.targetPosition = targetPressed;
            isHit = true;
        }
        else 
        {
            jointSpring.targetPosition = targetReleased;
            isHit = false;
        }

        hJoint.spring = jointSpring;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider == ball && isHit)
        {
            // play sfx
            audioManager.PlaySFX(transform.position, paddleAudioSource);
        }
    }
}
