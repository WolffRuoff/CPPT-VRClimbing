using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationUIBehavior : MonoBehaviour
{
    public GameObject calibrationText;
    public GameObject recalibrateText;
    public GameObject recalibrateButtons;

    // Update is called once per frame
    void Update()
    {
        if (GlobalBehavior.calibrationMode) {
            calibrationText.SetActive(true);
            recalibrateText.SetActive(false);
            recalibrateButtons.SetActive(false);

        } else if (!GlobalBehavior.calibrationMode && GlobalBehavior.calibrationFinished && !GlobalBehavior.wallActive) {
            calibrationText.SetActive(false);
            recalibrateText.SetActive(true);
            recalibrateButtons.SetActive(true);
        }
    }
}
