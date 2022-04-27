using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAppearBehavior : MonoBehaviour
{
    public GameObject climbingWall;

    public GameObject calibrationText;
    public GameObject recalibrateScreen;

    public GameObject laserPointer;

    // Update is called once per frame
    public void GoToWall()
    {
        calibrationText.SetActive(false);
        recalibrateScreen.SetActive(false);
        if(!GlobalBehavior.calibrationMode && !GlobalBehavior.wallActive && GlobalBehavior.calibrationFinished) {
            laserPointer.SetActive(false);
            climbingWall.SetActive(true);
            GlobalBehavior.wallActive = true;
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("CalibrationCube");
            foreach (GameObject c in cubes)
            {
                c.SetActive(false);
            }
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
}
