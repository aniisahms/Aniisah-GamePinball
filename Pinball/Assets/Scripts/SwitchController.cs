using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        switchOn,
        switchOff,
        switchBlink
    }

    [SerializeField] Collider ballCollider;
    [SerializeField] Material switchOnMaterial;
    [SerializeField] Material switchOffMaterial;
    private Renderer switchRenderer;
    private SwitchState switchState;


    void Start()
    {
        switchRenderer = GetComponent<Renderer>();
        SetActive(false);
        StartCoroutine(BlinkTimerStart(4));
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision == ballCollider) {
            ToggleSwitch();
        }
    }

    private void SetActive(bool isActive) {
        if (isActive == true) {
            switchState = SwitchState.switchOn;
            switchRenderer.material = switchOnMaterial;
            StopAllCoroutines();
        }
        else {
            switchState = SwitchState.switchOff;
            switchRenderer.material = switchOffMaterial;
            Debug.Log("SetActive: " + switchState);
        }
    }

    private void ToggleSwitch() {
        if (switchState == SwitchState.switchOn) {
            SetActive(false);
        }
        else {
            SetActive(true);
            Debug.Log("ToggleSwitch: " + switchState);
        }
    }

    private IEnumerator SwitchBlink(float times) {
        switchState = SwitchState.switchBlink;

        for (int i = 0; i < times; i++) {
            switchRenderer.material = switchOnMaterial;
            yield return new WaitForSeconds(0.3f);
            switchRenderer.material = switchOffMaterial;
            yield return new WaitForSeconds(0.3f);
        }
        Debug.Log("Blinking");

        switchState = SwitchState.switchOff;

        StartCoroutine(BlinkTimerStart(4));
    }

    private IEnumerator BlinkTimerStart(float timer) {
        yield return new WaitForSeconds(timer);
        StartCoroutine(SwitchBlink(2));
        Debug.Log("Blink timer start");
    }
}