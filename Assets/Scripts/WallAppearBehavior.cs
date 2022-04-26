using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAppearBehavior : MonoBehaviour
{
    public GameObject climbingWall;

    // Update is called once per frame
    void Update()
    {
        if(!GlobalBehavior.calibrationMode && !GlobalBehavior.wallActive && GlobalBehavior.calibrationFinished) {
            climbingWall.SetActive(true);
            GlobalBehavior.wallActive = true;
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("CalibrationCube");
            foreach (GameObject c in cubes)
            {
                c.SetActive(false);
            }
        }
    }
}
