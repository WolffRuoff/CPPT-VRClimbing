using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class manages the calibration UI (the various buttons and text associated with calibrating)
public class CalibrationUIBehavior : MonoBehaviour
{
    public GameObject calibrationText;
    public GameObject nextCalibrationText;
    public GameObject recalibrateText;
    public GameObject recalibrateButtons;

    // Update is called once per frame
    void Update()
    {
        if (GlobalBehavior.calibrationMode) {
            if (GlobalBehavior.sidewaysCalibration) {
                calibrationText.SetActive(true);
                nextCalibrationText.SetActive(false);
            } else {
                calibrationText.SetActive(false);
                nextCalibrationText.SetActive(true);                
            }
            recalibrateText.SetActive(false);
            recalibrateButtons.SetActive(false);

        } else if (!GlobalBehavior.calibrationMode && GlobalBehavior.calibrationFinished && !GlobalBehavior.wallActive) {
            calibrationText.SetActive(false);
            nextCalibrationText.SetActive(false);
            recalibrateText.SetActive(true);
            recalibrateButtons.SetActive(true);
        }
    }
}
