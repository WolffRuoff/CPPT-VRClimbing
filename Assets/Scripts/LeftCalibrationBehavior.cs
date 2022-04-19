using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCalibrationBehavior : MonoBehaviour
{
    public GameObject cubeToSpawn;
    public GameObject hand;

    public void OnSelect() {
        if (GlobalBehavior.calibrationMode) {
            GlobalBehavior.leftSpawnPos = hand.transform.position;
        }
    }

    public void OnDeselect() {
        if (GlobalBehavior.calibrationMode) {
            Instantiate(cubeToSpawn, GlobalBehavior.leftSpawnPos, Quaternion.identity);
        }
    }
}
