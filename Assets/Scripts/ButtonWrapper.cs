using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWrapper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        //0 is left hand, 1 is right hand, 2 is left controller, 3 is right controller
        Debug.Log("Selecting with " + controller);
    }

    public void UnSelect(float controller)
    {
        //0 is left hand, 1 is right hand, 2 is left controller, 3 is right controller
        Debug.Log("UnSelecting with " + controller);
    }
}
