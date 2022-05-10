using Oculus.Interaction.Grab;
using UnityEngine;

// This class handles the transformations that occur when climbing the mountain. By interacting with the 
// grabbable knobs, it determines how to interpret which hand is grabbing, and it also determines the
// next knob to highlight for wayfinding based on the currently grabbed knob. 
namespace Oculus.Interaction
{
    public class ClimbTransformer : MonoBehaviour, ITransformer
    {

        private IGrabbable _grabbable;
        private GameObject lHand;
        private GameObject rHand;
        private GameObject currentHand;
        private Vector3 initialHandPos;
        private GameObject player;

        private GameObject[] leftKnobs;
        private GameObject[] rightKnobs;

        public void Initialize(IGrabbable grabbable)
        {
            _grabbable = grabbable;
            lHand = GameObject.FindGameObjectWithTag("LHandAnchor");
            rHand = GameObject.FindGameObjectWithTag("RHandAnchor");
            player = GameObject.FindGameObjectWithTag("Player");

            leftKnobs = GameObject.FindGameObjectsWithTag("LeftKnob");
            rightKnobs = GameObject.FindGameObjectsWithTag("RightKnob");
        }

        public void BeginTransform()
        {
            SetGrabbingHand();
            initialHandPos = currentHand.transform.position;

            // clear any previous outlines since we've selected a new knob
            foreach(GameObject knob in leftKnobs){
                knob.GetComponent<Outline>().enabled=false;
            }
            foreach(GameObject knob in rightKnobs){
                knob.GetComponent<Outline>().enabled=false;
            }

            // determine which knob to outline next based on current knob
            int i = 1;
            while (i <= 14) {
                if (_grabbable.Transform.gameObject.name == "E" + i) {
                    try {
                        GameObject.Find("E" + (i + 1)).GetComponent<Outline>().enabled=true;
                    } catch {
                    }
                    break;
                }
                if (_grabbable.Transform.gameObject.name == "M" + i) {
                    try {
                        GameObject.Find("M" + (i + 1)).GetComponent<Outline>().enabled=true;
                    } catch {
                    }
                    break;
                }
                if (_grabbable.Transform.gameObject.name == "H" + i) {
                    try {
                        GameObject.Find("H" + (i + 1)).GetComponent<Outline>().enabled=true;
                    } catch {
                    }
                    break;
                }         
                i = i + 1;       
            }
        }

        public void UpdateTransform()
        {
            if(currentHand.GetComponentInChildren<OVRHand>().HandConfidence == OVRHand.TrackingConfidence.Low && OVRPlugin.GetHandTrackingEnabled())
            {
                Debug.Log("Low Hand Confidence");
                return;
            }
            Vector3 worldOffsetFromGrab = initialHandPos - currentHand.transform.position;

            player.transform.position += worldOffsetFromGrab;
            currentHand.transform.position = initialHandPos;
        }

        public void EndTransform() {
        }

        private void SetGrabbingHand()
        {
            foreach (GameObject hand in GameObject.FindGameObjectsWithTag("GrabInteractor"))
            {
                if (hand.GetComponent<IHandGrabInteractor>().HandGrabApi.transform.GetPose().Equals(_grabbable.GrabPoints[0])) {
                    if (hand.name.Contains("Left"))
                    {
                        currentHand = lHand;
                    }
                    else
                    {
                        currentHand = rHand;
                    }
                }
                else
                {
                    hand.GetComponent<IInteractor>().Unselect();
                }
            }
        }
    }
}
