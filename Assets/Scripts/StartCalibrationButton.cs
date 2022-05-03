using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCalibrationButton : MonoBehaviour
{
    public GameObject button;

    public void OnButtonClick() {
        if (GlobalBehavior.calibrationMode == false) {
            GlobalBehavior.calibrationMode = true;
        }
        //SFindObjectOfType<PointableCanvasModule>().RemovePointerCanvas(button.GetComponentInParent<PointableCanvas>());
        button.gameObject.SetActive(false);
    }
}