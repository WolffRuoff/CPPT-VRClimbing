using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalBehavior : MonoBehaviour
{
    public static bool calibrationMode = false;
    public static bool calibrationFinished = false;

    public static bool sidewaysCalibration = true;

    public static bool rightHandCalibrationSet = false;
    public static Vector3 rightSpawnPos;

    public static bool leftHandCalibrationSet = false;
    public static Vector3 leftSpawnPos;

    public static bool rightHandUpCalibrationSet = false;
    public static Vector3 rightUpSpawnPos;

    public static bool leftHandUpCalibrationSet = false;
    public static Vector3 leftUpSpawnPos;

    public static bool wallActive = false;

    public static bool gameStarted = false;

    public static int rotateLevel = 0;
    public static bool replay = false;
}