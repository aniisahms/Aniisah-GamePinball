using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOutController : MonoBehaviour
{
    public Collider ball;
    public CameraController cameraController;

    private void OnTriggerEnter(Collider other)
    {
        if (other == ball)
        {
            ZoomOut();
        }
    }

    public void ZoomOut()
    {
        cameraController.GoBackToDefault();
    }
}
