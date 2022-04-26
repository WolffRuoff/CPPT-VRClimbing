using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobScaler : MonoBehaviour
{
    

    public float defaultParentScale = 1f;

    // Parent of the Knob (the wall) that we change scale of
    private Transform knobParentTransform;

    private void Awake()
    {
        // COMMENT THIS OUT IF KNOBS ARE NOT CHILDREN OF WALL
        knobParentTransform = gameObject.transform.parent;
    }

    // 
    public void Update()
    {
        gameObject.transform.localScale = new Vector3(
            defaultParentScale / knobParentTransform.localScale.x,
            defaultParentScale / knobParentTransform.transform.localScale.y,
            defaultParentScale / knobParentTransform.transform.localScale.z);
    }
}
