using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCalibrationBehavior : MonoBehaviour
{
    public GameObject cubeToSpawn;
    public GameObject hand;

    public void OnSelect() {
        if (GlobalBehavior.calibrationMode) {
            GlobalBehavior.rightSpawnPos = hand.transform.position;
        }
    }

    public void OnDeselect() {
        if (GlobalBehavior.calibrationMode) {
            Instantiate(cubeToSpawn, GlobalBehavior.rightSpawnPos, Quaternion.identity);
        }
    }
}
