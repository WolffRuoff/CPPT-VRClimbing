using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinButton : MonoBehaviour
{

    [SerializeField] private float threshold = 0.05f;
    [SerializeField] private float deadZone = 0.025f;

    private bool isPressed;
    private Vector3 startPos;
    private ConfigurableJoint joint;

    public UnityEvent onPressed, onReleased;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPressed && GetValue() + threshold >= 1){
            Pressed();
        }
        if(isPressed && GetValue() - threshold <= 0){
            Released();
        }
    }

    private float GetValue(){
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;

        if(Math.Abs(value) < deadZone){
            value = 0;
        }

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed(){

        isPressed = true;
        onPressed.Invoke();

    }

    private void Released(){
        isPressed = false;
        onReleased.Invoke();
    }
}