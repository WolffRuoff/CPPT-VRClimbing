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

    public GameObject pauseMenu;
    public GameObject pauseButtons;

    public GameObject winText;
    public GameObject replayButton;

    public GameObject player;

    private bool restartGame = false;

    public void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void RestartGame() {
        restartGame = true;
        ManipulateWall();
    }

    // Update is called once per frame
    public void ManipulateWall()
    {
        calibrationText.SetActive(false);
        ChangeRecalibrateButtons(false);
        if(restartGame || (!GlobalBehavior.calibrationMode && !GlobalBehavior.wallActive && GlobalBehavior.calibrationFinished) || GlobalBehavior.replay) {
            climbingWall.SetActive(true);

            climbingWall.transform.position = new Vector3(0.0f,5.11f,20f);
            ChangeManipulateButtons(true);
            manipulationText.SetActive(true);

            GlobalBehavior.gameStarted = false;

            GameObject.FindObjectOfType<RayController>().SetRaying(true);
            GlobalBehavior.wallActive = true;
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("CalibrationCube");
            foreach (GameObject c in cubes)
            {
                c.SetActive(false);
            }

            GlobalBehavior.replay = false;

            pauseMenu.SetActive(false);
            pauseButtons.SetActive(false);
            winText.SetActive(false);
            replayButton.SetActive(false);

            player.transform.position = new Vector3(0f, 0f, 0f);
            restartGame = false;
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
        GlobalBehavior.rightHandUpCalibrationSet = false;
        GlobalBehavior.leftHandUpCalibrationSet = false;
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

        GlobalBehavior.gameStarted = true;
        Debug.LogWarning("Status of gamestarted: " + GlobalBehavior.gameStarted);

        // laserPointer.SetActive(false);
        GameObject.FindObjectOfType<RayController>().SetRaying(false);
    }
}
