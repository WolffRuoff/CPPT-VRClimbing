using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAppearBehavior : MonoBehaviour
{
    public GameObject climbingWall;

    public GameObject calibrationText;
    public GameObject[] recalibrateButtons;


    public GameObject manipulationText;
    public GameObject[] manipulationButtons;

    // Update is called once per frame
    public void ManipulateWall()
    {
        calibrationText.SetActive(false);
        ChangeRecalibrateButtons(false);
        if(!GlobalBehavior.calibrationMode && !GlobalBehavior.wallActive && GlobalBehavior.calibrationFinished) {
            climbingWall.SetActive(true);

            climbingWall.transform.position = new Vector3(0.0f,5.11f,20f);
            ChangeManipulateButtons(true);
            manipulationText.SetActive(true);

            GameObject.FindObjectOfType<RayController>().SetRaying(true);
            GlobalBehavior.wallActive = true;
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("CalibrationCube");
            foreach (GameObject c in cubes)
            {
                c.SetActive(false);
            }
        }
    }
    public void ChangeManipulateButtons(bool v)
    {
        foreach (GameObject obj in manipulationButtons)
        {
            obj.SetActive(v);
        }
    }
    public void ChangeRecalibrateButtons(bool v)
    {
        foreach (GameObject obj in recalibrateButtons)
        {
            obj.SetActive(v);
        }
    }
    public void Recalibrate() {
        GlobalBehavior.calibrationMode = true;
        GlobalBehavior.calibrationFinished = false;
        GlobalBehavior.rightHandCalibrationSet = false;
        GlobalBehavior.leftHandCalibrationSet = false;
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("CalibrationCube");
        foreach (GameObject c in cubes)
        {
            c.SetActive(false);
        }
    }

    public void startPlay()
    {
        ChangeManipulateButtons(false);
        manipulationText.SetActive(false);

        climbingWall.transform.position = new Vector3(0.0f,5.11f,3.71f);

        // laserPointer.SetActive(false);
        GameObject.FindObjectOfType<RayController>().SetRaying(false);
    }
}
