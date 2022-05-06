using Oculus.Interaction.Grab;
using UnityEngine;

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

        public void Initialize(IGrabbable grabbable)
        {
            _grabbable = grabbable;
            lHand = GameObject.FindGameObjectWithTag("LHandAnchor");
            rHand = GameObject.FindGameObjectWithTag("RHandAnchor");
            player = GameObject.FindGameObjectWithTag("Player");
        }

        public void BeginTransform()
        {
            SetGrabbingHand();
            initialHandPos = currentHand.transform.position;

            this.gameObject.GetComponent<Outline>().enabled = false;

            // TODO: clean up switch statement section below (added for wayfinding)
            //char difficulty = _grabbable.Transform.gameObject.name.Split
            switch(_grabbable.Transform.gameObject.name) {
                case "E1":
                    GameObject.Find("E2").GetComponent<Outline>().enabled=true;
                    break;
                case "E2":
                    GameObject.Find("E3").GetComponent<Outline>().enabled = true;
                    break;
                case "E3":
                    GameObject.Find("E4").GetComponent<Outline>().enabled=true;
                    break;
                case "E4":
                    GameObject.Find("E5").GetComponent<Outline>().enabled=true;
                    break;
                case "E5":
                    GameObject.Find("E6").GetComponent<Outline>().enabled=true;
                    break;
                case "E6":
                    GameObject.Find("E7").GetComponent<Outline>().enabled=true;
                    break;
                case "E7":
                    GameObject.Find("E8").GetComponent<Outline>().enabled=true;
                    break;
                case "E8":
                    GameObject.Find("E9").GetComponent<Outline>().enabled=true;
                    break;
                case "E9":
                    GameObject.Find("E10").GetComponent<Outline>().enabled=true;
                    break;
                case "E10":
                    GameObject.Find("E11").GetComponent<Outline>().enabled=true;
                    break;
                case "E11":
                    GameObject.Find("E12").GetComponent<Outline>().enabled=true;
                    break;
                case "E12":
                    GameObject.Find("E13").GetComponent<Outline>().enabled=true;
                    break;
                case "E13":
                    GameObject.Find("E14").GetComponent<Outline>().enabled=true;
                    break;
                case "E14":
                    GameObject.Find("E15").GetComponent<Outline>().enabled=true;
                    break;
                case "E15":
                    GameObject.Find("E16").GetComponent<Outline>().enabled=true;
                    break;
                case "M1":
                    GameObject.Find("M2").GetComponent<Outline>().enabled = true;
                    break;
                case "M2":
                    GameObject.Find("M3").GetComponent<Outline>().enabled = true;
                    break;
                case "M3":
                    GameObject.Find("M4").GetComponent<Outline>().enabled = true;
                    break;
                case "M4":
                    GameObject.Find("M5").GetComponent<Outline>().enabled = true;
                    break;
                case "M5":
                    GameObject.Find("M6").GetComponent<Outline>().enabled = true;
                    break;
                case "M6":
                    GameObject.Find("M7").GetComponent<Outline>().enabled = true;
                    break;
                case "M7":
                    GameObject.Find("M8").GetComponent<Outline>().enabled = true;
                    break;
                case "M8":
                    GameObject.Find("M9").GetComponent<Outline>().enabled = true;
                    break;
                case "M9":
                    GameObject.Find("10").GetComponent<Outline>().enabled = true;
                    break;
                case "M10":
                    GameObject.Find("M11").GetComponent<Outline>().enabled = true;
                    break;
                case "M11":
                    GameObject.Find("M12").GetComponent<Outline>().enabled = true;
                    break;
                case "M12":
                    GameObject.Find("M13").GetComponent<Outline>().enabled = true;
                    break;
                case "M13":
                    GameObject.Find("M14").GetComponent<Outline>().enabled = true;
                    break;
                case "H1":
                    GameObject.Find("H2").GetComponent<Outline>().enabled = true;
                    break;
                case "H2":
                    GameObject.Find("H3").GetComponent<Outline>().enabled = true;
                    break;
                case "H3":
                    GameObject.Find("H4").GetComponent<Outline>().enabled = true;
                    break;
                case "H4":
                    GameObject.Find("H5").GetComponent<Outline>().enabled = true;
                    break;
                case "H5":
                    GameObject.Find("H6").GetComponent<Outline>().enabled = true;
                    break;
                case "H6":
                    GameObject.Find("H7").GetComponent<Outline>().enabled = true;
                    break;
                case "H7":
                    GameObject.Find("H8").GetComponent<Outline>().enabled = true;
                    break;
                case "H8":
                    GameObject.Find("H9").GetComponent<Outline>().enabled = true;
                    break;
                case "H9":
                    GameObject.Find("H10").GetComponent<Outline>().enabled = true;
                    break;
                case "H10":
                    GameObject.Find("H11").GetComponent<Outline>().enabled = true;
                    break;
                default:
                    break;
            }

        }

        public void UpdateTransform()
        {
            if(currentHand.GetComponent<OVRHand>().HandConfidence == OVRHand.TrackingConfidence.Low)
            {
                Debug.Log("Low Hand Confidence");
            }
            if(!currentHand.GetComponent<OVRHand>().IsTracked)
            {
                Debug.Log("Lost Tracking of hand");
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
                    Debug.Log("Unselecting " + hand.name);
                    hand.GetComponent<IInteractor>().Unselect();
                }
            }
        }
    }
}
