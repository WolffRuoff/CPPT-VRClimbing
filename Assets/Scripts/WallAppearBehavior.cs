using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAppearBehavior : MonoBehaviour
{
    public GameObject climbingWall;

    public GameObject calibrationText;
    public GameObject recalibrateScreen;

    public GameObject laserPointer;

    public GameObject manipulationScreen;

    // Update is called once per frame
    public void ManipulateWall()
    {
        calibrationText.SetActive(false);
        recalibrateScreen.SetActive(false);
        if(!GlobalBehavior.calibrationMode && !GlobalBehavior.wallActive && GlobalBehavior.calibrationFinished) {
            // laserPointer.SetActive(false);
            climbingWall.SetActive(true);

            climbingWall.transform.position = new Vector3(0.0f,5.11f,20f);
            manipulationScreen.SetActive(true);
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

    public void startPlay()
    {
        manipulationScreen.SetActive(false);

        climbingWall.transform.position = new Vector3(0.0f,5.11f,3.71f);

        laserPointer.SetActive(false);
    }
}
