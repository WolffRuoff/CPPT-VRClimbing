using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sets the behavior for when the "Start Calibration" button is clicked
public class StartCalibrationButton : MonoBehaviour
{
    public GameObject button;

    public void OnButtonClick() {
        if (GlobalBehavior.calibrationMode == false) {
            GlobalBehavior.calibrationMode = true;
        }
        button.gameObject.SetActive(false);
    }
}