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
        }
        else 
        {
            jointSpring.targetPosition = targetReleased;
        }

        hJoint.spring = jointSpring;
    }
}
