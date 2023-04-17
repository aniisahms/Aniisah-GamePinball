using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    private Rigidbody rbBall;

    void Start()
    {
        rbBall = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rbBall.velocity.magnitude > maxSpeed) {
            rbBall.velocity = rbBall.velocity.normalized * maxSpeed;
        }
    }
}
