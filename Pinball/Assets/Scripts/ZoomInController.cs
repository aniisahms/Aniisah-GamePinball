using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInController : MonoBehaviour
{
    public Collider ball;
    public CameraController cameraController;
    public float length;

    private void OnTriggerEnter(Collider other) {
        if (other == ball)
        {
            ZoomIn();
        }
    }

    public void ZoomIn()
    {
        cameraController.FollowTarget(ball.transform, length);
    }
}
