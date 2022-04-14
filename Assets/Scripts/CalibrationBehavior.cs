using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationBehavior : MonoBehaviour
{
    public GameObject cube;
    public bool toggled = false;

    public void OnSelect() {
        if (!toggled) {
            cube.SetActive(false);
        } else {
            cube.SetActive(true);
        }
        toggled = !toggled;
    }
}
