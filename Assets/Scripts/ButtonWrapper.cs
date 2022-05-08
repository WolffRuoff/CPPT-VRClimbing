using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWrapper : MonoBehaviour
{

    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject cubeToSpawn;

    public GameObject pauseMenu;
    public GameObject pauseButtons;

    public GameObject originalCalibrationText;
    public GameObject nextCalibrationText;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        pauseButtons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // Checking for grab buttons
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch)) {
            Grabbing(2);
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
            LettingGo(2);
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            Grabbing(3);
        }
        else if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            LettingGo(3);
        }

        // Checking for triggers
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            Selecting(2);
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            UnSelect(2);
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            Selecting(3);
        }
        else if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            UnSelect(3);
        }
    }

    public void Grabbing(float controller)
    {
        //0 is left hand, 1 is right hand, 2 is left controller, 3 is right controller
        Debug.Log("Grabbing with " + controller);
    }

    public void LettingGo(float controller)
    {
        //0 is left hand, 1 is right hand, 2 is left controller, 3 is right controller
        Debug.Log("Letting go with " + controller);
    }

    public void Selecting(float controller)
    {
        if (GlobalBehavior.calibrationMode) {
            if (controller == 1) { 
                if (!GlobalBehavior.rightHandCalibrationSet) {
                    GlobalBehavior.rightSpawnPos = rightHand.transform.position;
                    GlobalBehavior.rightHandCalibrationSet = true;
                    Instantiate(cubeToSpawn, GlobalBehavior.rightSpawnPos, Quaternion.identity);
                } else if (!GlobalBehavior.sidewaysCalibration && !GlobalBehavior.rightHandUpCalibrationSet) {
                    GlobalBehavior.rightUpSpawnPos = rightHand.transform.position;
                    GlobalBehavior.rightHandUpCalibrationSet = true;
                    Instantiate(cubeToSpawn, GlobalBehavior.rightUpSpawnPos, Quaternion.identity);                   
                }
            } else if (controller == 0) { 
                if (!GlobalBehavior.leftHandCalibrationSet) {
                    GlobalBehavior.leftSpawnPos = leftHand.transform.position;
                    GlobalBehavior.leftHandCalibrationSet = true;
                    Instantiate(cubeToSpawn, GlobalBehavior.leftSpawnPos, Quaternion.identity);
                } else if (!GlobalBehavior.sidewaysCalibration && !GlobalBehavior.leftHandUpCalibrationSet) {
                    GlobalBehavior.leftUpSpawnPos = leftHand.transform.position;
                    GlobalBehavior.leftHandUpCalibrationSet = true;
                    Instantiate(cubeToSpawn, GlobalBehavior.leftUpSpawnPos, Quaternion.identity);                     
                }
            }
            if (GlobalBehavior.rightHandCalibrationSet && GlobalBehavior.leftHandCalibrationSet) {
                if (!GlobalBehavior.rightHandUpCalibrationSet && !GlobalBehavior.leftHandUpCalibrationSet) {
                    GlobalBehavior.sidewaysCalibration = false;
                    originalCalibrationText.SetActive(false);
                    nextCalibrationText.SetActive(true);
                } else if (GlobalBehavior.rightHandUpCalibrationSet && GlobalBehavior.leftHandUpCalibrationSet) {
                    GlobalBehavior.sidewaysCalibration = true;
                    GlobalBehavior.calibrationMode = false;
                    GlobalBehavior.calibrationFinished = true;
                }
            }
        }
        else if (GlobalBehavior.gameStarted) {
            pauseMenu.SetActive(true);
            pauseMenu.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, pauseMenu.transform.position.z);
            pauseButtons.SetActive(true);
            pauseButtons.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, pauseButtons.transform.position.z);
            GameObject.FindObjectOfType<RayController>().SetRaying(true);
            GlobalBehavior.replay = true;
        }
    }

    public void UnSelect(float controller)
    {
        //0 is left hand, 1 is right hand, 2 is left controller, 3 is right controller
        Debug.Log("UnSelecting with " + controller);
    }
}
