using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationUIBehavior : MonoBehaviour
{
    public GameObject calibrationText;
    public GameObject recalibrateScreen;

    // Update is called once per frame
    void Update()
    {
        if (GlobalBehavior.calibrationMode) {
            calibrationText.SetActive(true);
            recalibrateScreen.SetActive(false);

        } else if (!GlobalBehavior.calibrationMode && GlobalBehavior.calibrationFinished && !GlobalBehavior.wallActive) {
            calibrationText.SetActive(false);
            recalibrateScreen.SetActive(true);
        }
    }
}
