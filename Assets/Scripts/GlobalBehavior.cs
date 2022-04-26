using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalBehavior : MonoBehaviour
{
    public static bool calibrationMode = false;
    public static bool calibrationFinished = false;

    public static bool rightHandCalibrationSet = false;
    public static Vector3 rightSpawnPos;

    public static bool leftHandCalibrationSet = false;
    public static Vector3 leftSpawnPos;
}