using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class handles global static behavior that is read across various scripts in the game.
// The main components are: calibration points that get set for each hand on the side and above the head;
// whether the wall is active and the game has started; the list of danger knobs; customizations like colors of the knob;
// and the ability to replay the game.
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

    public static bool enableReplay = false;

    public static List<GameObject> dangerKnobs = new List<GameObject>();

    public static Material rightColor;
    public static Material leftColor;
}